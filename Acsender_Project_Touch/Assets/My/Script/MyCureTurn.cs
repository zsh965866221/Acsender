using UnityEngine;
using System.Collections;
using System.ComponentModel;
using UnityEngine.UI;

public class MyCureTurn : MonoBehaviour
{
    public Material defaultMat;
    public Material turnMat;
    public LayerMask cureCheckMask;
    public ArrayList CureList;
    private MyUserPostionControll userPostionControll;

    public Vector3 TurnZeroPoint;

    public GameObject myText;
    private Text mytext;

    private bool isJ = false;
    private bool isK = false;

    private bool isLeft = false;
    private bool isRight = false;
    private bool isUp = false;
    private bool isDown = false;
	// Use this for initialization
	void Start () {
        CureList=new ArrayList();
	    userPostionControll = GetComponent<MyUserPostionControll>();
        TurnZeroPoint=new Vector3();
	    if (myText != null)
	    {
            mytext = myText.GetComponent<Text>();
	    }
        CureList.Clear();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (mytext != null)
	    {
            mytext.text = CureList.Count.ToString();
	    }

        Vector3 myposition = userPostionControll.currectPostion;
        Ray ray = new Ray(myposition + Vector3.up * .1f, -Vector3.up * 1.2f);
        Debug.DrawRay(myposition + Vector3.up * .1f, -Vector3.up * 1.2f, Color.black);
        RaycastHit hit;
        Physics.Raycast(myposition + Vector3.up * .1f, -Vector3.up, out hit, 20f, cureCheckMask);
        GameObject o = hit.collider.gameObject;
	    TurnZeroPoint =
	        new Vector3(userPostionControll.currectPostion.x, o.transform.position.y, userPostionControll.currectPostion.z) +
	        new Vector3(0, 1, 0);
        if (Input.GetKeyDown(KeyCode.J) || isJ)
	    {
	        bool exist = false;
	        foreach (GameObject g in CureList)
	        {
	            if (g == o)
	            {
	                exist = true;
	            }
	        }
	        if (!exist&&o.tag!="Plane")
	        {
	            CureList.Add(o);
	        }
	        foreach (GameObject g in CureList)
	        {
	            g.GetComponent<Renderer>().material = turnMat;
	            g.transform.localScale =new Vector3(0.98f,0.98f,0.98f);
	        }
            isJ = false;
	    }
        if (Input.GetKeyDown(KeyCode.K) || isK)
	    {
	        if (CureList.Count != 0)
	        {
	            GameObject g = CureList[CureList.Count - 1]as GameObject;
	            g.GetComponent<Renderer>().material = defaultMat;
                g.transform.localScale = new Vector3(0.96f, 0.96f, 0.96f);
	            CureList.RemoveAt(CureList.Count-1);
	        }
            isK = false;
	    }

        //按照y轴旋转
        if (Input.GetKeyDown(KeyCode.LeftArrow) || isLeft)
	    {
	        foreach (GameObject g in CureList)
	        {
	            Vector3 p = new Vector3(Mathf.RoundToInt(TurnZeroPoint.x - (TurnZeroPoint.z - g.transform.position.z)),
	                Mathf.RoundToInt(g.transform.position.y), Mathf.RoundToInt(TurnZeroPoint.z + (TurnZeroPoint.x - g.transform.position.x)));
	            g.transform.position = p;
	        }
            isLeft = false;
	    }
        if (Input.GetKeyDown(KeyCode.RightArrow) || isRight)
        {
            foreach (GameObject g in CureList)
            {
                Vector3 p = new Vector3(Mathf.RoundToInt(TurnZeroPoint.x + (TurnZeroPoint.z - g.transform.position.z)),
                    Mathf.RoundToInt(g.transform.position.y), Mathf.RoundToInt(TurnZeroPoint.z - (TurnZeroPoint.x - g.transform.position.x)));
                g.transform.position = p;
            }
            isRight = false;
        }
        //按照摄像头水平为轴旋转
        Transform tCamera = Camera.main.transform;
        if (Input.GetKeyDown(KeyCode.UpArrow) || isUp)
	    {
            if (Mathf.Abs(0 - tCamera.forward.z) > 0.001)
            {
                foreach (GameObject g in CureList)
                {
                    Vector3 p = new Vector3(Mathf.RoundToInt(g.transform.position.x),
                        Mathf.RoundToInt(TurnZeroPoint.y + (TurnZeroPoint.z - g.transform.position.z)),
                        Mathf.RoundToInt(TurnZeroPoint.z - (TurnZeroPoint.y - g.transform.position.y)));
                    g.transform.position = p;
                }

            }
            if (Mathf.Abs(0 - tCamera.forward.x) > 0.001)
            {
                foreach (GameObject g in CureList)
                {
                    Vector3 p = new Vector3(Mathf.RoundToInt(TurnZeroPoint.x + (TurnZeroPoint.y - g.transform.position.y)),
                        Mathf.RoundToInt(TurnZeroPoint.y - (TurnZeroPoint.x - g.transform.position.x)), Mathf.RoundToInt(g.transform.position.z));
                    g.transform.position = p;
                }
            }
            isUp = false;
	    }
        if (Input.GetKeyDown(KeyCode.DownArrow) || isDown)
        {
            if (Mathf.Abs(0 - tCamera.forward.z) > 0.001)
            {
                foreach (GameObject g in CureList)
                {
                    Vector3 p = new Vector3(Mathf.RoundToInt(g.transform.position.x),
                        Mathf.RoundToInt(TurnZeroPoint.y - (TurnZeroPoint.z - g.transform.position.z)),
                        Mathf.RoundToInt(TurnZeroPoint.z + (TurnZeroPoint.y - g.transform.position.y)));
                    g.transform.position = p;
                }

            }
            if (Mathf.Abs(0 - tCamera.forward.x) > 0.001)
            {
                foreach (GameObject g in CureList)
                {
                    Vector3 p = new Vector3(Mathf.RoundToInt(TurnZeroPoint.x - (TurnZeroPoint.y - g.transform.position.y)),
                        Mathf.RoundToInt(TurnZeroPoint.y + (TurnZeroPoint.x - g.transform.position.x)), Mathf.RoundToInt(g.transform.position.z));
                    g.transform.position = p;
                }
            }
            isDown = false;
        }
	}

    void OnEnable()
    {
        EasyButton.On_ButtonDown += On_ButtonDown;
        EasyButton.On_ButtonUp += On_ButtonUp;

        EasyTouch.On_SwipeStart += On_SwipeStart;
        EasyTouch.On_Swipe += On_Swipe;
        EasyTouch.On_SwipeEnd += On_SwipeEnd;
    }

    void OnDisable()
    {
        EasyButton.On_ButtonDown -= On_ButtonDown;
        EasyButton.On_ButtonUp -= On_ButtonUp;

        UnsubscribeEvent();
    }

    void OnDestroy()
    {
        EasyButton.On_ButtonDown -= On_ButtonDown;
        EasyButton.On_ButtonUp -= On_ButtonUp;
    }
    void UnsubscribeEvent()
    {
        EasyTouch.On_SwipeStart -= On_SwipeStart;
        EasyTouch.On_Swipe -= On_Swipe;
        EasyTouch.On_SwipeEnd -= On_SwipeEnd;
    }
    void On_ButtonDown(string buttonName)
    {
        if (buttonName == "CubePick")
        {
            isJ = true;
        }
        if (buttonName == "CubeCass")
        {
            isK = true;
        }
    }

    void On_ButtonUp(string buttonName)
    {
        if (buttonName == "Exit")
        {

        }
    }

    private void On_SwipeStart(Gesture gesture)
    {
    }

    // During the swipe
    private void On_Swipe(Gesture gesture)
    {
    }

    // At the swipe end 
    private void On_SwipeEnd(Gesture gesture)
    {
        // Get the swipe angle
        if (gesture.startPosition.x > Screen.width / 2 && gesture.position.x > Screen.width / 2 && gesture.startPosition.y > Screen.height / 3 && gesture.position.y > Screen.height / 3 && gesture.swipeLength > 50)
        {
            if (gesture.swipe == EasyTouch.SwipeType.Left)
            {
                isLeft = true;
            }
            if (gesture.swipe == EasyTouch.SwipeType.Right)
            {
                isRight = true;
            }
            if (gesture.swipe == EasyTouch.SwipeType.Up)
            {
                isUp = true;
            }
            if (gesture.swipe == EasyTouch.SwipeType.Down)
            {
                isDown = true;
            }
        }
    }
}
