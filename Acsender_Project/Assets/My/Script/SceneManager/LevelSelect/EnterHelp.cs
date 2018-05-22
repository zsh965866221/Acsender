using UnityEngine;
using System.Collections;

public class EnterHelp : MonoBehaviour {
    public GameObject character;
    public GameObject HelpPanel;
    MyCureTurn cureTurn;
	// Use this for initialization
	void Start () {
        cureTurn = character.GetComponent<MyCureTurn>();
        HelpPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        ArrayList curelist = cureTurn.CureList;
        foreach (GameObject o in curelist)
        {
            if (o == gameObject)
            {
                Time.timeScale = 0;
                HelpPanel.SetActive(true);
            }
        }
	}
}
