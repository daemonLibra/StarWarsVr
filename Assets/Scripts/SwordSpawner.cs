using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawner : MonoBehaviour
{
    public GameObject Schwert;
    public SwordBehaviour SwordBehaviour;
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            _ = Instantiate(Schwert);
        }
    }
}
