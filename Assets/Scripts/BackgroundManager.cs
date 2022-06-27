using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    public GameObject MenuManagerObject;
    private MenuManager MenuManagerScript;

    public Material BackgroundMaterial;
    public Material InstructionMaterial;

    // Start is called before the first frame update
    void Start()
    {
        MenuManagerScript = MenuManagerObject.GetComponent<MenuManager>();
        // make sure that the background starts as white
        BackgroundMaterial.SetColor("_Color", Color.white);
    }

    public void BackgroundRed()
    {
        if(MenuManagerScript.ColorObject == "Background")
        {
            Debug.Log("Background to red");
            BackgroundMaterial.SetColor("_Color", Color.red);
        }
    }

    public void BackgroundGreen()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {

            BackgroundMaterial.SetColor("_Color", Color.green);
        }
    }

    public void BackgroundBlue()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {

            BackgroundMaterial.SetColor("_Color", Color.blue);
        }
    }

    public void BackgroundBlack()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {

            BackgroundMaterial.SetColor("_Color", Color.black);
        }
    }

    public void BackgroundWhite()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {

            BackgroundMaterial.SetColor("_Color", Color.white);
        }
    }

    public void BackgroundYellow()
    {
        if (MenuManagerScript.ColorObject == "Background")
        {

            BackgroundMaterial.SetColor("_Color", Color.yellow);
        }
    }

    public void UpdateInstructionBackground()
    {
        InstructionMaterial = BackgroundMaterial;
    }


}
