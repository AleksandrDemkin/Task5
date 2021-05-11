using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileInUpdate : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        while (_meshRenderer.material.color != Color.green)
        {
            Debug.Log(_meshRenderer.material.color);
        }
    }
    
}
