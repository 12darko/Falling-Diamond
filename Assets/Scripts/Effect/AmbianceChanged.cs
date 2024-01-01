using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AmbianceChanged : MonoBehaviour
{
    private Material mat;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        var gameCam = FindObjectOfType<Camera>();

        ColorUtility.TryParseHtmlString("#4D0716", out Color color);
         gameCam.DOColor(color, 2);
    }
}
