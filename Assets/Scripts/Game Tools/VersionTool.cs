using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionTool : MonoBehaviour
{
    public TextMeshProUGUI versionText;
    public string _version;
    public bool readFromPrefs = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!readFromPrefs)
        {
            UpdateVersion(_version);
        }
        else
        {
            versionText.text = PlayerPrefs.GetString("version");
        }
    }

    void UpdateVersion(string version) 
    {
        PlayerPrefs.SetString("version", version);
        _version = version;
        versionText.text = _version;
    }
}
