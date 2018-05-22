using UnityEngine;
using System.Collections;

public class MyLSTag : MonoBehaviour {
    public GameObject mcamera;
    private Vector3 cameraVector;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        cameraVector = mcamera.transform.rotation.eulerAngles;
	    transform.rotation = mcamera.transform.rotation;
	}
}
