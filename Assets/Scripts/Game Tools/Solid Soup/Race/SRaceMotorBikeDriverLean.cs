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

    private float leanSpeed = 3f;

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

        var spineTargetPos = new Vector3(spineStartPos.x, spineYpos, spineStartPos.z);
        var spineTargetRot = Quaternion.Euler(new Vector3(spineXrot, spineStartRot.y, spineStartRot.z));
        var neckTargetRot = Quaternion.Euler(new Vector3(neckXrot, neckYrot - 30, neckStartRot.z));

        spine.localPosition = Vector3.Lerp(spine.localPosition, spineTargetPos, Time.deltaTime * leanSpeed);
        spine.localRotation = Quaternion.Lerp(spine.localRotation, spineTargetRot, Time.deltaTime * leanSpeed);
        neck.localRotation = Quaternion.Lerp(neck.localRotation, neckTargetRot, Time.deltaTime * leanSpeed);

        //spine.localPosition = new Vector3(spineStartPos.x, spineYpos, spineStartPos.z);
        //spine.localRotation = Quaternion.Euler(new Vector3(spineXrot, spineStartRot.y, spineStartRot.z));
        //neck.localRotation = Quaternion.Euler(new Vector3(neckXrot, neckYrot - 30, neckStartRot.z));
        
    }
    
    // spine1 position.y (3.726 -> 0.25)
    // spine1 rotation.x (0 -> 15)

    // neck rotation.x (0 -> 15)
}
