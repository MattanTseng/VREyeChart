using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextManager : MonoBehaviour
{
    public TMP_Text[] RowObjects;
    public TextPreset[] TextSettings;
    public TMP_Text TestText;
    public GameObject TextCanvas;

    private Vector3 CanvasScale;
    private string TextFont;

    private void Start()
    {
        CanvasScale = TextCanvas.GetComponent<RectTransform>().localScale;
        // In order for the math to work, the y and x scales of the canvas must be equal
        if(CanvasScale.x != CanvasScale.y)
        {
            Debug.Log("WARNING: Canvas is not scaled correctly.");
        }
    }

    public void GetTextInfo()
    {
        
    }

    public string[] RefreshTextContent(int numRows)
    {
        string[] TextContent;
        string Aplhabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        // Apply these new strings to our rows.
        for (int i = 0; i < numRows; i++)
        {
            

        }
        return TextContent;
    }
}
