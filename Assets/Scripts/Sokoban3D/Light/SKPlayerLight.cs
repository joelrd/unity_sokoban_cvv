using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban { }

public class SKPlayerLight : MonoBehaviour
{
    public float stepDistance = 1f;
    private Vector3 _direction;
    public bool _isReadyToMove;
    private RaycastHit _hit;
    private SKBoxLight _box;

    // Start is called before the first frame update
    void Start()
    {
        _isReadyToMove = true;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MoveChar(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MoveChar(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            MoveChar(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            MoveChar(Vector3.forward);
        }
    }

    public virtual void MoveChar(Vector3 direction) {
        if(!DetectObstruction(direction) && _isReadyToMove) {
            StartCoroutine(TimedMove(direction));
        }
    }

    public virtual IEnumerator TimedMove( Vector3 direction ) {
        _isReadyToMove = false;
        this.transform.Translate(direction);
        yield return new WaitForSeconds(0.1f);
        _isReadyToMove = true;
    }

    public virtual bool DetectObstruction(Vector3 direction) {
        if ( Physics.Raycast(transform.position, transform.TransformDirection(direction),out _hit, stepDistance)) {
            if(_hit.collider.gameObject.tag.Equals("Box")) {
                _box = _hit.collider.gameObject.GetComponent<SKBoxLight>();
                if(_box.MoveBox(direction, stepDistance)) {
                    return false;
                } else {
                    return true;
                }
            }
            return true;
        } else {
            return false;
        }
    }
}
