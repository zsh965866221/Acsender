using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UseTime : MonoBehaviour
{
    public Text myText;
    Camera mainCamera;
    MyCamera camera;
    public static double gameTime;
    // Use this for initialization
    void Start()
    {
        myText = GetComponent<Text>();
        mainCamera = Camera.main;
        camera = mainCamera.GetComponent<MyCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = camera.GetComponent<MyCamera>().endTime - camera.GetComponent<MyCamera>().startTime;
        myText.text = string.Format("{0:F}", gameTime) + "秒";
    }
}
