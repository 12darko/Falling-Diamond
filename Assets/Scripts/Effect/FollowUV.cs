using System;
using Player;
using Test;
using UnityEngine;

namespace Effect
{
    public class FollowUV : MonoBehaviour
    {
        [SerializeField] private MeshRenderer mr;
        [SerializeField,HideInInspector] private Material mat;
        [SerializeField] private GameObject player;

        [SerializeField] private float parallax = 2f;


  

        private void Update()
        {
            mat = mr.material;
            Vector2 offset = mat.mainTextureOffset;
            offset.y = player.transform.position.y/ transform.localScale.y / parallax;
            offset.x = player.transform.position.x/ transform.localScale.x / parallax;
            mat.mainTextureOffset = offset;
        }
    }
}