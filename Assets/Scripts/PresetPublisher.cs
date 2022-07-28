using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


// preset publisher will take the preset that the user has selected and apply the settings to the text that
// the script is attached to

public class PresetPublisher : MonoBehaviour
{
    public Camera Viewer;
    public Canvas DisplayCanvas;
    private Vector3 CanvasPosition;
    private Vector3 CameraPosition;
    private Vector3 CanvasScale;
    private float ViewingDistance;
    private float theta;
    private float TextHeightMeters;
    private float TextHeighPx;

    public TMP_Dropdown RowSelector;
    private int SelectedRow;
    public GameObject GameManager;
    private TextPreset SelectedPreset;
    private TextManager TextManagerScript;
    // Start is called before the first frame update
    private TMP_Text ThisText;
    public Material BackgroundMaterial;
    public Material ReferenceMaterial;
    private float LetterSuperiorityScaling;

    private void Start()
    {

        //BackgroundMaterial.SetColor("_Color", Color.white);
        //ThisText.color = Color.black;
        CanvasScale = DisplayCanvas.GetComponent<RectTransform>().localScale;
        // In order for the math to work, the y and x scales of the canvas must be equal

        if (CanvasScale.x != CanvasScale.y)
        {
            Debug.Log("PresetPublisher.cs WARNING: DisplayCanvas is not scaled correctly. Must be a square.");
        }

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
        // The letter superiority effect means that letters must be scaled up by 20% to be read with the same efficacy
        CalcFontHeight();

        ThisText.fontSize = TextHeighPx;
        ThisText.font = SelectedPreset.TextFont;
        ThisText.color = SelectedPreset.TextColor;

        if (BackgroundMaterial != null)
        {
            print("Changing the background material");
            BackgroundMaterial.color = ReferenceMaterial.color;
        }
    }

    private void CalcFontHeight()
    {
        theta = 2*Mathf.Atan((0.5f * SelectedPreset.FontSize * TextManagerScript.CanvasScale.x) /6f);
        CameraPosition = Viewer.transform.position;
        CanvasPosition = DisplayCanvas.transform.position;

        ViewingDistance = Vector3.Distance(CameraPosition, CanvasPosition);

        TextHeightMeters = Mathf.Tan(theta) * ViewingDistance;
        TextHeighPx =TextHeightMeters/CanvasScale.x;
        LetterSuperiorityScaling = 0.2f * TextHeighPx;
        TextHeighPx += LetterSuperiorityScaling;
    }


}
