using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSBPlayerController : MonoBehaviour
{
    public Image crosshair;
    private int playerNum;
    private float moveSpeed = 50f;
    private float fireRate = 1f;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.1f);
    [SerializeField]
    private AudioClip hitSound, missSound;
    private AudioSource shotAudio;
    private LineRenderer laserLine;
    private float nextFire;
    private Camera cam;
    public Player player;
    public GameObject explosionParticle;

    private void OnEnable()
    {
        crosshair.gameObject.SetActive(true);
    }

    private void Start()
    {
        playerNum = GetComponent<BoidController>().playerNum;
        player = ReInput.players.GetPlayer(playerNum);
        laserLine = GetComponent<LineRenderer>();
        shotAudio = GetComponent<AudioSource>();
        //cam = Camera.main;
        SetupCrosshair();
    }

    private void Update()
    {
        if (player.GetButtonDown("Shoot") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Shoot();
        }

        Move();

        float fillAmount = 1 - (nextFire - Time.time);

        if (fillAmount < 1)
        {
            crosshair.fillAmount = fillAmount;
        }
        else
        {
            crosshair.fillAmount = 1f;
        }
    }

    void Shoot()
    {

        Vector3 pos = crosshair.transform.position;
        Vector3 dir = Camera.main.transform.position - pos;
        Debug.DrawRay(pos, -dir * 30, Color.red, 100f);
        
        RaycastHit hit;
        laserLine.SetPosition(0, pos);
        laserLine.SetPosition(1, -dir * 30);
        if (Physics.Raycast(pos, -dir, out hit))
        {
            if (hit.collider != null)
            {
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                Debug.Log(hit);
                laserLine.SetPosition(1, -dir * 30);
            }
            SSBSpaceship spaceship = hit.collider.GetComponent<SSBSpaceship>();

            if (spaceship)
            {
                Debug.Log("Hit ship");
                Instantiate(explosionParticle, spaceship.transform.position, spaceship.transform.rotation);
                spaceship.KillSpaceship(playerNum);
                shotAudio.clip = hitSound;
                shotAudio.Play();
            }
            else
            {
                shotAudio.clip = missSound;
                shotAudio.Play();
            }
        }
    }

    IEnumerator ShotEffect()
    {

        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }

    void Move()
    {
        float h = player.GetAxis("Turn");
        float v = player.GetAxis("Pitch") * - 1;
        Vector3 pos = crosshair.rectTransform.localPosition;
        pos.x += h * moveSpeed * Time.deltaTime;
        pos.y += v * moveSpeed * Time.deltaTime;
        crosshair.rectTransform.localPosition = pos;
    }

    void SetupCrosshair()
    {
        switch (playerNum)
        {
            case 1:
                SetCrosshairColor((int)GamePrefs.P1Color);
                break;
            case 2:
                SetCrosshairColor((int)GamePrefs.P2Color);
                break;
            case 3:
                SetCrosshairColor((int)GamePrefs.P3Color);
                break;
            case 4:
                SetCrosshairColor((int)GamePrefs.P4Color);
                break;
            case 5:
                SetCrosshairColor((int)GamePrefs.P5Color);
                break;
            case 6:
                SetCrosshairColor((int)GamePrefs.P6Color);
                break;
            case 7:
                SetCrosshairColor((int)GamePrefs.P7Color);
                break;
            case 8:
                SetCrosshairColor((int)GamePrefs.P8Color);
                break;

        }
    }

    void SetCrosshairColor(int color)
    {
        switch (color)
        {
            case 0:
                crosshair.color = new Color(63f / 255f, 68f / 255f, 68f / 255f, 1f);
                break;
            case 1:
                crosshair.color = new Color(203f / 255f, 203f / 255f, 203f / 255f, 1f);
                break;
            case 2:
                crosshair.color = new Color(198f / 255f, 68f / 255f, 65f / 255f, 1f);
                break;
            case 3:
                crosshair.color = new Color(210f / 255f, 124f / 255f, 56f / 255f, 1f);
                break;
            case 4:
                crosshair.color = new Color(211f / 255f, 177f / 255f, 41f / 255f, 1f);
                break;
            case 5:
                crosshair.color = new Color(150f / 255f, 195f / 255f, 57f / 255f, 1f);
                break;
            case 6:
                crosshair.color = new Color(34f / 255f, 143f / 255f, 105f / 255f, 1f);
                break;
            case 7:
                crosshair.color = new Color(77f / 255f, 173f / 255f, 188f / 255f, 1f);
                break;
            case 8:
                crosshair.color = new Color(80f / 255f, 117f / 255f, 173f / 255f, 1f);
                break;
            case 9:
                crosshair.color = new Color(138f / 255f, 40f / 255f, 173f / 255f, 1f);
                break;

        }
    }
}
