using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLaserPointerScript : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    public bool hasTarget = false;

    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
        laserLineRenderer.enabled = true;
    }

    void Update()
    {
        if (!hasTarget)
        {
            ShootLaserFromTargetPosition(transform.position, transform.forward, laserMaxLength);
            laserLineRenderer.startColor = Color.red;
            laserLineRenderer.endColor = Color.red;
        }
        else
        {
            ShootLaserFromTargetPosition(transform.position, transform.forward, float.MaxValue);
            laserLineRenderer.startColor = Color.green;
            laserLineRenderer.endColor = Color.green;
        }
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}