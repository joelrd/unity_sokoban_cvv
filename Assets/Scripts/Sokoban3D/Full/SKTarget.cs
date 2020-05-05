using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnedSokoban {}

public class SKTarget : SKTargetLight
{
    // Start is called before the first frame update
    void Start()
    {
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

    }
}
