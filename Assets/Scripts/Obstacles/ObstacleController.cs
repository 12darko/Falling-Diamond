using System;
using System.Collections;
using System.Collections.Generic;
using Effect;
using Player;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
   [SerializeField]
   public Obstacle[] Obstacles = null;
   public bool IsBreak = false;
   private void Awake()
   {
      Obstacles = gameObject.GetComponentsInChildren<Obstacle>(); 
   }

 

   public void ShatterAllObstacles()
   {
      if (transform.parent!= null)
      {
         transform.parent = null;
      }
      foreach (var obstacle in Obstacles)
      {
         obstacle.Shatter();;
      }

      StartCoroutine(RemoveAllShatterParts());
      PlayerData.Instance.DestroyObjectCount++;
    
   }
   
   IEnumerator RemoveAllShatterParts()
   {
      yield return new WaitForSeconds(1);
      gameObject.SetActive(false);
    //  Destroy(gameObject);
    }

   public void ShatterObject(Collision collision)
   {
      var parent = collision.collider.transform.parent;
      Debug.Log(parent.name);
      parent.GetChild(0).gameObject.SetActive(false);
      parent.GetChild(1).gameObject.SetActive(true);
      transform.GetComponent<ObjectMove>().ObstaclesMove(collision);
   }
}
