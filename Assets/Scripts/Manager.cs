using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{

    public GameObject ChartCanvas;
    public GameObject SettingsCanvas;
    public GameObject ToMenuButton;
    public GameObject ToGameButton;

    public TMP_Text Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten;
    private string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    // Create empty strings to hold the text contents of the rows.
    private string Row, Row1, Row2, Row3, Row4, Row5, Row6, Row7, Row8, Row9, Row10;
    private string[] AllStrings = new string [11];
    private TMP_Text[] AllText = new TMP_Text[11];
    // These are the font sizes as determined in the google sheet file
    private int[] LetterSizes = { 44, 22, 16, 11, 9, 7, 6, 5, 4, 3, 2};


    // Start is called before the first frame update
    void Start()
    {
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
