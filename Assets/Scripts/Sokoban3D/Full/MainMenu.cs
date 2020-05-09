using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnedSokoban {}

public class MainMenu : MonoBehaviour
{
    private Sound_Handler _sound;

    void Awake() {
        this.PlaySound(1);
    }

    public void PlayGame() {
        this.PlaySound(2);
        SceneManager.LoadScene("Level-1");
    }

    public void QuitGame() {
        this.PlaySound(2);
        Application.Quit();
    }

    public void ContinueGame() {
        this.PlaySound(2);
        SceneManager.LoadScene("Level-1");
    }

    public void PlaySound(int index) {
        _sound = Sound_Handler.instance;
        _sound.playsound(index);
    }
}
