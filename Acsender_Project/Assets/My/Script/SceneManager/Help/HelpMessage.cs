using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpMessage : MonoBehaviour
{

    public Text helpMessage;
    // Use this for initialization
    void Start()
    {
        helpMessage = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setMessage(string message)
    {
        helpMessage.text = message;
    }
}
