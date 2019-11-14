using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    public string scene;
    public Color loadToColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, (2 * Screen.height) / 3, 100, 30), "Start")) {
                Initiate.Fade(scene, loadToColor, 0.5f);
            }
    }
}
