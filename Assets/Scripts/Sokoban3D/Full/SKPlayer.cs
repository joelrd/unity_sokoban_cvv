using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban {}

public class SKPlayer : SKPlayerLight
{
    private SKLevel _level;
    private SKSmoothFollow _smoothFollow;
    // Start is called before the first frame update
    void Start()
    {
        _level = SKGameControl.instance.levelmanager;
        _isReadyToMove = true;
        this.gameObject.transform.parent.name = "Ground";
        this.gameObject.name = "Player";
        this.gameObject.transform.parent = null;
        _smoothFollow = Camera.main.GetComponent<SKSmoothFollow>();
        _smoothFollow.target = this.gameObject.transform;
    }

    // Update is called once per frame
    public override void Update()
    {
        if( _level.GameStarted( ) && !_level.GameDone( ) ) {
            base.Update();
        }
    }

    public void SetLevelController(SKLevel level) {
        _level = level;
    }

    public override void MoveChar ( Vector3 direction ) {
        if ( !DetectObstruction( direction ) && _isReadyToMove ) {
            StartCoroutine(TimedMove(direction));
            if( SKGameControl.instance != null ) {
                SKGameControl.instance.AddMove ( );
            }
        }
    }
}
