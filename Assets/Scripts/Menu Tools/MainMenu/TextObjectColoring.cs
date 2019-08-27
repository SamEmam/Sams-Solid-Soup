using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObjectColoring : MonoBehaviour
{
    [SerializeField]
    private Material mat;

    [SerializeField]
    private GameObject[] letters;

    [SerializeField]
    private HandleEnum handleEnum;

    [SerializeField]
    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        ColorLetters(letters, mat);
    }

    void ColorLetters(GameObject[] letters, Material material)
    {
        foreach (GameObject letter in letters)
        {
            letter.GetComponent<MeshRenderer>().material = material;
        }
    }

    public void TriggerColoring()
    {
        ColorLetters(letters, mat);
    }

    public void SetMat(Material material)
    {
        mat = material;
        TriggerColoring();
    }

    public Material GetMat()
    {
        return mat;
    }

    public void SwitchScene()
    {
        StartCoroutine(SelectedHandle());
    }

    public IEnumerator SelectedHandle()
    {
        yield return new WaitForSeconds(2f);

        switch (handleEnum)
        {
            case HandleEnum.local:
                sceneLoader.LoadSceneByIndex(1);
                break;
            case HandleEnum.online:
                sceneLoader.LoadSceneByIndex(1);
                break;
            case HandleEnum.options:
                sceneLoader.LoadSceneByIndex(1);
                break;
            case HandleEnum.exit:
                Application.Quit();
                break;
        }
    }
}

public enum HandleEnum
{
    local,
    online,
    options,
    exit
}
