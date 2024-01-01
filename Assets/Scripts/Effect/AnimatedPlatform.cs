using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatedPlatform : MonoBehaviour
{
    
    public void ObjectSetActiveFalse()
    {
        gameObject.SetActive(false);
        PlayerData.Instance.SpawnerUpdater.Invoke();
    }
}
