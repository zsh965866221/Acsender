using UnityEngine;
using System.Collections;

public class EscapeControl : MonoBehaviour
{
    private bool isescape;
	// Use this for initialization
	void Start ()
	{
	    isescape = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.timeScale == 1)
	    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevelAdditive(4);
                Time.timeScale = 0;
            }
	    }
	}
}
