using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnedSokoban {}

public class Pause : MonoBehaviour
{
    public bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = togglePause();
        }
    }

    void OnGUI()
     {
         if(paused)
         {
             var rect = new Rect((Screen.width)/2, (Screen.height)/2, 200, 50);
             if(GUI.Button(rect, "Exit")) {
                paused = togglePause();
                SceneManager.LoadScene("Main");

             }
         }
     }

    bool togglePause() {
         if(Time.timeScale == 0f)
         {
             Time.timeScale = 1f;
             return(false);
         }
         else
         {
             Time.timeScale = 0f;
             return(true);
         }
     }
}
