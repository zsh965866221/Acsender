using UnityEngine;
using System.Collections;

public class Replay : MonoBehaviour
{
    public static int LevelNumber;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReplayThisLevel()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        Application.LoadLevel(LevelNumber);
    }
}
