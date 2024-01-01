using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Spawner;
using TMPro;
using UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        UIData.Instance.ExpText.text = PlayerData.Instance.Point.ToString();
    }
}
