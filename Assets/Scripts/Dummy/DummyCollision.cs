using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCollision : MonoBehaviour
{
    public DummyBehaviour Contact;

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            if ("Laserschwert" == collision.collider.name)
            {
                Contact.Damage();
            }
        }
    }

}
