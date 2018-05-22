using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    
	}
    void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position,new Vector3(2,2,2));       
    }
}
