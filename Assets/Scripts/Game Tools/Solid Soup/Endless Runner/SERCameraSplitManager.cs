using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SERCameraSplitManager : MonoBehaviour
{
    public Camera[] cams;
    private List<Camera> camList = new List<Camera>();

    private void Start()
    {
        foreach (var cam in cams)
        {
            if (cam.gameObject.activeInHierarchy)
            {
                camList.Add(cam);
            }
        }

        SetCams();
    }

    void SetCams()
    {
        if (camList.Count == 8)
        {
            camList[0].rect = new Rect(0.00f, 0.5f, 0.25f, 0.5f);
            camList[1].rect = new Rect(0.25f, 0.5f, 0.25f, 0.5f);
            camList[2].rect = new Rect(0.50f, 0.5f, 0.25f, 0.5f);
            camList[3].rect = new Rect(0.75f, 0.5f, 0.25f, 0.5f);

            camList[4].rect = new Rect(0.00f, 0.0f, 0.25f, 0.5f);
            camList[5].rect = new Rect(0.25f, 0.0f, 0.25f, 0.5f);
            camList[6].rect = new Rect(0.50f, 0.0f, 0.25f, 0.5f);
            camList[7].rect = new Rect(0.75f, 0.0f, 0.25f, 0.5f);
        }
        else if (camList.Count == 7)
        {
            camList[0].rect = new Rect(0.00f, 0.5f, 0.25f, 0.5f);
            camList[1].rect = new Rect(0.25f, 0.5f, 0.25f, 0.5f);
            camList[2].rect = new Rect(0.50f, 0.5f, 0.25f, 0.5f);
            camList[3].rect = new Rect(0.75f, 0.5f, 0.25f, 0.5f);

            camList[4].rect = new Rect(0.0000f, 0.0f, 0.3333f, 0.5f);
            camList[5].rect = new Rect(0.3333f, 0.0f, 0.3333f, 0.5f);
            camList[6].rect = new Rect(0.6666f, 0.0f, 0.3333f, 0.5f);
        }
        else if (camList.Count == 6)
        {
            camList[0].rect = new Rect(0.0000f, 0.5f, 0.3333f, 0.5f);
            camList[1].rect = new Rect(0.3333f, 0.5f, 0.3333f, 0.5f);
            camList[2].rect = new Rect(0.6666f, 0.5f, 0.3333f, 0.5f);

            camList[3].rect = new Rect(0.0000f, 0.0f, 0.3333f, 0.5f);
            camList[4].rect = new Rect(0.3333f, 0.0f, 0.3333f, 0.5f);
            camList[5].rect = new Rect(0.6666f, 0.0f, 0.3333f, 0.5f);
        }
        else if (camList.Count == 5)
        {
            camList[0].rect = new Rect(0.0000f, 0.5f, 0.3333f, 0.5f);
            camList[1].rect = new Rect(0.3333f, 0.5f, 0.3333f, 0.5f);
            camList[2].rect = new Rect(0.6666f, 0.5f, 0.3333f, 0.5f);

            camList[3].rect = new Rect(0.0f, 0.0f, 0.5f, 0.5f);
            camList[4].rect = new Rect(0.5f, 0.0f, 0.5f, 0.5f);
        }
        else if (camList.Count == 4)
        {
            camList[0].rect = new Rect(0.0f, 0.5f, 0.5f, 0.5f);
            camList[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            camList[2].rect = new Rect(0.0f, 0.0f, 0.5f, 0.5f);
            camList[3].rect = new Rect(0.5f, 0.0f, 0.5f, 0.5f);
        }
        else if (camList.Count == 3)
        {
            camList[0].rect = new Rect(0.0f, 0.5f, 0.5f, 0.5f);
            camList[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            camList[2].rect = new Rect(0.0f, 0.0f, 1.0f, 0.5f);
        }
        else if (camList.Count == 2)
        {
            camList[0].rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
            camList[1].rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
        }
        else
        {
            camList[0].rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        }
    }
}
