using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBehaviour : MonoBehaviour
{
    
    private LineRenderer laserLine;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        //laserLine.startWidth = 0.1f;
        //laserLine.endWidth = 1f;
    }

    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        laserLine.SetPosition(0, transform.position);
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            laserLine.SetPosition(1, hit.point);
            laserLine.enabled = true;
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
            {
                PushPullObject(hit.collider);
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            laserLine.enabled = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void PushPullObject(Collider collider)
    {
        Transform objectTransform = collider.transform;
        Rigidbody objectBody = collider.gameObject.GetComponent<Rigidbody>();
        objectBody.velocity = Vector3.zero;
        objectBody.angularVelocity = Vector3.zero;
        Vector3 direction = transform.position - objectTransform.position;
        objectTransform.position = objectTransform.position + direction * 0.5f;
    }
}
