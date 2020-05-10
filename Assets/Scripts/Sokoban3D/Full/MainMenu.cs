using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnedSokoban {}

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioSource[] allAudioSources;
    private string _level;

    void Awake() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach(AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
        if(SKGameControl.instance != null){
            Destroy(SKGameControl.instance);
        }
        audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
    }

    public void PlayGame() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level-1");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ContinueGame() {
        _level = PlayerPrefs.GetString("Level");
        if (string.IsNullOrEmpty(_level)) {
            _level = "Level-1";
        }
        SceneManager.LoadScene(_level);
    }
}
