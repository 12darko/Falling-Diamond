using System;
using UnityEngine;

namespace Effect
{
    public class NormalRotateManager : MonoBehaviour
    {
        [SerializeField] private float fastSpeed; 
        private void FixedUpdate()
        {
            FastRotation();
        }

        private void FastRotation()
        {
            transform.Rotate(new Vector3(0, fastSpeed * Time.deltaTime));
            
        }
    }
}