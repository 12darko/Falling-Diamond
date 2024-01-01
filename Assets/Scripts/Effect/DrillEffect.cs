using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DrillEffect : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool clicked;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
        }
    }

    void FixedUpdate()
    {
        if (clicked)
        {
            SlowRotation();
        }
        else
        {
            FastRotation();
        }
        
        
    }

    private void FastRotation()
    {
        speed = 105;
        transform.Rotate(new Vector3(0, speed * Time.deltaTime));
    }

    private void SlowRotation()
    {
        speed = 65;
        transform.Rotate(new Vector3(0, speed* Time.deltaTime));
    }
}
