using System.Collections;
using System.Collections.Generic;
using Pattern;
using TMPro;
using UnityEngine;

public class UIData : Singleton<UIData>
{
    [SerializeField] private TMP_Text expText;

    public TMP_Text ExpText
    {
        get => expText;
        set => expText = value;
    }
}
