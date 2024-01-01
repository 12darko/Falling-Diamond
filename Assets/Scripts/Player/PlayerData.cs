using System;
using Pattern;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerData : Singleton<PlayerData>
    {
        [SerializeField] private Vector3 destroyObjects;
        [SerializeField] private int destroyObjectCount;

        [SerializeField] private int point;
          private UnityAction _spawnerUpdater;
        public Vector3 DestroyObjects
        {
            get => destroyObjects;
            set => destroyObjects = value;
        }

        public int DestroyObjectCount
        {
            get => destroyObjectCount;
            set => destroyObjectCount = value;
        }

        public UnityAction SpawnerUpdater
        {
            get => _spawnerUpdater;
            set => _spawnerUpdater = value;
        }

        public int Point
        {
            get => point;
            set => point = value;
        }
    }
}

 