using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenCubeController : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    private Vector3 prevPos, curPos;

    private void Update()
    {
        transform.position = Vector3.Lerp(prevPos, curPos, Time.deltaTime);
    }

    public void MoveToNextPosition(int index)
    {
        if (index == 0)
        {
            prevPos = positions[positions.Count - 1];
            curPos = positions[index];
        }
        else
        {
            prevPos = positions[index - 1];
            curPos = positions[index];
        }
    }
}
