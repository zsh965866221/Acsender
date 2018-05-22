using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour
{
    public double startTime;
    public double endTime;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        Replay.LevelNumber = Application.loadedLevel;
    }

    // Update is called once per frame
    void Update()
    {
        endTime = Time.time;
    }
}