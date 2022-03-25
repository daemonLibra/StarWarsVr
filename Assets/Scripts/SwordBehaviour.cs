using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    private GameObject _swordObject;
    private GameObject _handObject;
    bool _useForce = false;
    public void GetSword()
    {
        Transform swordTransform = _swordObject.transform;
        Rigidbody swordBody = _swordObject.GetComponent<Rigidbody>();
        swordBody.velocity = Vector3.zero;
        swordBody.angularVelocity = Vector3.zero;
        Vector3 direction = _handObject.transform.position - swordTransform.position;

        Debug.Log("direction: " + direction);
        Debug.Log("swordTransform.position: " + swordTransform.position);
        Debug.Log("hand.position: " + _handObject.transform.position);
        //swordTransform.localRotation = Quaternion.Lerp(swordTransform.localRotation, _handObject.transform.localRotation, 1f);
        swordTransform.position = swordTransform.position + direction * 0.5f;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _swordObject = GameObject.FindGameObjectWithTag("WeaponTag");
        _handObject = GameObject.FindGameObjectWithTag("hand");
        Vector3 localHand = _handObject.transform.position;
        _swordObject.transform.localPosition = new Vector3(localHand.x, localHand.y, localHand.z + 0.02f);
    }

    void Update()
    {
        Transform swordTransform = _swordObject.transform;

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Rigidbody swordBody = _swordObject.GetComponent<Rigidbody>();
            swordBody.velocity = Vector3.zero;
            swordBody.angularVelocity = Vector3.zero;
            _useForce = !_useForce;
        }
        if (Vector3.Distance(swordTransform.position, _handObject.transform.position) > 0.1f)
        {
            if (_useForce)
            {
                float step = 2f * Time.deltaTime; // calculate distance to move
                swordTransform.position = Vector3.MoveTowards(swordTransform.position, _handObject.transform.position, step);
            }
        } 
        else
        {
            _useForce = false;
        }
    }
}
