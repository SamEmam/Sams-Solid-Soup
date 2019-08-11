using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenCubeController : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public int index = 0;
    private Vector3 prevPos, curPos;

    private void Start()
    {
        transform.position = Vector3.Lerp(prevPos, curPos, Time.deltaTime);
    }

    void MoveToNextPosition()
    {
        if (index == positions.Count - 1)
        {
            index = 0;
            prevPos = positions[positions.Count - 1];
            curPos = positions[index];
        }
        else
        {
            index++;
        }
    }
}
