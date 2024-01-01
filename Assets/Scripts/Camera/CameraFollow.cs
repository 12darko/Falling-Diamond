using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     [SerializeField] private Vector3 cameraPos;
     [SerializeField] private Transform player;
     [SerializeField] private Transform effect;

     private float _cameraOffset;
    
     private void Update()
     {
          if (effect == null)
          {
              effect = GameObject.Find("Changed(Clone)").GetComponent<Transform>();
          }

          if (transform.position.y > player.position.y && transform.position.y > effect.position.y + _cameraOffset)
          {
              cameraPos = new Vector3(transform.position.x, player.position.y, transform.position.z);
              transform.position = new Vector3(transform.position.x, cameraPos.y, -5);
          }
     }
}
