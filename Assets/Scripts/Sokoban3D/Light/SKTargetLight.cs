using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban { }

public class SKTargetLight : MonoBehaviour
{
    public Color activatedColor = Color.green;
    public Color deactivatedColor = Color.yellow;
    public bool _status;
    public Renderer targetRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        targetRenderer = this.gameObject.GetComponent<Renderer>();
        targetRenderer.material.color = deactivatedColor;
        _status = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetStatus ( ) {
        return _status;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Box")) {
            targetRenderer.material.color = activatedColor;
            _status = true;
        }
    }

    private void OnTriggerExit ( Collider other ) {
        if ( other.gameObject.tag.Equals( "Box" ) ) {
            targetRenderer.material.color = deactivatedColor;
            _status = false;
        }
    }
}
