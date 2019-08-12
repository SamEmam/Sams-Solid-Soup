using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenCubeMaster : MonoBehaviour
{
    public List<LoadingScreenCubeController> cubes;
    public float stepTime = 1f;
    public int index = 0;
    private int maxIndex;

    private void Start()
    {
        maxIndex = cubes[0].positions.Count - 1;
        StartCoroutine(NextStep());
    }

    IEnumerator NextStep()
    {
        while (true)
        {
            if (index == maxIndex)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            foreach (var cube in cubes)
            {
                cube.MoveToNextPosition(index);
            }

            yield return new WaitForSeconds(stepTime);
        }
    }
}
