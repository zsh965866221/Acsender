using UnityEngine;
using System.Collections;

public class EnterGame : MonoBehaviour {
    public GameObject character;
    public int levelNumber;
    MyCureTurn cureTurn;
	// Use this for initialization
	void Start () {
        cureTurn = character.GetComponent<MyCureTurn>();
	
	}
	
	// Update is called once per frame
	void Update () {
        ArrayList curelist = cureTurn.CureList;
        foreach (GameObject o in curelist)
        {
            if (o == gameObject)
            {
                Application.LoadLevel(levelNumber);
            }
        }
	
	}
}
