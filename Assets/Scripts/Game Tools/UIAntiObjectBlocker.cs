using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAntiObjectBlocker : MonoBehaviour
{
    private List<GameObject> targets = new List<GameObject>();
    [SerializeField]
    private GameObject[] uiElements;
    private List<GameObject> uiElementsList;

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return null;

        targets = GetComponent<RCameraTargetController>().targets;

        foreach (GameObject element in uiElements)
        {
            if (element.activeInHierarchy)
            {
                uiElementsList.Add(element);
            }
        }
    }

    private void Update()
    {
        if (LinecastToTargets())
        {
            DisableUI();
        }
        else
        {
            EnableUI();
        }
    }

    bool LinecastToTargets()
    {
        for (var i = targets.Count - 1; i > -1; i--)
        {
            if (targets[i] == null)
                targets.RemoveAt(i);
        }

        RaycastHit hit;
        foreach (GameObject target in targets)
        {
            if ((Physics.Linecast(Camera.main.transform.position, target.transform.position, out hit) && hit.collider.tag == "UIBlocker"))
            {
                return true;
            }
        }
        return false;
    }

    void EnableUI()
    {
        foreach (GameObject element in uiElements)
        {
            element.SetActive(true);
        }
    }

    void DisableUI()
    {
        foreach (GameObject element in uiElements)
        {
            element.SetActive(false);
        }
    }
}
