using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MyLSButtonControl : MonoBehaviour
{
    public GameObject MusicObj;
    public AudioSource audioSource;
    private bool ispausing=false;
    public GameObject[] pictures;
    private int pictureIndex=0;
    private int nextPictureIndex=1;
	// Use this for initialization
	void Start () {
        MusicObj = GameObject.FindGameObjectWithTag("Music");
	    audioSource = MusicObj.GetComponent<AudioSource>();
	    foreach (GameObject o in pictures)
	    {
	        o.SetActive(false);
	    }
        pictures[pictureIndex].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IntroductionHid(GameObject g)
    {
        g.SetActive(false);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void HelpHid(GameObject g)
    {
        g.SetActive(false);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void DisplaySoundPanel(GameObject g)
    {
        g.SetActive(true);
    }

    public void SoundPauseUnPause(GameObject g)
    {
        Text text = g.GetComponent<Text>();
        if (!ispausing)
        {
            audioSource.Pause();
            ispausing = true;
            text.text = "播放";
        }
        else
        {
            audioSource.UnPause();
            ispausing = false;
            text.text = "暂停";
        }
    }

    public void NextPicture()
    {
        if (pictureIndex <= pictures.Length-1)
        {
            if (pictureIndex == pictures.Length - 1)
            {
                nextPictureIndex = pictureIndex;
            }
            else
            {
                nextPictureIndex = pictureIndex+1;
            }
            pictures[pictureIndex].SetActive(false);
            pictures[nextPictureIndex].SetActive(true);
            if (pictureIndex != pictures.Length-1)
            {
                pictureIndex++;
            }
        }

    }
    public void PrePicture()
    {
        if (pictureIndex >= 0)
        {
            if (pictureIndex == 0)
            {
                nextPictureIndex = pictureIndex;
            }
            else
            {
                nextPictureIndex = pictureIndex - 1;
            }
            pictures[pictureIndex].SetActive(false);
            pictures[nextPictureIndex].SetActive(true);
            if (pictureIndex != 0)
            {
                pictureIndex--;
            }
        }

    }
}
