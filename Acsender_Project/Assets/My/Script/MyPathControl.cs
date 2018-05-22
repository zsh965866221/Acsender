using System;
using UnityEngine;
using System.Collections;

public class MyPathControl : MonoBehaviour {
    private MyPath mypath;
    private Animator myanim;
    private GameObject character;
    private MyUserPostionControll myUserPostionControll;
    private bool first = true;

    private GameObject Scene;
    private MySceneControll SceneControl;

    private bool isturnning = false;
    public int turnNum=0;
	// Use this for initialization
	void Start ()
	{
        character=GameObject.Find("MyCharacter");
        Scene = GameObject.Find("Scene");
        SceneControl = Scene.GetComponent<MySceneControll>();
        
	    mypath = GetComponent<MyPath>();
	    myanim = GetComponent<Animator>();
	    myUserPostionControll = character.GetComponent<MyUserPostionControll>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (first)
	    {
            mypath.complete = false;
            myUserPostionControll.turn = true;
            mypath.path[1].position = transform.right * 0.3f + new Vector3(myUserPostionControll.currectPostion.x, myUserPostionControll.currectPostion.y+2.5f, myUserPostionControll.currectPostion.z);
            
            myanim.SetTrigger("N2");
	        first = false;
	    }
	    if (!isturnning)
	    {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isturnning = true;
                mypath.complete = false;
                myUserPostionControll.turn = true;
                mypath.path[1].position = transform.right * 0.3f + new Vector3(myUserPostionControll.currectPostion.x, myUserPostionControll.currectPostion.y+2.5f, myUserPostionControll.currectPostion.z);

                myanim.SetTrigger("N2");
                SceneControl.SceneChanged = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                isturnning = true;
                mypath.complete = false;
                myUserPostionControll.turn = true;
                mypath.path[1].position = -transform.right * 0.3f + new Vector3(myUserPostionControll.currectPostion.x, myUserPostionControll.currectPostion.y+2.5f, myUserPostionControll.currectPostion.z);

                myanim.SetTrigger("N1");
                SceneControl.SceneChanged = true;
            }
	    }
	}

    public void RotateComplete()
    {
        mypath.path[0] = transform;
        mypath.self.transform.rotation = transform.rotation;
        myanim.SetTrigger("Complete");
        if (Math.Abs(0 - transform.forward.x) > 0.001)
        {
            myUserPostionControll.FixedPostion = myUserPostionControll.currectPostion.x;
        }
        if (Math.Abs(0 - transform.forward.z) > 0.001)
        {
            myUserPostionControll.FixedPostion = myUserPostionControll.currectPostion.z;
        }
        mypath.complete = true;
        myUserPostionControll.turn = false;
        isturnning = false;

    }
}
