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

    private void Start()
    {
        ToMainMenu();
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
}
