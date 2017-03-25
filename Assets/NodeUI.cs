
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour {
    public GameObject ui;
    private node target;
    public void SetTarget(node _target)
    {
        this.target = _target;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

	}

