using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentPostion : MonoBehaviour {
    public GameObject Character;
    Text text;
    Vector3 currentPostion;
    MyCureTurn mycureTurn;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        mycureTurn = Character.GetComponent<MyCureTurn>();
	}
	
	// Update is called once per frame
	void Update () {
        currentPostion = mycureTurn.TurnZeroPoint;
        text.text = currentPostion.x + "," + currentPostion.y + ","+currentPostion.z ;
	}
}
