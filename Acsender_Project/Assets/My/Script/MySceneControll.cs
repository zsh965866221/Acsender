using UnityEngine;
using System.Collections;
using System.Linq;

public class MySceneControll : MonoBehaviour
{

    public bool change;
    public GameObject[] SceneList;
    public GameObject character;
    public Vector3[] originalPosition;

    private MyPath mypath;
    public bool SceneChanged ;

	// Use this for initialization
	void Start ()
	{
	    change = true;
        SceneChanged = true;
        character = GameObject.Find("MyCharacter");
        SceneList = GameObject.FindGameObjectsWithTag("MyScene");
        originalPosition = new Vector3[SceneList.Length];
        mypath = Camera.main.GetComponent<MyPath>();
        
        for (int i = 0; i < SceneList.Length; i++)
        {
            originalPosition[i] = SceneList[i].transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (SceneChanged == true && mypath.complete == true )
        {
            print( Camera.main.transform.forward);
            if (Mathf.Abs(Camera.main.transform.forward.x - 0) > 0.3)
            {
                for (int i = 0; i < SceneList.Length; i++)
                {
                    Vector3 point = new Vector3(Mathf.Round(character.transform.position.x), originalPosition[i].y, originalPosition[i].z);
                    SceneList[i].transform.position = point;
                    print(originalPosition[i] + " " + point);
                }
            }
            else if (Mathf.Abs(Camera.main.transform.forward.z - 0) > 0.3)
            {
                for (int i = 0; i < SceneList.Length; i++)
                {
                    Vector3 point = new Vector3(originalPosition[i].x, originalPosition[i].y, Mathf.Round(character.transform.position.z));
                    SceneList[i].transform.position = point;
                    print(originalPosition[i] + " " + point);
                }
            }
            SceneChanged = false;
        }


	    if (change)
	    {
	        change = false;
	    }
	}
}
