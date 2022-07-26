using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// The indicator manager shows the user which text line they have selected.

public class IndicatorManager : MonoBehaviour
{
    public GameObject IndicatorArrow;
    public GameObject RowParent;
    public Transform[] RowTransforms;
    public Vector3 OldPosition;
    public int SelectedRow;
    public TMP_Dropdown RowDropDown;

    private int NumChild;

    private TextManager GameTextManager;
    private BackgroundManager GameBackgroundManager;

    

    private void Start()
    {
        GameTextManager = this.GetComponent<TextManager>();
        GameBackgroundManager = this.GetComponent<BackgroundManager>();
        // The number of children corresponds to the number of positions that we will need.
        NumChild = RowParent.transform.childCount;

        // Make Row transforms have the right number of entries.
        RowTransforms = new Transform[NumChild];

        for (int i = 0; i < NumChild; i++)
        {
            RowTransforms[i] = RowParent.transform.GetChild(i);
            Debug.Log(RowTransforms[i]);
        }

        // get the current position of the indicator
        OldPosition = IndicatorArrow.GetComponent<RectTransform>().position;
    }

    // this method is run when there is a change to the drop down value in the application
    public void UpdateIndicator()
    {
        Vector3 NewPosition;
        GameTextManager.UpdateInstructionStyle();
        GameTextManager.PublishPreset();
        GameBackgroundManager.UpdateInstructionBackground();
        if (RowDropDown.value != SelectedRow)
        {
            // update which row is being selected.
            SelectedRow = RowDropDown.value;
            GameTextManager.SelectedRow = SelectedRow;

        }

        // use the array of row positions that we found and go to the nth entry
        NewPosition = RowTransforms[SelectedRow].position;

        // check the input value agains the current position. 
        // move the indicator if there is a change.
        if(NewPosition != OldPosition)
        {
            // The x value neds to be offset so that it is not on top of the letters
            OldPosition = NewPosition + new Vector3(0.15f, 0f, 0f);
            // move the indicator to the new location
            IndicatorArrow.GetComponent<RectTransform>().position = OldPosition;
        }
    }
}
