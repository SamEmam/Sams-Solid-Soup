using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCaravanConnector : MonoBehaviour
{
    public MeshRenderer[] meshes;
    public Material[] colors;
    private int playerNum;
    private RVehicleTypeSelector typeSelector;
    private GameObject vehicle;
    private CharacterJoint joint;

    private void OnEnable()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return null;
        
        typeSelector = GetComponentInParent<RVehicleTypeSelector>();
        vehicle = typeSelector.GetVehicle();
        joint = GetComponent<CharacterJoint>();
        joint.connectedBody = vehicle.GetComponent<Rigidbody>();
        transform.SetParent(vehicle.transform);
        playerNum = vehicle.GetComponent<RPlayerScore>().playerNum;
        GetColor();
    }

    void GetColor()
    {
        switch (playerNum)
        {
            case 1:
                SetColors(colors[(int)GamePrefs.P1Color]);
                break;
            case 2:
                SetColors(colors[(int)GamePrefs.P2Color]);
                break;
            case 3:
                SetColors(colors[(int)GamePrefs.P3Color]);
                break;
            case 4:
                SetColors(colors[(int)GamePrefs.P4Color]);
                break;
            case 5:
                SetColors(colors[(int)GamePrefs.P5Color]);
                break;
            case 6:
                SetColors(colors[(int)GamePrefs.P6Color]);
                break;
            case 7:
                SetColors(colors[(int)GamePrefs.P7Color]);
                break;
            case 8:
                SetColors(colors[(int)GamePrefs.P8Color]);
                break;
        }
    }

    void SetColors(Material playerMaterial)
    {
        foreach (var mesh in meshes)
        {
            var tempMesh = mesh.materials;
            for (int i = 0; i < tempMesh.Length; i++)
            {
                if (tempMesh[i].name == "stone (Instance)")
                {
                    tempMesh[i] = playerMaterial;
                }
            }
            mesh.materials = tempMesh;
        }
    }
}
