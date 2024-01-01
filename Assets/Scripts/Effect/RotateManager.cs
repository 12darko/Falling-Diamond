using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class RotateManager : MonoBehaviour
{

    [SerializeField] private float fastSpeed;
    [SerializeField] private float slowSpeed;
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
            FastRotation();
        }
        else
        {
            SlowRotation();
        }
        
    }

    private void FastRotation()
    {
        transform.Rotate(new Vector3(0, fastSpeed * Time.deltaTime));
    }

    private void SlowRotation()
    {
 
         transform.Rotate(new Vector3(0, slowSpeed* Time.deltaTime));
    }
    
    /*
     *
     *    transform.DORotate(new Vector3(0f, 360f, 0f), 0.2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart)
            .SetRelative().SetEase(Ease.Linear);
            
            
                    Quaternion target = transform.rotation * Quaternion.AngleAxis(0, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, fastSpeed);
     */
}