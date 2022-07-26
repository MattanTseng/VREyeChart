using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This is the most complicated script in the application. 
// This script 

public class TextManager : MonoBehaviour
{
    private Color CurrentColor;

    public GameObject MenuManagerObject;
    private MenuManager MenuManagerScript;
    public GameObject TextCanvas;
    public TMP_FontAsset SelectedFont;
    public Color SelectedColor;
    // all of the rows of text are stored in this vector
    public TMP_Text[] RowObjects;
    public int[] Distances;

    private Vector3 CanvasScale;
    private string[] ChartContent;
    private int[] FontSizes;
    private TextPreset[] TextPresets;

    public int SelectedRow;

    private TextPreset InstructionAppearance;

    public TMP_Text Instructions;
    public TMP_Text RValDisplay, GValDisplay, BValDisplay;
    public Slider RedSlider;
    public Slider GreenSlider;
    public Slider BlueSlider;

    private float ScaledVal;

    public string[] InstructionContent;

    private void Start()
    {

        InstructionContent[0] = "Use the options in the menu \n to select the size, color, and \n font that is easiest for you to \n read.";
        InstructionContent[1] = "Use the buttons to indicate \n which orientation is being \n presented.";

        MenuManagerScript = MenuManagerObject.GetComponent<MenuManager>();

        TextPresets = new TextPreset[RowObjects.Length];
        CanvasScale = TextCanvas.GetComponent<RectTransform>().localScale;
        // In order for the math to work, the y and x scales of the canvas must be equal

        if (CanvasScale.x != CanvasScale.y)
        {
            Debug.Log("WARNING: Canvas is not scaled correctly. Must be a square.");
        }

        // Create a list of strings that increases by 1 letter
        ChartContent = NewStringContent(RowObjects.Length);

        // creates a list of integers to be used as the font size of the letters.
        FontSizes = this.GetComponent<PxCalculator>().CalculatePx(Distances, CanvasScale);

        TextPresets = UpdateChart(FontSizes, SelectedFont, ChartContent, SelectedColor);

        CurrentColor = SelectedColor;

        PublishChartClass(TextPresets, RowObjects);
    }

    //Update all attributes in one row
    public TextPreset UpdateRow(int Size, TMP_FontAsset Font, string Content, Color color)
    {
        TextPreset NewText = new TextPreset(Size, Font, Content, color);
        return NewText;
    }
    //Update text content in one row
    public TextPreset UpdateRowContent(string Content)
    {

        TextPreset NewContent = new TextPreset(Content);
        return NewContent;

    }

    //Update all attributes in whole chart
    public TextPreset[] UpdateChart(int[] Size, TMP_FontAsset Font, string[] Content, Color color)
    {
        TextPreset[] NewChart = new TextPreset[Content.Length];
        for (int i = 0; i < Content.Length; i++)
        {
            NewChart[i] = UpdateRow(Size[i], Font, Content[i], color);
        }
        return NewChart;
    }
    //Update text content in whole chart
    public void UpdateChartContent(string[] Content, TextPreset[] NewChart)
    {
        for (int i = 0; i < Content.Length; i++)
        {
            NewChart[i].TextContent = Content[i];
        }
    }

    private void PublishChartClass(TextPreset[] Preset, TMP_Text[] Row)
    {
        // publish the information in the text class so that the user can see it.
        for (int i = 0; i < Preset.Length; i++)
        {
            Row[i].fontSize = Preset[i].FontSize;
            Row[i].text = Preset[i].TextContent;
            Row[i].font = Preset[i].TextFont;
            Row[i].color = Preset[i].TextColor;
        }
    }



    public string[] NewStringContent(int numRows)
    {
        string[] TextContent = new string[numRows];
        // this is the string that we will pull random letters from.
        string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for (int i = 1; i <= numRows; i++)
        {
            // re-initialize the string to clear it
            string row = null;
            for (int j = 0; j < i; j++)
            {
                // add i number of random letters to the string
                row += Alphabet[Random.Range(0, Alphabet.Length)].ToString();
                // add spaces in between each character
                row += "  ";

            }
            TextContent[i - 1] = row;

        }

        // Return a list of n strings
        return TextContent;
    }

    public void RefreshLetters()
    {
        string[] NewLetters = NewStringContent(RowObjects.Length);
        TextPreset[] TextPresets = new TextPreset[RowObjects.Length];

        for (int i = 0; i < NewLetters.Length; i++)
        {
            Debug.Log(NewLetters[i]);
        }
        TextPresets = UpdateChart(FontSizes, SelectedFont, NewLetters, SelectedColor);
        UpdateChartContent(NewLetters, TextPresets);
        PublishChartClass(TextPresets, RowObjects);

    }



    //These methods are used to change the color of the text
    public void ChangeColorPreset()
    {
        foreach (TextPreset TextRow in TextPresets)
        {
            TextRow.NewColor(SelectedColor);
        }

    }

    // these are for the color sliders
    public void RedValText()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            print("RedValText");
            SelectedColor = new Color(RedSlider.value, SelectedColor.g, SelectedColor.b, SelectedColor.a);
            UpdateDisplayValues();
            ChangeColorPreset();
            PublishChartClass(TextPresets, RowObjects);
        }
    }
    public void GreebValText()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            SelectedColor = new Color(SelectedColor.r, GreenSlider.value, SelectedColor.b, SelectedColor.a);
            UpdateDisplayValues();
            ChangeColorPreset();
            PublishChartClass(TextPresets, RowObjects);
        }
    }
    public void BlueValText()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            SelectedColor = new Color(SelectedColor.r, SelectedColor.g, BlueSlider.value, SelectedColor.a);
            UpdateDisplayValues();
            ChangeColorPreset();
            PublishChartClass(TextPresets, RowObjects);
        }
    }

    private void UpdateDisplayValues()
    {
        ScaledVal = Mathf.Floor(RedSlider.value * 255);
        RValDisplay.text = ScaledVal.ToString();

        ScaledVal = Mathf.Floor(GreenSlider.value * 255);
        GValDisplay.text = ScaledVal.ToString();

        ScaledVal = Mathf.Floor(BlueSlider.value * 255);
        BValDisplay.text = ScaledVal.ToString();


    }

    public void UpdateSliderValues()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            RedSlider.value = SelectedColor.r / 255;
            BlueSlider.value = SelectedColor.b / 255;
            GreenSlider.value = SelectedColor.g / 255;
        }
    }

    // these are the color presets
    public void TextRed()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            RedSlider.value = 1;
            BlueSlider.value = 0;
            GreenSlider.value = 0;
            ChangeColorPreset();
            PublishChartClass(TextPresets, RowObjects);
            UpdateDisplayValues();
        }
    }

    public void TextGreen()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            RedSlider.value = 0;
            BlueSlider.value = 0;
            GreenSlider.value = 1;
            ChangeColorPreset();
            PublishChartClass(TextPresets, RowObjects);
            UpdateDisplayValues();
        }
    }
    public void TextBlue()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            RedSlider.value = 0;
            BlueSlider.value = 1;
            GreenSlider.value = 0;
            ChangeColorPreset();
            PublishChartClass(TextPresets, RowObjects);
            UpdateDisplayValues();
        }
    }
    public void TextBlack()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            RedSlider.value = 0;
            BlueSlider.value = 0;
            GreenSlider.value = 0;
            ChangeColorPreset();
            PublishChartClass(TextPresets, RowObjects);
            UpdateDisplayValues();
        }
    }

    public void TextWhite()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            RedSlider.value = 1;
            BlueSlider.value = 1;
            GreenSlider.value = 1;
            ChangeColorPreset();
            PublishChartClass(TextPresets, RowObjects);
            UpdateDisplayValues();
        }
    }

    public void TextYellow()
    {
        if (MenuManagerScript.ColorObject == "Letters")
        {
            RedSlider.value = 1;
            BlueSlider.value = 0;
            GreenSlider.value = 1;
            ChangeColorPreset();
            PublishChartClass(TextPresets, RowObjects);
            UpdateDisplayValues();
        }
    }

    //this method is used to change the font of the text. 
    public void ChangeFont(int Font)
    {
        this.GetComponent<FontManager>().ChangeFont(TextPresets, Font);
        PublishChartClass(TextPresets, RowObjects);
    }

    public void UpdateInstructionStyle() 
    {
        InstructionAppearance = new TextPreset(TextPresets[SelectedRow]);
        InstructionAppearance.TextContent = InstructionContent[0];
    }

    public void PublishPreset()
    {
            Instructions.fontSize = InstructionAppearance.FontSize;
            Instructions.text = InstructionAppearance.TextContent;
            Instructions.font = InstructionAppearance.TextFont;
            Instructions.color = InstructionAppearance.TextColor;
    }


    public void SyncSliders()
    {
        RedSlider.value = SelectedColor.r;
        GreenSlider.value = SelectedColor.g;
        BlueSlider.value = SelectedColor.b;
    }
}
