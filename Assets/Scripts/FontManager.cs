using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

/* This script is in charge of changing the font being displayed. 
 the developer will have to drag all of the font options into the script in 
the unity editor.

*/
public class FontManager : MonoBehaviour
{

    // this is where all of the possible fonts are stored.
    public TMP_FontAsset[] Fonts;


    // this is called when a new font is selected.
    // remember that the chart is made up of an array of presets. 
    // so in order to change the font of all of the presets, every font in every preset must be updated.
    public void ChangeFont(TextPreset[] Preset, int FontSelection){
       

        if(FontSelection < Fonts.Length) // verify that the font selection value is correct.
        {
            // update the font for all of the presets.
            foreach (TextPreset TP in Preset)
            {
                TP.NewFont(Fonts[FontSelection]);
            }
        }

        else
        {
            Debug.Log("Invalid int value entered: See FontManager Script");

        }
        

    }
}
