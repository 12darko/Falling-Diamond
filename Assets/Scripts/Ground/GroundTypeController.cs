using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ground
{
    public class GroundTypeController : MonoBehaviour
    {
     [SerializeField] private GroundType _type;
     [SerializeField] private int earnedExp;

     private void Start()
     {
         GroundController();
         _type = (GroundType)Random.Range(0, 3);
     }

     private void GroundController()
        {
            switch (_type)
            {
                case GroundType.LOW:
                    earnedExp = Random.Range(1,3);
                    break;
                case GroundType.MID:
                    earnedExp = Random.Range(3,6);
                    break;
                case GroundType.HIGH:
                    earnedExp = Random.Range(6,9);
                    break;
                case GroundType.ULTRA:
                    earnedExp = Random.Range(9,12);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}