using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EditorScripting
{
    public class EditorPrefab : MonoBehaviour
    {
        [SerializeField] private Vector3[] pos;
        [SerializeField] private Quaternion[] rot;
        [SerializeField] private PlatformType type;

        [SerializeField] private EditorStandProp standProp;

        [ContextMenu("Generate Platform")]
        public void CreatePlatform()
        {
            switch (type)
            {
                case PlatformType.Red:
                    CreateStandColor(standProp.RedStand);
                    break;
                case PlatformType.Turquoise:
                    CreateStandColor(standProp.TurquoiseStand);
                    break;
                case PlatformType.Blue:
                    CreateStandColor(standProp.BlueStand);
                    break;
                case PlatformType.LightBlue:
                    CreateStandColor(standProp.LightblueStand);
                    break;
                case PlatformType.Purple:
                    CreateStandColor(standProp.PurpleStand);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void CreateStandColor(IReadOnlyList<GameObject> stand)
        {
            for (var i = 0; i < pos.Length; i++)
            {
                Instantiate(stand[Random.Range(0, stand.Count)], pos[i], rot[i], transform);
            }
        }
    }


    public enum PlatformType
    {
        Red,
        Turquoise,
        Blue,
        LightBlue,
        Purple
    }
}