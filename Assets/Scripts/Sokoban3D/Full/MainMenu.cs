using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnedSokoban {}

public class MainMenu : MonoBehaviour
{
    private Sound_Handler _sound;

    void Awake() {
        _sound = Sound_Handler.instance;
        _sound.playsound(1);
    }

    public void PlayGame() {
        SceneManager.LoadScene("Level-1");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ContinueGame() {
        SceneManager.LoadScene("Level-1");
    }
}
