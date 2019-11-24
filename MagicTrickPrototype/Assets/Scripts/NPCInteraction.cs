using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public bool inPlayerRange = false;
    List<string> interactions;
    public int level;
    private int MAX_OPTIONS;
    public Text text;
    public RawImage NPCBox;
    public Text playerText;
    public RawImage playerBox;
    private KeyCode[] codes = {
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3
        };
    public int numOptions;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        interactions = new List<string>();
        interactions.Add("hi2");                     //0
        interactions.Add("hello3");                  //1
        interactions.Add("heck off4");               //2
        interactions.Add("nice to meet you0");       //3
        interactions.Add("wow rude2");               //4
        interactions.Add("sorry7");                  //5
        interactions.Add("I'm just a rude dude8");   //6
        interactions.Add("apology not accepted0");   //7
        interactions.Add("ök boomer0");              //8
        MAX_OPTIONS = 3;
    }

    // Update is called once per frame
    void Update()
    {
        numOptions = 0;
        if (inPlayerRange && level < interactions.Capacity)
        {
            numOptions = int.Parse(interactions[level].Substring(interactions[level].Length - 1));
            text.text = interactions[level].Substring(0, interactions[level].Length - 1);
            playerText.text = "";
            for(int i = 1; i <= numOptions; i++)
            {
                playerText.text += i + ". " + interactions[level + i].Substring(0, interactions[level + i].Length - 1) + "\n";
            }

            if (numOptions == 0)
            {
                level = interactions.Capacity;
            }
            for(int j = 0; j < numOptions; j++)
            {
                if (Input.GetKeyDown(codes[j]))
                {
                    level = int.Parse(interactions[level + j + 1].Substring(interactions[level + j + 1].Length - 1));
                }
            }
        }
        if(text.text == "")
        {
            NPCBox.enabled = false;
        }
        else
        {
            NPCBox.enabled = true;
        }
        if (playerText.text == "")
        {
            playerBox.enabled = false;
        }
        else
        {
            playerBox.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inPlayerRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inPlayerRange = false;
            text.text = "";
            playerText.text = "";
        }
    }
}
