using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public bool inPlayerRange = false;
    List<string> interactions;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        interactions = new List<string>();
        interactions.Add("hi");
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlayerRange && Input.GetKeyDown("c") && level < interactions.Capacity)
        {
            Debug.Log(interactions[level].Substring(0, interactions[level].Length-1));
            //level = int.Parse(interactions[level].Substring(interactions[level].Length-1));
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
        }
    }
}
