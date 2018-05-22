using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class help : MonoBehaviour 
{

    public GameObject character;
    public Vector3 currentPostion;
    MyCureTurn mycureTurn;
    Camera mainCamera;

    bool step1, step2, step3;
    public GameObject tip1, tip2, tip3;

    public HelpMessage helpMessage;

	// Use this for initialization
	void Start () 
    {
        step1 = step2 = step3 = false;
        mycureTurn = character.GetComponent<MyCureTurn>();
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentPostion = mycureTurn.TurnZeroPoint;
        if (step1 == false)
        {
            tip1.SetActive(true);
            tip2.SetActive(false);
            tip3.SetActive(false);
            
            helpMessage.setMessage("请移动到箭头所指位置");
            
            if (currentPostion.x == -1 && currentPostion.y == 1 &&
                currentPostion.z == 0)
            {
                step1 = true;
                tip1.SetActive(false);
            }

        }
        else
        {
            if (step2 == false)
            {
                helpMessage.setMessage( "请向右旋转" );
                if ((int)mainCamera.transform.forward.x == 0 && (int)mainCamera.transform.forward.y == 0
                    && (int)mainCamera.transform.forward.z == 1)
                {
                    step2 = true;
                }
            }
            else
            {
                if (step3 == false)
                {
                    tip2.SetActive(true);
                    helpMessage.setMessage("请移动到箭头所指位置");
                    if (currentPostion.x == 0 && currentPostion.y == 2 &&
                        currentPostion.z == 0)
                    {
                        step3 = true;
                        tip2.SetActive(false);
                    }
                }
                else
                {
                    tip3.SetActive(true);
                    helpMessage.setMessage("请跳跃撞击终点");
                    if (currentPostion.x == 0 && currentPostion.y == 3 &&
                        currentPostion.z == 0)
                    {
                        tip3.SetActive(false);
                    }

                }
            }
        }
	}
}
