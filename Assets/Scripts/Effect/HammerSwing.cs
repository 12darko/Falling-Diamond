using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HammerSwing : MonoBehaviour
{
    [SerializeField] private float speed;
   
   public void SwingTrue()
   {
       transform.DORotate(new Vector3( transform.position.x, transform.position.y,  Input.mousePosition.z  * speed), 0.2f,
           RotateMode.LocalAxisAdd).SetEase(Ease.Linear);
       // transform.Rotate(new Vector3(transform.position.x, transform.position.y,Input.mousePosition.z* speed * Time.deltaTime));
   }
   public void SwingFalse()
   {
       //transform.Rotate(new Vector3(-300,90, 90));
   }
}
