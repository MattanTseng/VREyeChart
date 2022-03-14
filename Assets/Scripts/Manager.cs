using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{

    public GameObject ChartCanvas;
    public GameObject SettingsCanvas;
    public GameObject RefreshLettersButton;
    public GameObject LetterColorsButton;
    public GameObject BackgroundColorsButton;
    public GameObject ColorButtonParent;
    public GameObject MainMenuButton;

    public Material Backround;

    public string ColorObject;
    private Vector3 TopRowRectTransform;

    public TMP_Text Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten;
    private string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    // Create empty strings to hold the text contents of the rows.
    private string Row, Row1, Row2, Row3, Row4, Row5, Row6, Row7, Row8, Row9, Row10;
    private string[] AllStrings = new string [11];
    private TMP_Text[] AllText = new TMP_Text[11];
    // These are the font sizes as determined in the google sheet file
    private int[] LetterSizes = { 45, 22, 16, 11, 9, 7, 6, 5, 4, 3, 2};

    private Vector3[] RowPositions = new Vector3[11];

    // Start is called before the first frame update
    void Start()
    {
        TopRowRectTransform = Zero.GetComponent<RectTransform>().position;
        Debug.Log("Here are the coordinates for the first row");
        Debug.Log(TopRowRectTransform);

        AllStrings[0] = Row;
        AllStrings[1] = Row1;
        AllStrings[2] = Row2;
        AllStrings[3] = Row3;
        AllStrings[4] = Row4;
        AllStrings[5] = Row5;
        AllStrings[6] = Row6;
        AllStrings[7] = Row7;
        AllStrings[8] = Row8;
        AllStrings[9] = Row9;
        AllStrings[10] = Row10;

        AllText[0] = Zero;
        AllText[1] = One;
        AllText[2] = Two;
        AllText[3] = Three;
        AllText[4] = Four;
        AllText[5] = Five;
        AllText[6] = Six;
        AllText[7] = Seven;
        AllText[8] = Eight;
        AllText[9] = Nine;
        AllText[10] = Ten;

        // Start by setting letters to black and background to white
        ColorObject = "Letters";
        ChangeColor("Black");
        ColorObject = "Background";
        ChangeColor("White");

        // Make sure the menu is on the correct page
        ToMainMenu();

        for (int q = 0; q < AllStrings.Length; q++)
        {
            RowPositions[q] = TopRowRectTransform - new Vector3(0f, 0.1f, 0f) * q;
        }

        for (int j = 0; j < AllStrings.Length; j++)
        {
            AllStrings[j] = NewLetters(j);
            Debug.Log("Updating");
            Debug.Log(AllStrings[j]);
            
        }

        for(int i = 0; i < AllText.Length; i++)
        {

            AllText[i].text = AllStrings[i];
            AllText[i].fontSize = LetterSizes[i];
            AllText[i].GetComponent<RectTransform>().position = RowPositions[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshLetters()
    {
        for (int j = 0; j < AllStrings.Length; j++)
        {
            AllStrings[j] = NewLetters(j);
            Debug.Log("Updating");
            Debug.Log(AllStrings[j]);
        }

        for (int i = 0; i < AllText.Length; i++)
        {
            AllText[i].text = AllStrings[i];
            AllText[i].fontSize = LetterSizes[i];

        }
    }

    // Function to get a string of random letters
    private string NewLetters(int strlength)
    {
        Debug.Log(strlength);

        string Row = null;
        for (int i = 0; i < strlength+1; i++)
        {
            Row += Alphabet[Random.Range(0, Alphabet.Length)].ToString();
            if(i >= 0)
            {
                Row += "  ";
            }
        }
        return Row;
    }

    public void LetterColorMenu()
    {
        ColorObject = "Letters";
        RefreshLettersButton.SetActive(false);
        LetterColorsButton.SetActive(false);
        BackgroundColorsButton.SetActive(false);
        MainMenuButton.SetActive(true);
        ColorButtonParent.SetActive(true);
    }

    public void BackgroundColorMenu()
    {
        // This state will be used to determine which colors to edit
        ColorObject = "Background";
        // Now hide the other menu buttons
        RefreshLettersButton.SetActive(false);
        LetterColorsButton.SetActive(false);
        BackgroundColorsButton.SetActive(false);
        MainMenuButton.SetActive(true);
        ColorButtonParent.SetActive(true);
        ColorButtonParent.transform.GetChild(0).gameObject.SetActive(true);
        
    }
    
    public void ToMainMenu()
    {
        RefreshLettersButton.SetActive(true);
        LetterColorsButton.SetActive(true);
        BackgroundColorsButton.SetActive(true);
        MainMenuButton.SetActive(false);
        ColorButtonParent.SetActive(false);
    }

    public void ChangeColor(string ColorInput)
    {
        float R;
        float G;
        float B;
        float A;
        Color materialColor = Color.black;

        if(ColorInput == "Red")
        {
            Debug.Log("RED");
            R = 255f;
            G = 0f;
            B = 0f;
            A = 255f;
            materialColor = Color.red;

            
        }

        else if(ColorInput == "Green")
        {
            Debug.Log("GREEN");
            R = 0f;
            G = 255f;
            B = 0f;
            A = 255f;
            materialColor = Color.green;
        }

        else if(ColorInput == "Blue")
        {
            Debug.Log("BLUE");
            R = 0f;
            G = 0f;
            B = 255f;
            A = 255f;
            materialColor = Color.blue;
        }
        else if(ColorInput == "Black")
        {
            Debug.Log("BLACK");
            R = 0f;
            G = 0f;
            B = 0f;
            A = 255f;
            materialColor = Color.black;
        }

        else if(ColorInput == "White")
        {
            Debug.Log("WHITE");
            R = 255f;
            G = 255f;
            B = 255f;
            A = 255f;
            materialColor = Color.white;
        }
        else if (ColorInput == "Yellow")
        {
            Debug.Log("YELLOW");
            R = 255f;
            G = 255f;
            B = 0f;
            A = 255f;
            materialColor = Color.yellow;
        }

        else
        {
            // Default to black
            R = 0f;
            G = 0f;
            B = 0f;
            A = 255f;
        }
        string WhichColor = ColorObject;

        if(WhichColor == "Letters")
        {
            for(int i = 0; i<AllText.Length; i++)
            {
                AllText[i].color = new Color(R, G, B, A);
            }
        }

        else if(WhichColor == "Background")
        {
            // Decrease our alpha channel to reduce brightness
            A = 100f;
            Backround.SetColor("_Color", materialColor);
        }
        else
        {
            Debug.Log("I don't know what color you want to change");
        }
    }
}
