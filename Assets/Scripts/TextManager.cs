using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextManager : MonoBehaviour
{
    public GameObject TextCanvas;
    public TMP_FontAsset SelectedFont;
    public Color SelectedColor;
    public TMP_Text[] RowObjects;
    public int[] Distances;


    private Vector3 CanvasScale;
    private string[] ChartContent;
    private int[] FontSizes;
    private TextPreset[] TextPresets;
    


    private void Start()
    {
        CanvasScale = TextCanvas.GetComponent<RectTransform>().localScale;
        // In order for the math to work, the y and x scales of the canvas must be equal
        if(CanvasScale.x != CanvasScale.y)
        {
            Debug.Log("WARNING: Canvas MUST be a square");
        }

        // Create a list of strings that increases by 1 letter
        ChartContent = NewStringContent(RowObjects.Length);
        // creates a list of integers to be used as the font size of the letters.
        FontSizes = this.GetComponent<PxCalculator>().CalculatePx(Distances, CanvasScale);
        UpdateTextClass(TextPresets, FontSizes, SelectedFont, ChartContent, SelectedColor);
        PublishChartClass(TextPresets, RowObjects);
    
    
    }

    public void UpdateTextClass(TextPreset[] Preset, int[] Size, TMP_FontAsset Font, string[] Content, Color TextColor)
    {
        for(int i = 0; i < Preset.Length; i++)
        {
            // send information to the class.
            Preset[i].FontSize = Size[i];
            Preset[i].TextFont = Font;
            Preset[i].TextContent = Content[i];
            Preset[i].TextColor = SelectedColor;
        }
    }

    public void PublishChartClass(TextPreset[] Preset, TMP_Text[] TextObjs)
    {
        // publish the information in the text class so that the user can see it.
        for(int i =0; i < Preset.Length; i++)
        {
            TextObjs[i].fontSize = Preset[i].FontSize;
            TextObjs[i].text = Preset[i].TextContent;
            TextObjs[i].font = Preset[i].TextFont;
            TextObjs[i].color = Preset[i].TextColor;
        }
    }



    public string[] NewStringContent(int numRows)
    {
        string[] TextContent = new string[numRows];
        // this is the string that we will pull random letters from.
        string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for (int i = 0; i < numRows; i++)
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
            TextContent[i] = row;

        }

        // Return a list of n strings
        return TextContent;
    }
}
