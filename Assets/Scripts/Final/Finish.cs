using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Finish : MonoBehaviour
{
   [SerializeField] private GameObject portalTransitionEffect;
   [SerializeField] private GameObject player;

   private void Start()
   {
      player =GameObject.FindGameObjectWithTag("Player");
   }

   public void Effect()
   {
      portalTransitionEffect.SetActive(true);
      player.transform.DOScale(0, 0.5f).SetEase(Ease.Linear);
   }
}
