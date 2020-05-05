using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban {}

public class SKBox : SKBoxLight
{
    private SKLevel _level;
    // Start is called before the first frame update
    void Start()
    {
        _level = SKGameControl.instance.levelmanager;
        this.gameObject.transform.parent.name = "Ground";
        this.gameObject.name = "Box";
        this.gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

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
