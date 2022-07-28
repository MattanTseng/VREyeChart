using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// this class holds the information for the different rows on the chart. 
// Each row will have different characteristics depending on the size.
public class TextPreset
{
    public int FontSize;// = 12;
    public TMP_FontAsset TextFont;
    public string TextContent;// = "ERROR";
    public Color TextColor;// = Color.red;
    public float theta; // This is the veiwing angle of the preset


    //Here is the constructor for our class
    public TextPreset(int Size, TMP_FontAsset Font, string Content, Color color)
    {
        FontSize = Size;
        TextFont = Font;
        TextContent = Content;
        TextColor = color;
    }

    public TextPreset(string Content)
    {
        TextContent = Content;
    }

    public TextPreset(TextPreset Template)
    {
        FontSize = Template.FontSize;
        TextFont = Template.TextFont;
        TextContent = Template.TextContent;
        TextColor = Template.TextColor;
    }

    public void NewColor(Color ColorChoice)
    {
        TextColor = ColorChoice;
    }

    public void NewFont(TMP_FontAsset FontChoice)
    {
        TextFont = FontChoice;
    }
}
