using System;
using UnityEngine;
using System.Collections;

public class LoacLevel : MonoBehaviour
{
    public int levelNumber;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        Application.LoadLevel(levelNumber);
    }

    public void ExitEscape(GameObject g)
    {
        Destroy(g);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
