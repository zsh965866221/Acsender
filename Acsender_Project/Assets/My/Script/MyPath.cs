using UnityEngine;
using System.Collections;

public class MyPath : MonoBehaviour
{
    public Transform[] path;
    public float percentage;
    public float angle;

    public GameObject self;

    private Animator myanim;
    public bool complete = true;
	// Use this for initialization
	void Start ()
	{
	    myanim = GetComponent<Animator>();
        self=new GameObject("SelfRotate");
	    self.transform.rotation = transform.rotation;
	    GameObject g = GameObject.Find("MyCharacter");
	    path[0].position = g.transform.position + new Vector3(0, 2.5f, 0);
        path[1].position = g.transform.position + new Vector3(0, 2.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        iTween.PutOnPath(gameObject,path,percentage);
	    if (!complete)
	    {
            transform.rotation = Quaternion.Euler(self.transform.eulerAngles + new Vector3(0, angle, 0));
	    }
	}
}
