using UnityEngine;
using System.Collections;

public class MyUserPostionControll : MonoBehaviour {

    //my
    public float FixedPostion = 2;
    public bool turn = false;
    public Vector3 currectPostion;

    private Transform tCamera;
	// Use this for initialization
	void Start () {
        currectPostion=new Vector3();
        //
        tCamera = Camera.main.transform;

        currectPostion.x = Mathf.Round(transform.position.x);
        currectPostion.z = Mathf.Round(transform.position.z);
        if (!turn)
        {
            if (Mathf.Abs(0 - tCamera.forward.x) > 0.01)
            {
                FixedPostion = currectPostion.x;

            }
            if (Mathf.Abs(0 - tCamera.forward.z) > 0.01)
            {

                FixedPostion = currectPostion.z;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        //设定当前场景位置
	    currectPostion.y = transform.position.y;
	    currectPostion.x = Mathf.Round(transform.position.x);
	    currectPostion.z = Mathf.Round(transform.position.z);

        tCamera = Camera.main.transform;
        if (!turn)
        {
            if (Mathf.Abs(0 - tCamera.forward.x) > 0.001)
            {
                Vector3 currentPostiont = transform.position;
                currentPostiont.x = FixedPostion;
                transform.position = currentPostiont;
            }
            if (Mathf.Abs(0 - tCamera.forward.z) > 0.001)
            {
                Vector3 currentPostiont = transform.position;
                currentPostiont.z = FixedPostion;
                transform.position = currentPostiont;
            }
        }
	}
}
