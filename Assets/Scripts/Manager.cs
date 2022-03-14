using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    // The canvas that has the snellen chart and drop down menu
    public GameObject ChartCanvas;
    // The canvas that has the menu and color change options
    public GameObject SettingsCanvas;
    // The button that refreshes the letter content
    public GameObject RefreshLettersButton;
    // The button that opens the color menu for the letters
    public GameObject LetterColorsButton;
    // The button that opens the color menu for the background
    public GameObject BackgroundColorsButton;
    // The parent that holds all of the color buttons
    public GameObject ColorButtonParent;
    // The button to return to the main menu
    public GameObject MainMenuButton;
    // The image that indicates which row is selected
    public GameObject RowIndicator;
    // The drop down menu used to select the row (on the chartcanvas)
    public TMP_Dropdown RowDropDown;
    // The material asset that is used to color the chart background
    public Material Backround;
    // A string that will be used to call for different color changes
    public string ColorObject;
    // The value returned by the drop down menu
    public int SelectedRow;
    // The position of the top text vector
    private Vector3 TopRowRectTransform;

    // Text Objects that correspond to the different chart rows.
    public TMP_Text Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten;
    // This string will be broken up to obtain our random letters
    private string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    // Create empty strings to hold the text contents of the rows.
    private string Row, Row1, Row2, Row3, Row4, Row5, Row6, Row7, Row8, Row9, Row10;
    // These empty lists will be filled with the strings and text objects that make up our chart
    private string[] AllStrings = new string [11];
    private TMP_Text[] AllText = new TMP_Text[11];
    // These are the font sizes as determined in the google sheet
    private int[] LetterSizes = { 45, 22, 16, 11, 9, 7, 6, 5, 4, 3, 2};

    private Vector3[] RowPositions = new Vector3[11];

    // Start is called before the first frame update
    void Start()
    {
        // get the value from the drop down menu
        SelectedRow = RowDropDown.value;
        // get the position of the top row of the snellen chart
        TopRowRectTransform = Zero.GetComponent<RectTransform>().position;

        // Fill up our list of strings. This is the actual text content of each row on the chart
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

        // Fill up the list of text objects. These are where we are going to display our text
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

        // Make sure the indicator is in the correct position
        RefreshIndicator();

        // Create a list of positions referenced from the top row and iterating down.
        for (int q = 0; q < AllStrings.Length; q++)
        {
            RowPositions[q] = TopRowRectTransform - new Vector3(0f, 0.1f, 0f) * q;
            AllText[q].GetComponent<RectTransform>().position = RowPositions[q];
        }


        // give each row values and letters
        RefreshLetters();
    }

    // Update is called once per frame
    void Update()
    {
        // if the user changes which row is selected, move the arrow
        if (RowDropDown.value != SelectedRow)
        {
            RefreshIndicator();
        }
    }

    // This function checks the value of the dropdown and moves the indicator to the correct row.
    private void RefreshIndicator()
    {
        // update index
        SelectedRow = RowDropDown.value;
        // Use that index to get a value for a position that was previously determined
        Vector3 IndicatorPosition = RowPositions[SelectedRow] + new Vector3(0.1f, 0f, 0f);
        // Move to that position
        RowIndicator.GetComponent<RectTransform>().position = IndicatorPosition;
    }


    // This function takes a list of strings and applies them to all of our text rows
    public void RefreshLetters()
    {
        // Update the list of strings
        for (int j = 0; j < AllStrings.Length; j++)
        {
            AllStrings[j] = NewLetters(j);
        }

        // Apply these new strings to our rows.
        for (int i = 0; i < AllText.Length; i++)
        {
            AllText[i].text = AllStrings[i];
            AllText[i].fontSize = LetterSizes[i];

        }
    }

    // This function returns a string of n random characters
    private string NewLetters(int strlength)
    {
        // The passed int will tell the function how many characters to include
        string Row = null;
        for (int i = 0; i < strlength+1; i++)
        {
            Row += Alphabet[Random.Range(0, Alphabet.Length)].ToString();
            // If there is more than one character then insert a "  " inbetween the characters
            if(i >= 0)
            {
                Row += "  ";
            }
        }
        // Function outputs the string value
        return Row;
    }

    // The letter color menu and background color menu are basically the same thing. 
    // The only difference is that each function changes the value of the color object string. 
    // The value of the colorobject determines what the color buttons modify.
    // Go to the menu that has the color options
    public void LetterColorMenu()
    {
        ColorObject = "Letters";
        RefreshLettersButton.SetActive(false);
        LetterColorsButton.SetActive(false);
        BackgroundColorsButton.SetActive(false);
        MainMenuButton.SetActive(true);
        ColorButtonParent.SetActive(true);
    }

    // go to the menu that has the color options.
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
    
    // go to the main menu page
    public void ToMainMenu()
    {
        RefreshLettersButton.SetActive(true);
        LetterColorsButton.SetActive(true);
        BackgroundColorsButton.SetActive(true);
        MainMenuButton.SetActive(false);
        ColorButtonParent.SetActive(false);
    }

    // This function will be called for all the color buttons
    // Each button passes a string to the function. 
    // The value of the string determines the output color. 
    // The value of the ColorObject determines which item changes color
    public void ChangeColor(string ColorInput)
    {
        // Define some empty variables
        float R;
        float G;
        float B;
        float A;
        // Default the background color to white
        Color materialColor = Color.white;

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
        // What object are we changing?
        string WhichColor = ColorObject;

        if(WhichColor == "Letters")
        {
            // iterate through all of our text objects and update their color
            for(int i = 0; i<AllText.Length; i++)
            {
                AllText[i].color = new Color(R, G, B, A);
            }
        }

        else if(WhichColor == "Background")
        {

            // Change the material being used for the background
            Backround.SetColor("_Color", materialColor);
        }
        else
        {
            // This is bad.... hopefully this doesn't ever run.
            Debug.Log("I don't know what color you want to change");
        }
    }
}
