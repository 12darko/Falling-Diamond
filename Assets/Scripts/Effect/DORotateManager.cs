using System;
using DG.Tweening;
using UnityEngine;

namespace Effect
{
    public class DORotateManager : MonoBehaviour
    {
        private void Start()
        {
            transform.DORotate(new Vector3(0f, 360f, 0f), 4f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart)
                .SetRelative().SetEase(Ease.Linear);
        }

       

       
    }
}