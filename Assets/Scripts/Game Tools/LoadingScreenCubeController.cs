using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenCubeController : MonoBehaviour
{
    public List<Vector3> positions;
    private Vector3 targetPos;
    private int speed = 5;

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, speed * Time.deltaTime);
    }

    public void MoveToNextPosition(int index)
    {
        targetPos = positions[index];
    }
}
