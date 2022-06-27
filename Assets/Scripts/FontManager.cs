using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class FontManager : MonoBehaviour
{

    public TMP_FontAsset[] Fonts;


    public void ChangeFont(TextPreset[] Preset, int FontSelection){
        if(FontSelection < Fonts.Length)
        {
            foreach (TextPreset TP in Preset)
            {
                TP.NewFont(Fonts[FontSelection]);
            }
        }

        else
        {
            Debug.Log("Invalid int value entered");

        }
        

    }
}
