using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


// preset publisher will take the preset that the user has selected and apply the settings to the text that
// the script is attached to

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
