using System;
using UnityEngine;
using System.Collections;

public class MyCameraFollow : MonoBehaviour
{
    public Transform character;
    public float smoothTime = 0.01f;
    private Vector3 cameraVelocity = Vector3.zero;
    public bool turn=false;
    public Vector3 offset=new Vector3(0,2.5f,0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //x轴朝向
	    if (!turn)
	    {
            if (Math.Abs(0 - transform.forward.x) > 0.001)
            {
                Vector3 tempPostion = character.position + offset;
                tempPostion.x = transform.position.x;
                transform.position = Vector3.SmoothDamp(transform.position, tempPostion, ref cameraVelocity, smoothTime);
            }
            //z轴朝向
            if (Math.Abs(0 - transform.forward.z) > 0.001)
            {
                Vector3 tempPostion = character.position + offset;
                tempPostion.z = transform.position.z;
                transform.position = Vector3.SmoothDamp(transform.position, tempPostion, ref cameraVelocity, smoothTime);
            }
	    }
	}
}
