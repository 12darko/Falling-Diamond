using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using Effect;
using Spawner;
using States;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private int spawnClaim = 0;
        [SerializeField] private ObjectSpawner _spawner;
        [SerializeField] private PlayerState pState = PlayerState.Prepare;
        [SerializeField] private CinemachineVirtualCamera vrCam;
        [SerializeField] private AudioClip finish, destroy;

        #region Class

        [SerializeField] private PlayerKeyController playerKeyController;
        [SerializeField] private PlayerInvincibleController playerInvincibleController;
        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private NextLevel nextLevel;

        #endregion


        private void Update()
        {
            switch (pState)
            {
                case PlayerState.Playing:
                    playerKeyController.PlayerKeyDown();
                    playerInvincibleController.PlayerInvincible();

                    break;
                case PlayerState.Prepare:
                    pState = PlayerState.Playing;
                    break;
                case PlayerState.Died:
                    break;
                case PlayerState.Finish:
                  
                    nextLevel.Invoke("Next", 3f);
                    TinySauce.OnGameFinished(true, 1000,PlayerPrefs.GetInt("Level").ToString());

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void FixedUpdate()
        {
            if (pState == PlayerState.Playing)
            {
                playerMovementController.PlayerMovement();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Finish") && pState == PlayerState.Playing)
            {
                pState = PlayerState.Finish;
                transform.DOMove(collision.collider.transform.GetChild(0).position, 03f, false)
                    .SetEase(Ease.Linear);
                transform.DOScale(0f, 0.6f).SetEase(Ease.Linear);
                SoundManager.Instance.PlaySoundFx(finish, 0.5f);

            }
            else
            {
                // Debug.Log(collision.collider.gameObject.name);
                var invincibleController = playerInvincibleController;

                if (invincibleController.Invincible)
                {
                    collision.collider.transform.parent.GetComponent<Obstacle>().ShatterObject(collision);
                    //  collision.collider.transform.parent.GetComponent<ObstacleController>().ShatterAllObstacles();
                    PlayerData.Instance.Point += Random.Range(25, 55);
                    SoundManager.Instance.PlaySoundFx(destroy, 0.5f);
                }
                else
                {
                    if (collision.collider.CompareTag("Black") && !collision.collider.transform.parent
                            .GetComponent<ObstacleController>().IsBreak)
                    {
                        /*
                                        var magnitude = rb.velocity.magnitude * 10f;
                                        var clamp = Mathf.Clamp(magnitude, 1, 10);
                                        rb.AddForce(0, clamp * 100f * Vector3.up.y , 0, ForceMode.Impulse);*/
                        var magnitude = playerMovementController.Rb.velocity.magnitude;
                        PlayerData.Instance.DestroyObjects = collision.collider.transform.parent
                            .GetComponent<ObstacleController>().transform.position;
                        transform.DOMoveY(magnitude * 2f, 0.5f, false).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            if (spawnClaim != 1)
                            {
                                _spawner.SpawnObjectWithDestroyOthers(10 / 2, PlayerData.Instance.DestroyObjects);
                            }

                            spawnClaim = 1;
                        });
                        PlayerData.Instance.Point -= Random.Range(5, 15);
                        SoundManager.Instance.AudioSource.pitch = 1;
                    }
                    else if (collision.collider.CompareTag("Break"))
                    {
                        collision.collider.transform.parent.GetComponent<Obstacle>().ShatterObject(collision);
                        PlayerData.Instance.Point += Random.Range(5, 15);
                        SoundManager.Instance.PlaySoundFx(destroy, 0.5f);
                        SoundManager.Instance.AudioSource.pitch += Time.deltaTime;

                        if (!collision.collider.CompareTag("Black") && invincibleController.Impact)
                        {
                            collision.collider.transform.parent.GetComponent<Obstacle>().ShatterObject(collision);
                            PlayerData.Instance.Point += Random.Range(5, 15);
                            SoundManager.Instance.PlaySoundFx(destroy, 0.5f);
                        }
                        else
                        {
                            SoundManager.Instance.AudioSource.pitch = 1;
                            if (collision.collider.CompareTag("Red"))
                            {
                                
                                Debug.Log("Yandın");
                                PlayerData.Instance.Point = 0;
                            }

                            invincibleController.Impact = false;
                        }
                    }
                }
            }
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            if (!collisionInfo.collider.CompareTag("Finish"))
            {
                var invincibleController = playerInvincibleController;
                if (invincibleController.Invincible)
                {
                    collisionInfo.collider.transform.parent.GetComponent<Obstacle>().ShatterObject(collisionInfo);
                    PlayerData.Instance.Point += Random.Range(25, 50);
                    SoundManager.Instance.PlaySoundFx(destroy, 0.5f);
                    
                }

                else
                {
                    if (!collisionInfo.collider.CompareTag("Black") && invincibleController.Impact)
                    {
                        collisionInfo.collider.transform.parent.GetComponent<Obstacle>().ShatterObject(collisionInfo);
                        PlayerData.Instance.Point += Random.Range(5, 25);
                        SoundManager.Instance.PlaySoundFx(destroy, 0.5f);
                    }
                    else
                    {
                        SoundManager.Instance.AudioSource.pitch = 1;
                        if (collisionInfo.collider.CompareTag("Red"))
                        {
                            Debug.Log("Yandın");
                            PlayerData.Instance.Point = 0;
                        }

                        invincibleController.Impact = false;
                    }
                }
            }
            else
            {
                Debug.Log(collisionInfo.collider.name);
              
                transform.DOMove(collisionInfo.collider.transform.GetChild(0).position, 0.5f, false).OnComplete(() =>
                    {
                        transform.gameObject.SetActive(false);  
                    })
                    .SetEase(Ease.Linear);
                transform.DOScale(0f, 1f).SetEase(Ease.Linear);

                vrCam.Follow = collisionInfo.collider.transform.GetChild(0);
                vrCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.x = 0;

                collisionInfo.collider.transform.parent.GetComponent<ConfettiEffect>().ActiveConfetti();
                
            }
        }
    }
}