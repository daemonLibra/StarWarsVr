using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehaviour : MonoBehaviour
{
    private Enemy.Enemy Tom;
    public GameObject Camera;
    
    public void Cut()
    {
        Tom.SplitObject();
    }

    public void Damage()
    {
        Tom.SetDamage(10);
        if (Tom.GetCurrentHealth() <= 0)
        {
            Cut();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Tom = new Enemy.Enemy("Tom", 50, "Enemy1", "Healthbar");
    }

    private void Update()
    {
        Tom.FollowCamera(Camera.gameObject.transform.position);

        if (Input.GetKeyDown(KeyCode.Space) && Tom.GetCurrentHealth() > 0)
        {
            Damage();
        }
        
    }
}
