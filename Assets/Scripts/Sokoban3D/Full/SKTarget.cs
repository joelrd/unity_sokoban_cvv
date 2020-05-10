using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban {}

public class SKTarget : SKTargetLight
{
    public AudioSource audioSource;
    private bool _hasPlayed;
    // Start is called before the first frame update
    void Start()
    {
        _hasPlayed = false;
        audioSource = GetComponent<AudioSource>();
        targetRenderer = this.gameObject.GetComponent<Renderer>();
        targetRenderer.material.color = deactivatedColor;
        _status = false;
        this.gameObject.transform.parent.name = "Ground";
        this.gameObject.name = "Target";
        this.gameObject.transform.parent = null;
        SKGameControl.instance.RegisterTarget(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (_status && !_hasPlayed && !audioSource.isPlaying) {
            audioSource.Play();
            _hasPlayed = true;
        }
        if(!_status) {
            _hasPlayed = false;
        }
    }
}
