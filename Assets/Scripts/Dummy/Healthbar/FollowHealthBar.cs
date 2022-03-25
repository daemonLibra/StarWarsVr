using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHealthBar : MonoBehaviour
{
    public Transform enemy;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //Vector3 relPos = _healthbarObject.transform.position - transform.position;
        //Quaternion rot = Quaternion.LookRotation(relPos);
        //_healthbarObject.transform.localRotation = rot;
    }
}
