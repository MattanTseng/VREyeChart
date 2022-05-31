using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class IndicatorManager : MonoBehaviour
{
    public GameObject IndicatorArrow;
    public GameObject RowParent;
    public Transform[] RowTransforms;
    public Vector3 OldPosition;
    public Vector3[] RowPositions;
    public int SelectedRow;
    public TMP_Dropdown RowDropDown;

    private int NumChild;


    private void Start()
    {
        NumChild = RowParent.transform.childCount;
        Debug.Log("Child count");
        Debug.Log(NumChild);

        RowTransforms = new Transform[NumChild];

        Debug.Log("Length of RowTransformations");
        Debug.Log(RowTransforms.Length);

        for (int i = 0; i < NumChild; i++)
        {
            RowTransforms[i] = RowParent.transform.GetChild(i);
            Debug.Log(RowTransforms[i]);
        }



        // get the current position of the indicator
        OldPosition = IndicatorArrow.GetComponent<RectTransform>().position;
    }

    public void UpdateIndicator()
    {
        Debug.Log("Moving Indicator");
        Debug.Log(RowDropDown.value);
        Vector3 NewPosition;
        if(RowDropDown.value != SelectedRow)
        {
            SelectedRow = RowDropDown.value;
        }

        NewPosition = RowTransforms[SelectedRow].position;

        // check the input value agains the current position. 
        // move the indicator if there is a change.
        if(NewPosition != OldPosition)
        {
            OldPosition = NewPosition + new Vector3(0.1f, 0f, 0f);
            IndicatorArrow.GetComponent<RectTransform>().position = OldPosition;
        }
    }

    public void ThisIsATest2()
    {
        Debug.Log("This is a test");
    }
}
