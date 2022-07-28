using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TumblingE : MonoBehaviour
{

    public TMP_Text[] Letters;
    private int DirChoice;
    public TMP_Text Results;
    private int OldChoice =0;
    // Start is called before the first frame update
    void Start()
    {
        NewE();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewE()
    {
        OldChoice = DirChoice;
        // make sure to hide all of the leters when the application begins
        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i].enabled = false;
        }
        while (DirChoice == OldChoice) {

            DirChoice = UnityEngine.Random.Range(0, 3);
        }
        Letters[DirChoice].enabled = true;

    }

    public void CheckSelection(int Direction)
    {
        if(Direction == DirChoice)
        {
            Results.text = "Correct";
        }
        else
        {
            Results.text = "False";
        }
    }
}
