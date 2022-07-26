using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public string ColorObject = "Letters";
    public GameObject RefreshLettersButton;
    public GameObject LetterColorsButton;
    public GameObject BackgroundColorsButton;
    public GameObject MainMenuButton;
    public GameObject ColorButtonParent;
    public GameObject FontSelectionButton;
    public GameObject FontButtonParent;

    private void Start()
    {
        ToMainMenu();
    }

    // The letter color menu and background color menu are basically the same thing. 
    // The only difference is that each function changes the value of the color object string. 
    // The value of the colorobject determines what the color buttons modify.
    // Go to the menu that has the color options

    // This is where the user can change the color of the text
    public void LetterColorMenu()
    {

        ColorObject = "Letters";
        FontSelectionButton.SetActive(false);
        RefreshLettersButton.SetActive(false);
        LetterColorsButton.SetActive(false);
        BackgroundColorsButton.SetActive(false);
        MainMenuButton.SetActive(true);
        ColorButtonParent.SetActive(true);
        FontButtonParent.SetActive(false);
    }

    // This is where the user can change the color of the background
    public void BackgroundColorMenu()
    {
        FontSelectionButton.SetActive(false);

        // This state will be used to determine which colors to edit
        ColorObject = "Background";
        // Now hide the other menu buttons
        RefreshLettersButton.SetActive(false);
        LetterColorsButton.SetActive(false);
        BackgroundColorsButton.SetActive(false);
        MainMenuButton.SetActive(true);
        ColorButtonParent.SetActive(true);
        ColorButtonParent.transform.GetChild(0).gameObject.SetActive(true);
        FontButtonParent.SetActive(false);

    }

    // this is where the user can select the font
    public void FontSelectionMenu()
    {

        FontSelectionButton.SetActive(false);

        // This state will be used to determine which colors to edit
        // Now hide the other menu buttons
        RefreshLettersButton.SetActive(false);
        LetterColorsButton.SetActive(false);
        BackgroundColorsButton.SetActive(false);
        MainMenuButton.SetActive(true);
        FontButtonParent.SetActive(true);
    }

    // Return the user to the main menu
    public void ToMainMenu()
    {
        FontSelectionButton.SetActive(true);

        RefreshLettersButton.SetActive(true);
        LetterColorsButton.SetActive(true);
        BackgroundColorsButton.SetActive(true);
        MainMenuButton.SetActive(false);
        ColorButtonParent.SetActive(false);
        FontButtonParent.SetActive(false);
    }
}
