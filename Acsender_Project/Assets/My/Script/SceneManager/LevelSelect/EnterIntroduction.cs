using UnityEngine;
using System.Collections;

public class EnterIntroduction : MonoBehaviour {
    public GameObject IntroductionPanel;
	// Use this for initialization
	void Start () {
        IntroductionPanel.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Time.timeScale = 0;
            IntroductionPanel.SetActive(true);
        }
    }
}
