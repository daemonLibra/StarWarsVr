using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Healthbar
{
    public class Healthbar : Object
    {
        private float _maxHealth;
        private float _currentHealth;
        private GameObject _healthbarObject;
        private readonly float _healthbarLength = 20;
        public float MaxHealth
        {
            get { return _maxHealth; }
        }
        public float CurrentHealth
        {   
            get { return _currentHealth; }
            set { _currentHealth = value; } 
        }

        //the healthbar follows the direction of the camera
        public void FollowCamera(Vector3 CameraPosition)
        {
            Vector3 relPos = _healthbarObject.transform.position - CameraPosition;
            Quaternion rot = Quaternion.LookRotation(relPos);
            _healthbarObject.transform.localRotation = rot;
        }

        public Healthbar(string GameObjectTag, float MaxHealth) 
        {
            _maxHealth = MaxHealth;
            _healthbarObject = GameObject.FindGameObjectWithTag(GameObjectTag);
        }

        //change the healthbar size
        public void ChangeHealthBarSize()
        {
            float BarLength = _currentHealth / MaxHealth;
            _healthbarObject.transform.localScale = new Vector3(_healthbarLength * BarLength, _healthbarObject.transform.localScale.y, _healthbarObject.transform.localScale.z);
        }

        //set the healthbar over the object
        public void SetHealthbarPosition()
        {
            _healthbarObject.transform.localPosition = new Vector3(_healthbarObject.transform.localPosition.x, _healthbarObject.transform.localPosition.y, _healthbarObject.transform.localPosition.z);
        }

    }

}