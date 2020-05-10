using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban {}

public class SKBox : SKBoxLight
{
    private SKLevel _level;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        transform.hasChanged = false;
        audioSource = GetComponent<AudioSource>();
        _level = SKGameControl.instance.levelmanager;
        this.gameObject.transform.parent.name = "Ground";
        this.gameObject.name = "Box";
        this.gameObject.transform.parent = null;
    }

    void Update() {
        if (transform != null && transform.hasChanged && !audioSource.isPlaying) {
            audioSource.Play();
            transform.hasChanged = false;
        }
    }

    new public bool MoveBox( Vector3 direction, float stepDistance ) {
        if ( !_level.GameDone( ) ) {
            return base.MoveBox(direction, stepDistance);
        } else {
            return false;
        }
    }

    public void SetLevelController(SKLevel level) { _level = level; }
}
