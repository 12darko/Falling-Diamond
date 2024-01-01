using System;
using System.Collections;
using System.Collections.Generic;
using Spawner;
using UnityEngine;

public class CheckerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
           ObjectSpawnerData.Instance.Level++;
        }
    }
}
