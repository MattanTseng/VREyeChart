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
    private TextPreset[] TextSettings;
    private int[] FontSizes;
    private TextPreset[] TextPresets;


    private void Start()
    {
        CanvasScale = TextCanvas.GetComponent<RectTransform>().localScale;
        // In order for the math to work, the y and x scales of the canvas must be equal
        if(CanvasScale.x != CanvasScale.y)
        {
            Debug.Log("WARNING: Canvas is not scaled correctly.");
        }

        // Create a list of strings that increases by 1 letter
        ChartContent = NewStringContent(RowObjects.Length);
        // creates a list of integers to be used as the font size of the letters.
        FontSizes = this.GetComponent<PxCalculator>().CalculatePx(Distances, CanvasScale);
    }

    public void UpdateChartClass()
    {
        for(int i = 0; i < TextPresets.Length; i++)
        {
            // send information to the class.
            TextPresets[i].FontSize = FontSizes[i];
            TextPresets[i].TextFont = SelectedFont;
            TextPresets[i].TextContent = ChartContent[i];
            TextPresets[i].TextColor = SelectedColor;
        }
        
    }

    private void PublishChartClass()
    {
        // publish the information in the text class so that the user can see it.
        for(int i =0; i < TextPresets.Length; i++)
        {
            RowObjects[i].fontSize = TextPresets[i].FontSize;
            RowObjects[i].text = TextPresets[i].TextContent;
            RowObjects[i].font = TextPresets[i].TextFont;
            RowObjects[i].color = TextPresets[i].TextColor;
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
