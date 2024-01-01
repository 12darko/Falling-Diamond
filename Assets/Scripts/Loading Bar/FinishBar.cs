using System;
using System.Collections;
using System.Collections.Generic;
using Pattern;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishBar : MonoBehaviour
{
    [Header("UI Ref")]
    [SerializeField] private TMP_Text levelCounter;
    [SerializeField] private Image loadingBar;

    [Header("Objects")] 
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform endPlatform;

    #region Props

    
 

    public Transform EndPlatform
    {
        get => endPlatform;
        set => endPlatform = value;
    }

 

    public Transform PlayerPos
    {
        get => playerPos;
        set => playerPos = value;
    }

    public float MaxDistance
    {
        get => _maxDistance;
        set => _maxDistance = value;
    }

    #endregion

    private float _maxDistance;

 


    private void Start()
    {

        SetLevelText();
    }

    private void Update()
    {
        var distance = 1 - (GetDistance() / _maxDistance); 
        UpdateProgress(distance);
    }

    private void SetLevelText()
    {
        levelCounter.text = PlayerPrefs.GetInt("Level").ToString();
    }

    public float GetDistance()
    {
        return Vector3.Distance(playerPos.position, endPlatform.position);
    }
    private void UpdateProgress(float value)
    {
        loadingBar.fillAmount = value;
  
    }
}
