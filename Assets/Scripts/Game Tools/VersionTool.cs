using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionTool : MonoBehaviour
{
    public TextMeshProUGUI versionText;
    public string _version;

    // Start is called before the first frame update
    void Start()
    {
        if (_version != "")
        {
            UpdateVersion(_version);
        }
        else
        {
            _version = PlayerPrefs.GetString("version");
        }
    }

    void UpdateVersion(string version) 
    {
        PlayerPrefs.SetString("version", version);
        _version = version;
        versionText.text = _version;
    }
}
