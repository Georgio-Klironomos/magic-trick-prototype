using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickFlip : MonoBehaviour
{
    public Vector3 rotationDirection;
    public float smoothTime;
    public bool active = false;
    private float convertedTime = 200;
    private float smooth;
    private float originalX;

    // Use this for initialization
    void Start()
    {
        originalX = transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Debug.Log("kickflip");
            smooth = Time.deltaTime * smoothTime * convertedTime;
            transform.Rotate(rotationDirection * smooth);
            if(transform.rotation.x < -74 && transform.rotation.x > -87)
            {
                active = false;
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }
        }
    }
}

