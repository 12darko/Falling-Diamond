using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
   [SerializeField] private MeshRenderer mr;
   [SerializeField] private Material mat;
    private void Update()
    {
        mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y -= Time.deltaTime / 5f;
        mat.mainTextureOffset = offset;
    }
}
