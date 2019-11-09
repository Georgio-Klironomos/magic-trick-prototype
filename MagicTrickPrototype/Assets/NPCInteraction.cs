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
        interactions.Add("hi2");
        interactions.Add("hello3");
        interactions.Add("heck off4");
        interactions.Add("nice to meet you0");
        interactions.Add("wow rude2");
        interactions.Add("sorry7");
        interactions.Add("I'm just a rude dude8");
        interactions.Add("apology not accepted0");
        interactions.Add("ök boomer0");
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
            for(int i = 1; i <= numOptions; i++)
            {
                text.text += "\n" + i + ". " + interactions[level + i].Substring(0, interactions[level + i].Length - 1);
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

            /*if(Input.GetKeyDown(KeyCode.Alpha1) && numOptions >= 1)
            {
                level = int.Parse(interactions[level + 1].Substring(interactions[level + 1].Length - 1, interactions[level + 1].Length));
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && numOptions >= 2)
            {
                level = int.Parse(interactions[level + 2].Substring(interactions[level + 2].Length - 1, interactions[level + 2].Length));
            }*/
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
        }
    }
}
