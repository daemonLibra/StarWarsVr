using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDummies : MonoBehaviour
{
    public GameObject Dummy;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            _ = Instantiate(Dummy);
        }
    }
}
