using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalUseTime : MonoBehaviour
{
    public Text myText;
    public UseTime useTime;
    // Use this for initialization
    void Start()
    {
        myText = GetComponent<Text>();
        //useTime = new UseTime();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "任务完成\n" + "耗时：" + string.Format("{0:F}", UseTime.gameTime) + "秒";
    }
}
