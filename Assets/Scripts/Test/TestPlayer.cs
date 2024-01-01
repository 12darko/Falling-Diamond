using System;
using UnityEngine;

namespace Test
{
    public class TestPlayer : MonoBehaviour
    {
        private float _speed = 0.005f;

        private void Update()
        {
            transform.Translate( new Vector3(Input.GetAxis("Horizontal") * _speed, Input.GetAxis("Vertical") *_speed,0));
        }
    }
}