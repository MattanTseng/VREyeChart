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


    // There are two different ways that the color of the background can be changed. 
    // there are certain presets that the user can select. 
    // additionally there are RGB sliders for more fine changes.
    // at the start of each colorchange method there is an if statment. 
    // the colorobject is changed in the menu manager. This allows there to be only one set of buttons 
    // and sliders that can change the color of the text and the background independantly

    public void RedValBackground ()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {
            CurrentColor = new Color(RedSlider.value, CurrentColor.g, CurrentColor.b, CurrentColor.a);
            BackgroundMaterial.SetColor("_Color", CurrentColor);
            UpdateValueDisplay();
        }
    }

    public void GreenValBackground()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {
            CurrentColor = new Color(CurrentColor.r, GreenSlider.value, CurrentColor.b, CurrentColor.a);
            BackgroundMaterial.SetColor("_Color", CurrentColor);
            UpdateValueDisplay();
        }
    }



    public void BlueValBackground()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {
            CurrentColor = new Color(CurrentColor.r, CurrentColor.g, BlueSlider.value, CurrentColor.a);
            BackgroundMaterial.SetColor("_Color", CurrentColor);
            UpdateValueDisplay();
        }
    }

    public void UpdateValueDisplay()
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

    public void SyncSliders()
    {
        RedSlider.value = CurrentColor.r;
        GreenSlider.value = CurrentColor.g;
        BlueSlider.value = CurrentColor.b;
    }
}
