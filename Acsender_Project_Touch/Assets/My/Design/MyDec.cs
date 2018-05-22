using UnityEngine;
using System.Collections;

public class MyDec : MonoBehaviour
{
    public float angle;
    public float sinangle;
    public float cosangle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    sinangle = Mathf.Sin(angle*Mathf.PI);
	    cosangle = Mathf.Cos(angle);

	}
}
