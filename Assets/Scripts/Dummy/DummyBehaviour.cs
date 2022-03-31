using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehaviour : MonoBehaviour
{
    private Dummy Tom;
    public GameObject DummyPrefab;
    public GameObject HealthbarPrefab;
    public float HealthbarLength;
    private Transform playerCamera;

    public void Cut()
    {
        Destroy(DummyPrefab);
        Destroy(this);
    }

    public void Damage()
    {
        Debug.Log("toms health vor dmg: " + Tom.GetCurrentHealth());
        Tom.SetDamage(10);
        Debug.Log("toms health nach dmg: " + Tom.GetCurrentHealth());
        if (0 >= Tom.GetCurrentHealth())
        {
            Cut();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Tom = Dummy.CreateInstance("Tom", 50, DummyPrefab, HealthbarPrefab, HealthbarLength);
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").transform;
    }

    private void Update()
    {
        Vector3 relPos = HealthbarPrefab.transform.position - playerCamera.position;
        Quaternion rot = Quaternion.LookRotation(relPos);
        HealthbarPrefab.transform.localRotation = rot;
    }
}
