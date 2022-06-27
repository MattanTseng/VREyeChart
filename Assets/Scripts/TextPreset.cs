using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[Serializable]

public class TextPreset
{
    public int FontSize;// = 12;
    public TMP_FontAsset TextFont;
    public string TextContent;// = "ERROR";
    public Color TextColor;// = Color.red;

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

    public void NewColor(Color ColorChoice)
    {
        TextColor = ColorChoice;
    }

    public void NewFont(TMP_FontAsset FontChoice)
    {
        TextFont = FontChoice;
    }
}
