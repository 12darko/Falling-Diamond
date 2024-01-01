using Pattern;
using UnityEngine;

namespace Spawner
{
    public class ObjectSpawnerData : Singleton<ObjectSpawnerData>
    {
        [SerializeField] private GameObject[] inGameObjectsModel;
        [SerializeField] private GameObject[] inGameObjectsPrefab = new GameObject[4];

        [SerializeField] private GameObject environmentChangedPrefab;

        [SerializeField] private GameObject temp1Object, temp2Object;
        [SerializeField] private GameObject temp3Object;

        private int _level = 1;
 
        private int _exp;
        private int _addNumber = 7;
        private float _obstacleNumber;
        private float _obstacleNumbersDestroy;


        

        public GameObject[] InGameObjectsModel
        {
            get => inGameObjectsModel;
            set => inGameObjectsModel = value;
        }

        public GameObject[] InGameObjectsPrefab
        {
            get => inGameObjectsPrefab;
            set => inGameObjectsPrefab = value;
        }

        public GameObject EnvironmentChangedPrefab
        {
            get => environmentChangedPrefab;
            set => environmentChangedPrefab = value;
        }

        public GameObject Temp1Object
        {
            get => temp1Object;
            set => temp1Object = value;
        }

        public GameObject Temp2Object
        {
            get => temp2Object;
            set => temp2Object = value;
        }

        public int Level
        {
            get => _level;
            set => _level = value;
        }

        public int Exp
        {
            get => _exp;
            set => _exp = value;
        }

        public int AddNumber
        {
            get => _addNumber;
            set => _addNumber = value;
        }

        public float ObstacleNumber
        {
            get => _obstacleNumber;
            set => _obstacleNumber = value;
        }

        public float ObstacleNumbersDestroy
        {
            get => _obstacleNumbersDestroy;
            set => _obstacleNumbersDestroy = value;
        }

        public GameObject Temp3Object
        {
            get => temp3Object;
            set => temp3Object = value;
        }
    }
}