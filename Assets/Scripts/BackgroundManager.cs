using System.Collections;
using System.Runtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackgroundManager : MonoBehaviour
{

    public GameObject MenuManagerObject;
    private MenuManager MenuManagerScript;

    public TMP_Text RValDisplay, GValDisplay, BValDisplay;

    private Color CurrentColor;
    public Slider RedSlider;
    public Slider GreenSlider;
    public Slider BlueSlider;
    public Material BackgroundMaterial;
    public Material InstructionMaterial;

    private float ScaledVal;

    // Start is called before the first frame update
    void Start()
    {
        MenuManagerScript = MenuManagerObject.GetComponent<MenuManager>();
        // make sure that the background starts as white
        BackgroundMaterial.SetColor("_Color", Color.white);

        CurrentColor = BackgroundMaterial.color;

        print(CurrentColor.r + " " + CurrentColor.g + " " + CurrentColor.b + " " + CurrentColor.a);

        UpdateValueDisplay();

    }


    public void RedVal ()
    {
        CurrentColor = new Color(RedSlider.value, CurrentColor.g, CurrentColor.b, CurrentColor.a);
        BackgroundMaterial.SetColor("_Color", CurrentColor);
        UpdateValueDisplay();
    }

    public void GreenVal()
    {
        CurrentColor = new Color(CurrentColor.r, GreenSlider.value, CurrentColor.b, CurrentColor.a);
        BackgroundMaterial.SetColor("_Color", CurrentColor);
        UpdateValueDisplay();
    }



    public void BlueVal()
    {
        CurrentColor = new Color(CurrentColor.r, CurrentColor.g, BlueSlider.value, CurrentColor.a);
        BackgroundMaterial.SetColor("_Color", CurrentColor);
        UpdateValueDisplay();
    }

    private void UpdateValueDisplay()
    {
        ScaledVal = Mathf.Floor(RedSlider.value * 255);
        RValDisplay.text = ScaledVal.ToString();

        ScaledVal = Mathf.Floor(GreenSlider.value * 255);
        GValDisplay.text = ScaledVal.ToString();

        ScaledVal = Mathf.Floor(BlueSlider.value * 255);
        BValDisplay.text = ScaledVal.ToString();

    }

    private void UpdateSliderValues()
    {
        RedSlider.value = BackgroundMaterial.color.r /255;
        BlueSlider.value = BackgroundMaterial.color.b/255;
        GreenSlider.value = BackgroundMaterial.color.g/255;
    }

    private void SliderToPresetSync()
    {
        UpdateSliderValues();
        UpdateValueDisplay();
    }


    public void BackgroundRed()
    {
        if(MenuManagerScript.ColorObject == "Background")
        {
           RedSlider.value = 1;
            BlueSlider.value = 0;
            GreenSlider.value = 0;
            UpdateValueDisplay();
        }
    }

    public void BackgroundGreen()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {
            RedSlider.value = 0;
            BlueSlider.value = 0;
            GreenSlider.value = 1;
            UpdateValueDisplay();
        }
    }

    public void BackgroundBlue()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {
            RedSlider.value = 0;
            BlueSlider.value = 1;
            GreenSlider.value = 0;
            UpdateValueDisplay();
        }
    }

    public void BackgroundBlack()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {
            RedSlider.value = 0;
            BlueSlider.value = 0;
            GreenSlider.value = 0;
            UpdateValueDisplay();
        }
    }

    public void BackgroundWhite()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {
            RedSlider.value = 1;
            BlueSlider.value = 1;
            GreenSlider.value = 1;
            UpdateValueDisplay();
        }
    }

    public void BackgroundYellow()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {
            RedSlider.value = 1;
            BlueSlider.value = 0;
            GreenSlider.value = 1;
            UpdateValueDisplay();
        }
    }

    public void UpdateInstructionBackground()
    {
        InstructionMaterial.color = BackgroundMaterial.color;
        UpdateValueDisplay();
    }


}
