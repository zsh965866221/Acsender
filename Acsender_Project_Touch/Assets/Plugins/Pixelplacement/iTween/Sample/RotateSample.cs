using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{	
	void Start(){
		iTween.RotateBy(gameObject, iTween.Hash("y", .25, "easeType", "easeInOutBack", "loopType", "None", "delay", .4,"Time",5f));
	}
}

