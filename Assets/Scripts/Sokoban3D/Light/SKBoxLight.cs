using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban { }

public class SKBoxLight : MonoBehaviour
{
    private RaycastHit _hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool MoveBox(Vector3 direction, float stepDistance) {
        if (DetectObstruction(direction, stepDistance)) {
            return false;
        } else {
            this.gameObject.transform.Translate(direction);
            return true;
        }
    }

    private bool DetectObstruction( Vector3 direction, float stepDistance ) {
        if( Physics.Raycast(
            transform.position,
            transform.TransformDirection(direction),
            out _hit,
            stepDistance)
        ) {
            return true;
        }
        else {
            return false;
        }
    }
}
