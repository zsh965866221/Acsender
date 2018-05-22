using UnityEngine;
using System.Collections;

public class RetainObject : MonoBehaviour
{
    public static bool isClone = false;
    public GameObject MusicObj;
	// Use this for initialization
	void Start () {
	    if (!isClone)
	    {
	        MusicObj = Instantiate(MusicObj) as GameObject;
            DontDestroyOnLoad(MusicObj);
	        isClone = true;
	    }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
