using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TargetPostion : MonoBehaviour {
    public GameObject target;
    Text mytext;
	// Use this for initialization
	void Start () {
        mytext = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (target == null)
	    {
	        mytext.text = "-,-,-";
	    }
	    else
	    {
            mytext.text = target.transform.position.x + "," + target.transform.position.y + "," + target.transform.position.z;
	    }
	
	}
}
