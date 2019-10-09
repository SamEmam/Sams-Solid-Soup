using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRaceMotorBikeDriverLean : MonoBehaviour
{
    private int playerNum;
    public Player player;

    [SerializeField]
    private Transform spine, neck;
    private Vector3 spineStartPos, spineStartRot, neckStartRot;
    private Rigidbody rb;

    private float maxSpinePosShift = 0.2f;
    private float maxSpineRotShift = 15f;
    private float maxNeckRotShift = 5f;
    private float maxNeckPitchShift = 1f;

    private void Start()
    {
        playerNum = GetComponent<RPlayerScore>().playerNum;
        player = ReInput.players.GetPlayer(playerNum);
        rb = GetComponent<Rigidbody>();

        spineStartPos = spine.localPosition;
        spineStartRot = spine.localRotation.eulerAngles;
        neckStartRot = neck.localRotation.eulerAngles;
    }

    private void Update()
    {
        float spineYpos = player.GetAxis("Turn") * maxSpinePosShift * (rb.velocity.magnitude / 50);
        float spineXrot = player.GetAxis("Turn") * maxSpineRotShift * (rb.velocity.magnitude / 50);
        float neckXrot = player.GetAxis("Turn") * maxNeckRotShift * (rb.velocity.magnitude / 50);
        float neckYrot = player.GetAxis("Turn") * maxNeckPitchShift * (rb.velocity.magnitude / 50);

        spineYpos = Mathf.Clamp(spineYpos, -maxSpinePosShift, maxSpinePosShift);
        spineXrot = Mathf.Clamp(spineXrot, -maxSpineRotShift, maxSpineRotShift);
        neckXrot = Mathf.Clamp(neckXrot, -maxNeckRotShift, maxNeckRotShift);
        neckYrot = Mathf.Clamp(neckYrot, -maxNeckPitchShift, maxNeckPitchShift);
        neckYrot = -1 * Mathf.Abs(neckYrot);

        spine.localPosition = new Vector3(spineStartPos.x, spineYpos, spineStartPos.z);
        spine.localRotation = Quaternion.Euler(new Vector3(spineXrot, spineStartRot.y, spineStartRot.z));
        neck.localRotation = Quaternion.Euler(new Vector3(neckXrot, neckYrot - 30, neckStartRot.z));

        //Vector3 leanX = new Vector3(transform.localRotation.eulerAngles.z, 0, 0);
        //Vector3 leanY = new Vector3(0, transform.localRotation.eulerAngles.z, 0);
        //Vector3 posLean = spineStartPos;
        //Vector3 rotLean = spineStartRot;
        //posLean.y += transform.localRotation.eulerAngles.z / 10;
        //rotLean.x += transform.localRotation.eulerAngles.z / 3;

        //posLean.y = Mathf.Clamp(posLean.y, -0.2f, 0.2f);
        //rotLean.x = Mathf.Clamp(rotLean.x, -10f, 10f);

        //float speed = 5f;

        //Vector3.Lerp(spine.localPosition, posLean, Time.deltaTime * speed);
        //Debug.Log("localPos:" + spine.localPosition + " poslean:" + posLean);

        //Quaternion.Lerp(spine.localRotation, Quaternion.Euler(rotLean), Time.deltaTime * speed);
        //Quaternion.Lerp(neck.localRotation, Quaternion.Euler(rotLean), Time.deltaTime * speed);
    }
    
    // spine1 position.y (3.726 -> 0.25)
    // spine1 rotation.x (0 -> 15)

    // neck rotation.x (0 -> 15)
}
