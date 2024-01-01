using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WindEffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.DOMoveY(25 * Time.fixedDeltaTime * 5, 0.5f, false).SetEase(Ease.Linear);
        }
    }
}
