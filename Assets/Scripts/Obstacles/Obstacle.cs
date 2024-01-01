using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Effect;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;


public class Obstacle : MonoBehaviour
{
    
    private Transform tr;
    private Vector3 defaultPos;
    private Quaternion defaultRot;
    private Rigidbody _rb;
    private MeshRenderer _meshRenderer;
    private Collider _collider;
    private ObstacleController _obstacleController;
    
    private void Awake()
    {
        tr = transform;
        _rb = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        _obstacleController = tr.parent.GetComponent<ObstacleController>();
        
        defaultPos = tr.position;
        defaultRot = tr.rotation;
    }
    
    public void Shatter()
    {
        _rb.isKinematic = false;
        _collider.enabled = false;

        var forcePoint = tr.parent.position;
        var parentXPos = tr.parent.position.x;
        var xPos = _meshRenderer.bounds.center.x;

        var subDir = (parentXPos - xPos < 0) ? Vector3.right : Vector3.left;

        var dir = (Vector3.up * 1.5f + subDir).normalized;

        var force = Random.Range(20, 35);
        var torque = Random.Range(110, 180);
        
        _rb.AddForceAtPosition(dir * force,forcePoint,ForceMode.Impulse);
        _rb.AddTorque(Vector3.left * torque);
        _rb.velocity = Vector3.down;
    }
    
    public void Join()
    {
        transform.DOJump(defaultPos, 3f, 5, 2f, false).SetEase(Ease.Linear).OnComplete(() =>
        {
            _rb.isKinematic = true;
            _collider.enabled = true;
        });
    }
    
    public void ShatterObject(Collision collision)
    {
          var parent = collision.collider.transform.parent;
            Debug.Log(parent.name);
            if (collision.collider.CompareTag("Black"))
            {
                transform.GetComponent<ObjectMove>().ObstaclesMove(collision);
               
            }
            else
            {
                parent.GetChild(0).gameObject.SetActive(false);
                parent.GetChild(1).gameObject.SetActive(true);
                transform.GetComponent<ObjectMove>().ObstaclesMove(collision);
            }
            _obstacleController.IsBreak = true;
    }
}