using System;
using UnityEngine;
using UnityEngine.Events;

namespace Effect
{
    public class MakeTransparent : MonoBehaviour
    {
        [SerializeField] private Material mat;
        [SerializeField] private Renderer rend;
        [SerializeField] private float alpha = 1f;
 

 
        #region Props

        public float Alpha
        {
            get => alpha;
            set => alpha = value;
        }

        #endregion

        private void Start()
        {
            mat = transform.GetComponent<Renderer>().materials[0];
        }

        private void Update()
        {
            ChangeAlpha(mat, alpha);
        }

        private void ChangeAlpha(Material mat,float alphaVal )
        {
         
            var oldColor = mat.color;
            var newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
            mat.SetColor("_Color", newColor);
        }
    }
}