using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PxCalculator : MonoBehaviour
{
    // Enter the distance in feet
    public int[] CalculatePx(int[] distance, Vector3 CanvasScale)
    {
        float angleMin = 5f;  // How many minutes is our view angle? 
        float angleDeg = angleMin / 60;
        int[] Px = new int[distance.Length];
        for (int i = 0; i < distance.Length; i++)
        {
            float LetterHeightInches = distance[i] * 12 * Mathf.Atan(Mathf.Deg2Rad * angleDeg);
            float LetterHeightMeters = LetterHeightInches * 0.0254f;
             Px[i] = Mathf.CeilToInt(LetterHeightMeters / CanvasScale.x);
        }
        return Px;
    }
}
