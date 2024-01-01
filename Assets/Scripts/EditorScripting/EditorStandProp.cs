 
using UnityEngine;

namespace EditorScripting
{
    public class EditorStandProp : MonoBehaviour
    {
        [SerializeField] private GameObject[] blueStand;
        [SerializeField] private GameObject[] redStand;
        [SerializeField] private GameObject[] turquoiseStand;
        [SerializeField] private GameObject[] lightblueStand;
        [SerializeField] private GameObject[] purpleStand;

        public GameObject[] BlueStand => blueStand;

        public GameObject[] RedStand => redStand;

        public GameObject[] TurquoiseStand => turquoiseStand;

        public GameObject[] LightblueStand => lightblueStand;

        public GameObject[] PurpleStand => purpleStand;
    }
}