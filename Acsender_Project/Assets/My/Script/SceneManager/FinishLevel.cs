using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour
{
    public int LevelNumber;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Application.LoadLevelAdditive(LevelNumber);
            Time.timeScale = 0;
            Destroy(gameObject,0.5f);
        }
    }
}
