using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    LineRenderer _lineRenderer;
    Ebhi _ebhi;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _ebhi = FindObjectOfType<Ebhi>();
    }

    void Update()
    {
        if (_ebhi.IsDragging)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(1, _ebhi.transform.position);
        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }
}
