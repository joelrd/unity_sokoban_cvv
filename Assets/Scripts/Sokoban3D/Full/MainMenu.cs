using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnedSokoban {}

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioSource[] allAudioSources;

    void Awake() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach(AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
        audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
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
