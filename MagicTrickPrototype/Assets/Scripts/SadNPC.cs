using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SadNPC : MonoBehaviour
{
    public bool inPlayerRange = false;
    List<string> interactions;
    public int level;
    private int MAX_OPTIONS;
    public Text text;
    public RawImage NPCBox;
    public Text playerText;
    public RawImage playerBox;
    public bool problem;
    public CharacterController player;
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
        problem = true;
        interactions = new List<string>();
        interactions.Add("I'm sad. Can you do me a favor?2");    //0
        interactions.Add("Sure Thing!3");                        //1
        interactions.Add("What is it?3");                        //2
        interactions.Add("Can you do a magic trick for me?1");   //3
        interactions.Add("Of course!5");                         //4
        interactions.Add("Thank you! It'll cheer me up.0");      //5
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
            for (int i = 1; i <= numOptions; i++)
            {
                playerText.text += i + ". " + interactions[level + i].Substring(0, interactions[level + i].Length - 1) + "\n";
            }

            if (numOptions == 0)
            {
                level = interactions.Capacity;
            }
            for (int j = 0; j < numOptions; j++)
            {
                if (Input.GetKeyDown(codes[j]))
                {
                    level = int.Parse(interactions[level + j + 1].Substring(interactions[level + j + 1].Length - 1));
                }
            }
        }
        if(level >= 3 && inPlayerRange && !player.isGrounded && (Input.GetKeyDown("e") || Input.GetKeyDown("r")))
        {
            problem = false;

        }
        if (!problem)
        {
            text.text = "Thanks I'm happy now";
        }
        if (text.text == "")
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
