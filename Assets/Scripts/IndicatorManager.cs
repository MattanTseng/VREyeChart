using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    public Vector3 OldPosition;

    private void Start()
    {
        // get the current position of the indicator
        OldPosition = this.GetComponent<RectTransform>().position;
    }

    public void RefreshIndicator(Vector3 NewPosition)
    {
        // check the input value agains the current position. 
        // move the indicator if there is a change.
        if(NewPosition != OldPosition)
        {
            OldPosition = NewPosition + new Vector3(0.1f, 0f, 0f);
            this.GetComponent<RectTransform>().position = OldPosition;
        }
    }
}
