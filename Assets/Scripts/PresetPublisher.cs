using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;



public class PresetPublisher : MonoBehaviour
{

    public GameObject Background;
    public TMP_FontAsset Text;
    public TextPreset SelectedPreset;
    // Start is called before the first frame update
    private TMP_Text ThisText;
    void Start()
    {
        ThisText = this.GetComponent<TMP_Text>();
    }

    public void ApplyPreset()
    {
        ThisText.fontSize = SelectedPreset.FontSize;
        ThisText.font = SelectedPreset.TextFont;
        ThisText.color = SelectedPreset.TextColor;
    }
}
