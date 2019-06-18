using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class MenuLightController : MonoBehaviour
{

    [SerializeField]
    private Vector3[] positions;

    private int currenctIndex;
    private float moveSpeed = 5f;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime < 1.8f)
        {
            return;
        }

        LerpToPos();

        if (XCI.GetButtonDown(XboxButton.DPadDown))
        {
            NextPos();
        }

        if (XCI.GetButtonDown(XboxButton.DPadUp))
        {
            PrevPos();
        }
    }

    void NextPos()
    {
        if (currenctIndex == positions.Length - 1)
        {
            currenctIndex = 0;
        }
        else
        {
            currenctIndex++;
        }
    }

    void PrevPos()
    {
        if (currenctIndex == 0)
        {
            currenctIndex = positions.Length - 1;
        }
        else
        {
            currenctIndex--;
        }
    }

    void LerpToPos()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, positions[currenctIndex], Time.deltaTime * moveSpeed);
    }
}
