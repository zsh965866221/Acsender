using System;
using UnityEngine;
using System.Collections;

public class DirectCamera : MonoBehaviour
{
    public GameObject mCamera;
    public float Radius=5.0f;
    public Transform target;
    public float distance = 0;
    private float angle;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	    

	}

    void FixedUpdate()
    {
        angle = mCamera.transform.rotation.eulerAngles.y/180*Mathf.PI;
        transform.localPosition = new Vector3(Radius*Mathf.Sin(angle), distance,Radius * Mathf.Cos(angle));
        transform.LookAt(target);
    }
}
