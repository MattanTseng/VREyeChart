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
    //private TextPreset[] TextPresets;


    private void Start()
    {

        TextPreset[] TextPresets = new TextPreset[RowObjects.Length];
        CanvasScale = TextCanvas.GetComponent<RectTransform>().localScale;
        // In order for the math to work, the y and x scales of the canvas must be equal

        if(CanvasScale.x != CanvasScale.y)
        {
            Debug.Log("WARNING: Canvas is not scaled correctly. Must be a square.");
        }

        // Create a list of strings that increases by 1 letter
        ChartContent = NewStringContent(RowObjects.Length);

        // creates a list of integers to be used as the font size of the letters.
        FontSizes = this.GetComponent<PxCalculator>().CalculatePx(Distances, CanvasScale);

        TextPresets = UpdateChart(FontSizes, SelectedFont, ChartContent, SelectedColor);

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
        for(int i = 0; i < Content.Length; i++)
        {
            NewChart[i] = UpdateRow(Size[i], Font, Content[i], color);
        }
        return NewChart;
    }
    //Update text content in whole chart
    public TextPreset[] UpdateChartContent(string[] Content)
    {
        TextPreset[] NewChart = new TextPreset[Content.Length];
        for (int i = 0; i < Content.Length; i++)
        {
            NewChart[i] = UpdateRowContent(Content[i]);
        }
        return NewChart;
    }

    private void PublishChartClass(TextPreset[] Preset, TMP_Text[] Row)
    {
        // publish the information in the text class so that the user can see it.
        for(int i =0; i < Preset.Length; i++)
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
            TextContent[i-1] = row;

        }

        // Return a list of n strings
        return TextContent;
    }
}
