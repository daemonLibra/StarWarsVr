using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private GameObject _enemy;
    private bool _isHit;
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);

            if (GameObject.FindGameObjectWithTag("Enemy1") == collision.gameObject)
            {
                _enemy = collision.gameObject;
                _isHit = true;
            }
            else
            {
                _isHit = false;
            } 

            Debug.Log(collision.gameObject);
        }
    }

    public Object GetParent()
    { 
        return this.GetParent();
    }

    public string GetNameOfCollision()
    {
        return _enemy.name;
    }

    public bool IsHit()
        { return _isHit; }
}
