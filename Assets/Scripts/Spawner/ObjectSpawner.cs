using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Effect;
using GameAnalyticsSDK.Setup;
using Player;
using Spawner;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
     public int targetFrameRate = 60;

    public GameObject tempsPositionObject;
    private GameObject _setParent;
    private Obstacle[] _obstacles;

    [SerializeField] private FinishBar finishBar;
    [SerializeField] private Material[] mats;

    public Obstacle[] Obstacles
    {
        get => _obstacles;
        set => _obstacles = value;
    }

    private void Start()
    {   
        TinySauce.OnGameStarted( PlayerPrefs.GetInt("Level").ToString());
        ObjectSpawnerData.Instance.Level = PlayerPrefs.GetInt("Level", 1);
        Debug.Log(  ObjectSpawnerData.Instance.Level);
        RandomObjectGenerator();
        ObjectEvent.ObjectSpawnerAction = SpawnObject;
        ObjectEvent.ObjectSpawnerAction.Invoke();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        
        finishBar.EndPlatform = GameObject.Find("Changed(Clone)").GetComponent<Transform>();
        finishBar.PlayerPos  = GameObject.Find("Player").GetComponent<Transform>();
        finishBar.MaxDistance =  finishBar.GetDistance();
        
    }


    private void SpawnObject()
    {        
        _setParent = new GameObject("Main");
        var randomNumber = Random.value;
        for (ObjectSpawnerData.Instance.ObstacleNumber = 0;
             ObjectSpawnerData.Instance.ObstacleNumber >
             -ObjectSpawnerData.Instance.Level - ObjectSpawnerData.Instance.AddNumber;
             ObjectSpawnerData.Instance.ObstacleNumber -= .7f)
        {
            if (ObjectSpawnerData.Instance.Level <= 20)
            {
                ObjectSpawnerData.Instance.Temp1Object =
                    Instantiate(ObjectSpawnerData.Instance.InGameObjectsPrefab[Random.Range(0, 2)]);
                RenderSettings.skybox=mats[0];
            }

            if (ObjectSpawnerData.Instance.Level > 20 && ObjectSpawnerData.Instance.Level < 50)
            {
                ObjectSpawnerData.Instance.Temp1Object =
                    Instantiate(ObjectSpawnerData.Instance.InGameObjectsPrefab[Random.Range(1, 3)]);
                RenderSettings.skybox=mats[1];
            }

            if (ObjectSpawnerData.Instance.Level >= 50 && ObjectSpawnerData.Instance.Level < 100)
            {
                ObjectSpawnerData.Instance.Temp1Object =
                    Instantiate(ObjectSpawnerData.Instance.InGameObjectsPrefab[Random.Range(2, 4)]);
                RenderSettings.skybox=mats[2];
            }

            if (ObjectSpawnerData.Instance.Level >= 100)
            {
                ObjectSpawnerData.Instance.Temp1Object =
                    Instantiate(ObjectSpawnerData.Instance.InGameObjectsPrefab[Random.Range(3, 4)]);
                RenderSettings.skybox=mats[3];
            }

            ObjectSpawnerData.Instance.Temp1Object.transform.position = new Vector3(0,
                ObjectSpawnerData.Instance.ObstacleNumber + transform.position.y, 0);
            ObjectSpawnerData.Instance.Temp1Object.transform.eulerAngles =
                new Vector3(0, ObjectSpawnerData.Instance.ObstacleNumber * 8, 0);


            if (Mathf.Abs(ObjectSpawnerData.Instance.ObstacleNumber) >= ObjectSpawnerData.Instance.Level * .3f &&
                Mathf.Abs(ObjectSpawnerData.Instance.ObstacleNumber) <= ObjectSpawnerData.Instance.Level * .6f)
            {
                ObjectSpawnerData.Instance.Temp1Object.transform.eulerAngles =
                    new Vector3(0, ObjectSpawnerData.Instance.ObstacleNumber * 8, 0);
                ObjectSpawnerData.Instance.Temp1Object.transform.eulerAngles += Vector3.up * 180;
            }
            else if (Mathf.Abs(ObjectSpawnerData.Instance.ObstacleNumber) > ObjectSpawnerData.Instance.Level * 0.8f)
            {
                ObjectSpawnerData.Instance.Temp1Object.transform.eulerAngles =
                    new Vector3(0, ObjectSpawnerData.Instance.ObstacleNumber * 8, 0);
                if (randomNumber > 0.75f)
                {
                    ObjectSpawnerData.Instance.Temp1Object.transform.eulerAngles += Vector3.up * 180;
                }
            }


            ObjectSpawnerData.Instance.Temp1Object.SetActive(true);

            _obstacles = ObjectSpawnerData.Instance.Temp1Object.transform.GetComponentsInChildren<Obstacle>();
            foreach (var obstacle in _obstacles)
            {
                var posChild = obstacle.transform.localPosition;
                var posMain = Vector3.zero;
                var resultPos = posChild - posMain;
                resultPos.Normalize(); // Vektörün magnitude uzunluğunu 1 yapar
                resultPos *= 2f; // Vektörün boyutunu değişiyoruz


                obstacle.transform.parent.gameObject.SetActive(false);
                obstacle.transform.DOMove(resultPos * 5, 0.4f, false).SetEase(Ease.Linear).OnComplete(
                    () =>
                    {
                         obstacle.transform.parent.gameObject.SetActive(true);
                         obstacle.transform.DOLocalMove(posChild, 0.5f, false).SetEase(Ease.Linear);
                    });
                
            }
 
            ObjectSpawnerData.Instance.Temp1Object.transform.SetParent(_setParent.transform);
       
        }

        ObjectSpawnerData.Instance.Temp2Object = Instantiate(ObjectSpawnerData.Instance.EnvironmentChangedPrefab);
        ObjectSpawnerData.Instance.Temp2Object.transform.position = new Vector3(0,
            ObjectSpawnerData.Instance.ObstacleNumber + transform.position.y, 0);
        ObjectSpawnerData.Instance.Temp2Object.transform.SetParent(_setParent.transform);

    }

    private void RandomObjectGenerator()
    {
        var randomIndex = Random.Range(0, ObjectSpawnerData.Instance.InGameObjectsPrefab.Length);
        for (var i = 0; i < ObjectSpawnerData.Instance.InGameObjectsPrefab.Length; i++)
        {
            ObjectSpawnerData.Instance.InGameObjectsPrefab[i] =
                ObjectSpawnerData.Instance.InGameObjectsModel[i + (randomIndex * 4)];
        }
    }

    public void SpawnObjectWithDestroyOthers(int addNumber, Vector3 position)
    {
        var randomNumber = Random.value;
     
        for (float i = 0; i <= addNumber; i+= 0.7f)
        {
            if (addNumber == 0)
            {
                Debug.Log("obje oluşturulmadı");
            }
            else
            {
                if (ObjectSpawnerData.Instance.Level <= 20)
                {
                    ObjectSpawnerData.Instance.Temp3Object =
                        Instantiate(ObjectSpawnerData.Instance.InGameObjectsPrefab[Random.Range(0, 2)]);
                }

                if (ObjectSpawnerData.Instance.Level > 20 && ObjectSpawnerData.Instance.Level < 50)
                {
                    ObjectSpawnerData.Instance.Temp3Object =
                        Instantiate(ObjectSpawnerData.Instance.InGameObjectsPrefab[Random.Range(1, 3)]);
                }

                if (ObjectSpawnerData.Instance.Level >= 50 && ObjectSpawnerData.Instance.Level < 100)
                {
                    ObjectSpawnerData.Instance.Temp3Object =
                        Instantiate(ObjectSpawnerData.Instance.InGameObjectsPrefab[Random.Range(2, 4)]);
                }

                if (ObjectSpawnerData.Instance.Level >= 100)
                {
                    ObjectSpawnerData.Instance.Temp3Object =
                        Instantiate(ObjectSpawnerData.Instance.InGameObjectsPrefab[Random.Range(3, 4)]);
                }

                Debug.Log(PlayerData.Instance.DestroyObjects.y + ObjectSpawnerData.Instance.ObstacleNumbersDestroy);
                var temp = position.y + 0.5f;
                ObjectSpawnerData.Instance.Temp3Object.transform.position = new Vector3(0, i + temp, 0);
              //  ObjectSpawnerData.Instance.Temp3Object.transform.eulerAngles = new Vector3(0, i * 8, 0);
              ObjectSpawnerData.Instance.Temp3Object.transform.eulerAngles = new Vector3(0, 0, 0);

                if (Mathf.Abs(i) >= ObjectSpawnerData.Instance.Level * .3f &&
                    Mathf.Abs(i) <= ObjectSpawnerData.Instance.Level * .6f)
                {
                   // ObjectSpawnerData.Instance.Temp3Object.transform.eulerAngles = new Vector3(0, i * 8, 0);
                    ObjectSpawnerData.Instance.Temp3Object.transform.eulerAngles = new Vector3(0, 0, 0);
                 //   ObjectSpawnerData.Instance.Temp3Object.transform.eulerAngles += Vector3.up * 180;
                }
                else if (Mathf.Abs(i) > ObjectSpawnerData.Instance.Level * 0.8f)
                {
                 //   ObjectSpawnerData.Instance.Temp3Object.transform.eulerAngles = new Vector3(0, i * 8, 0);
                 ObjectSpawnerData.Instance.Temp3Object.transform.eulerAngles = new Vector3(0, 0, 0);
                    if (randomNumber > 0.75f)
                    {
                        ObjectSpawnerData.Instance.Temp3Object.transform.eulerAngles += Vector3.up * 180;
                    }
                }

                _obstacles = ObjectSpawnerData.Instance.Temp3Object.transform.GetComponentsInChildren<Obstacle>();
                foreach (var obstacle in _obstacles)
                {
                    var posChild = obstacle.transform.localPosition;
                    var posMain = Vector3.zero;
                    var resultPos = posChild - posMain;
                    resultPos.Normalize(); // Vektörün magnitude uzunluğunu 1 yapar
                    resultPos *= 2f; // Vektörün boyutunu değişiyoruz
                    obstacle.transform.parent.gameObject.SetActive(false);
                    obstacle.transform.DOLocalMove(resultPos, 0.3f, false).SetEase(Ease.Linear)
                        .OnComplete(
                            () =>
                            {
                                obstacle.transform.parent.gameObject.SetActive(true);
                                obstacle.transform.DOLocalMove(posChild, 0.4f, false).SetEase(Ease.Linear); // not sorun burada olabilir
                            });
                }
                Debug.Log( ObjectSpawnerData.Instance.Temp3Object.name);
            }
            ObjectSpawnerData.Instance.Temp3Object.transform.SetParent(_setParent.transform);
        }
    }
}