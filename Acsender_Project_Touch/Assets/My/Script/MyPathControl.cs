using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MyPathControl : MonoBehaviour {
    private MyPath mypath;
    private Animator myanim;
    private GameObject character;
    private MyUserPostionControll myUserPostionControll;
    private bool first = true;

    private bool isturnning = false;
    private bool isQ = false;
    private bool isE = false;

	// Use this for initialization
	void Start ()
	{
        character=GameObject.Find("MyCharacter");
        
	    mypath = GetComponent<MyPath>();
	    myanim = GetComponent<Animator>();
	    myUserPostionControll = character.GetComponent<MyUserPostionControll>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (first)
	    {
	        isturnning = true;
            mypath.complete = false;
            myUserPostionControll.turn = true;
            mypath.path[1].position = transform.right * 0.3f + new Vector3(myUserPostionControll.currectPostion.x, myUserPostionControll.currectPostion.y+2.5f, myUserPostionControll.currectPostion.z);
            
            myanim.SetTrigger("N2");
	        first = false;
	    }
	    if (!isturnning)
	    {
            if (Input.GetKeyDown(KeyCode.Q) || isQ)
            {
                isturnning = true;
                mypath.complete = false;
                myUserPostionControll.turn = true;
                mypath.path[1].position = transform.right * 0.3f + new Vector3(myUserPostionControll.currectPostion.x, myUserPostionControll.currectPostion.y+2.5f, myUserPostionControll.currectPostion.z);

                myanim.SetTrigger("N2");
            }
            if (Input.GetKeyDown(KeyCode.E) || isE)
            {
                isturnning = true;
                mypath.complete = false;
                myUserPostionControll.turn = true;
                mypath.path[1].position = -transform.right * 0.3f + new Vector3(myUserPostionControll.currectPostion.x, myUserPostionControll.currectPostion.y+2.5f, myUserPostionControll.currectPostion.z);

                myanim.SetTrigger("N1");
            }
	    }
	}

    public void RotateComplete()
    {
        mypath.path[0] = transform;
        mypath.self.transform.rotation = transform.rotation;
        myanim.SetTrigger("Complete");
        if (Math.Abs(0 - transform.forward.x) > 0.01)
        {
            myUserPostionControll.FixedPostion = myUserPostionControll.currectPostion.x;
        }
        if (Math.Abs(0 - transform.forward.z) > 0.01)
        {
            myUserPostionControll.FixedPostion = myUserPostionControll.currectPostion.z;
        }
        mypath.complete = true;
        myUserPostionControll.turn = false;
        isturnning = false;
        isQ = false;
        isE = false;

    }

    //easytouch
    void OnEnable()
    {
        EasyTouch.On_SwipeStart += On_SwipeStart;
        EasyTouch.On_Swipe += On_Swipe;
        EasyTouch.On_SwipeEnd += On_SwipeEnd;
    }

    void OnDisable()
    {
        UnsubscribeEvent();

    }

    void OnDestroy()
    {
        UnsubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        EasyTouch.On_SwipeStart -= On_SwipeStart;
        EasyTouch.On_Swipe -= On_Swipe;
        EasyTouch.On_SwipeEnd -= On_SwipeEnd;
    }

    // At the swipe beginning 
    private void On_SwipeStart(Gesture gesture)
    {
    }

    // During the swipe
    private void On_Swipe(Gesture gesture)
    {
    }

    // At the swipe end 
    private void On_SwipeEnd(Gesture gesture)
    {
        // Get the swipe angle
        if (gesture.startPosition.x < Screen.width / 2 && gesture.position.x < Screen.width / 2 && gesture.startPosition.y > Screen.height / 3 && gesture.position.y > Screen.height / 3 && gesture.swipeLength > 50)
        {
            if (gesture.swipe == EasyTouch.SwipeType.Left)
            {
                isQ = true;
            }
            if (gesture.swipe == EasyTouch.SwipeType.Right)
            {
                isE = true;
            }
        }
    }
}
