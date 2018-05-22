using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundStrength : MonoBehaviour
{
    public GameObject SoundPanel;
    private GameObject MusicObj;
    private AudioSource audioSource;
    private Slider slider;
    private bool isFirst = true;
//    private MyLSButtonControl myLsButtonControl;
	// Use this for initialization
	void Start ()
	{
        
//	    myLsButtonControl = MusicObj.GetComponent<MyLSButtonControl>();
        SoundPanel.SetActive(false);
	    
	    slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update ()
	{
//	    audioSource.volume = slider.value;        
	}

    public void ChangeSoundStrength()
    {
        if (isFirst)
        {
            MusicObj = GameObject.FindGameObjectWithTag("Music");
            audioSource = MusicObj.GetComponent<AudioSource>();
        }
        
        audioSource.volume = slider.value;
        isFirst = false;
    }
}
