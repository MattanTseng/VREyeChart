using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


// preset publisher will take the preset that the user has selected and apply the settings to the text that
// the script is attached to

public class PresetPublisher : MonoBehaviour
{
    public TMP_Dropdown RowSelector;
    private int SelectedRow;
    public GameObject GameManager;
    public TextPreset SelectedPreset;
    private TextManager TextManagerScript;
    // Start is called before the first frame update
    private TMP_Text ThisText;
    public Material BackgroundMaterial;
    public Material ReferenceMaterial;

    private void Start()
    {

        //BackgroundMaterial.SetColor("_Color", Color.white);
        //ThisText.color = Color.black;

        ThisText = this.gameObject.GetComponent<TMP_Text>();
        TextManagerScript = GameManager.GetComponent<TextManager>();

        ApplyPreset();
    }


    private void GetPreset()
    {
        SelectedRow = RowSelector.value;
        print(SelectedRow);

        SelectedPreset = TextManagerScript.TextPresets[SelectedRow];
        print(SelectedPreset.TextColor);
    }
    public void ApplyPreset()
    {
        GetPreset();
        
        ThisText.fontSize = SelectedPreset.FontSize;
        ThisText.font = SelectedPreset.TextFont;
        ThisText.color = SelectedPreset.TextColor;

        if (BackgroundMaterial != null)
        {
            print("Changing the background material");
            BackgroundMaterial.color = ReferenceMaterial.color;
        }
    }


}
