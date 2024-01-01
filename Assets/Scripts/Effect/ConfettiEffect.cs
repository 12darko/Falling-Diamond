using System;
using UnityEngine;

namespace Effect
{
    public class ConfettiEffect : MonoBehaviour
    {
        [SerializeField] private GameObject confettiEffect;

        public void ActiveConfetti()
        {
            confettiEffect.SetActive(true);
        }
    }
}