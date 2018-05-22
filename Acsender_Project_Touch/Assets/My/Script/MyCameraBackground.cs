using UnityEngine;
using System.Collections;

public class MyCameraBackground : MonoBehaviour {

	// Use this for initialization
    private Camera mainCamera;
    public float black=0;
	void Start ()
	{
	    mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{
        mainCamera.backgroundColor=new Color(black,black,black);
	}
}
