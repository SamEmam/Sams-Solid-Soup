using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPointsBarMaster : MonoBehaviour
{
    public SPointsBar[] bars;
    private int maxPoints;

    private void LateUpdate()
    {
        var tempMax = maxPoints;

        GetNewMax();

        if (tempMax != maxPoints)
        {
            SetNewMax();
        }
        
    }

    void GetNewMax()
    {
        foreach (var bar in bars)
        {
            if (maxPoints < bar.currentValue)
            {
                maxPoints = bar.currentValue;
            }
        }
    }

    void SetNewMax()
    {
        foreach (var bar in bars)
        {
            bar.UpdateMax(maxPoints);
        }
    }
}
