﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnedSokoban {}

public class SKGameControl : MonoBehaviour
{
    public static SKGameControl instance;
    private int _characterMoves;
    private float _activePlayTime;
    private List<SKTarget> targets;
    private SKLevel _level;
    public AudioSource audioSource;

    void Awake ( ) {
        if(SKGameControl.instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            targets = new List<SKTarget>();
            audioSource = GetComponent<AudioSource>();
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        }
        else {
            Destroy(this.gameObject);
        }
    }

    public int characterMoves {
        get { return _characterMoves; }
        set { _characterMoves = value; }
    }
    public float activePlayTime {
        get { return _activePlayTime; }
        set { _activePlayTime = value; }
    }

    public SKLevel levelmanager {
        get { return _level; }
        set { _level = value; }
    }

    public void LoadScene ( string value ) {
        _level = null;
        ResetTargets();
        SceneManager.LoadScene( value );
    }
    public void RestartGame ( ) {
         _level = null;
         ResetTargets();
         _characterMoves = 0;
         _activePlayTime = 0;
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }

     public void RegisterTarget ( SKTarget newTarget ) {
         targets.Add( newTarget );
    }

    public void ResetTargets() {
        targets.Clear();
    }
    public SKTarget[] GetTargets ( ) {
        return targets.ToArray ( );
    }

    public void AddMove() {
        _characterMoves++;
    }

    public void AddPlayTime(float value) {
        _activePlayTime += value;
    }

    public void OnApplicationQuit ( ) {

    }
}
