using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Healthbar
{
    public class Healthbar : Object
    {
        private float _maxHealth;
        public float MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        private readonly float HealthbarLength = 20;

        private float _currentHealth;
        public float CurrentHealth
        {   
            get { return _currentHealth; }
            set { _currentHealth = value; } 
        }

        public GameObject HealthbarObject = GameObject.FindGameObjectWithTag("Healthbar");

        public void ChangeHealthBar()
        {
            float BarLength = _currentHealth / MaxHealth;
            HealthbarObject.transform.localScale = new Vector3(HealthbarLength * BarLength, HealthbarObject.transform.localScale.y, HealthbarObject.transform.localScale.z);
        }

    }

}