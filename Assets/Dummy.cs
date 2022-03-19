using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Enemmy.Enemy Tom;
    public GameObject Camera;
    private Transform TomTransform;
    private Transform TomHealthbarTransform;
    /*
     * Cut version 1.01
     */
    public void Cut()
    {   
        TomTransform.localScale = new Vector3 (TomTransform.localScale.x,TomTransform.localScale.y/2,TomTransform.localScale.z);
        float height = TomTransform.localScale.y;
        GameObject EHalf1 = GameObject.Instantiate(Tom.EnemyObject);
        TomTransform.localPosition = new Vector3 (TomTransform.localPosition.x+1,TomTransform.localPosition.y+height+1,TomTransform.localPosition.z);
        EHalf1.transform.localPosition = new Vector3(EHalf1.transform.localPosition.x, EHalf1.transform.localPosition.y - height, EHalf1.transform.localPosition.z);
        TomTransform.Rotate(Vector3.right, 20);
    }

    public void Damage()
    {
        Tom.Healthbar.CurrentHealth -= 10;
        Tom.Healthbar.ChangeHealthBar();
        if (Tom.Healthbar.CurrentHealth <= 0)
        {
            Cut();
        }
    }

    
    
    // Start is called before the first frame update
    void Start()
    {
        Tom = new Enemmy.Enemy("Tom", 50, "Enemy1");
        TomTransform = Tom.EnemyObject.transform;
        TomHealthbarTransform = Tom.Healthbar.HealthbarObject.transform;
        TomHealthbarTransform.localPosition = new Vector3(TomHealthbarTransform.localPosition.x, TomHealthbarTransform.localPosition.y, TomHealthbarTransform.localPosition.z);
    }

    private void Update()
    {
        Vector3 relPos = TomHealthbarTransform.position - Camera.gameObject.transform.position;
        Quaternion rot = Quaternion.LookRotation(relPos);
        TomHealthbarTransform.localRotation = rot;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage();
        }
        
    }
}
