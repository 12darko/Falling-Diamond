using DG.Tweening;
using Player;
using UnityEngine;

namespace Effect
{
    public class ObjectMove : MonoBehaviour
    {
        public void ObstaclesMove(Collision collision)
        {
            var obstacle = collision.collider.transform.parent.transform.parent.GetComponentsInChildren<Obstacle>();
            foreach (var obstacles in obstacle)
            {
                PlayerData.Instance.SpawnerUpdater += () =>
                {
                    Destroy(obstacles.transform.parent.GetComponent<NormalRotateManager>());
                    var posChild = obstacles.transform.localPosition;
                    var posMain = Vector3.zero;
                    var resultPos = posChild - posMain;
                    resultPos.Normalize(); // Vektörün magnitude uzunluğunu 1 yapar
                    resultPos *= 7f; // Vektörün boyutunu değişiyoruz
                
                   
                     obstacles.transform.DOLocalMove(resultPos * 1f, 0.3f, false).SetEase(Ease.Linear)
                        .OnComplete(() =>
                        {
                              obstacles.gameObject.transform.gameObject.SetActive(false);
                              
                        });  
                };
            }
        }
    }
}