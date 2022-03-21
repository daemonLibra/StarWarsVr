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
        private readonly float _healthbarLength = 2;
        public float MaxHealth
        {
            get { return _maxHealth; }
        }
        public float CurrentHealth
        {   
            get { return _currentHealth; }
            set { _currentHealth = value; } 
        }

        public Healthbar(string gameObjectTag, float maxHealth)
        {

            _healthbarObject = GameObject.FindGameObjectWithTag(gameObjectTag);

            if (_healthbarObject is null)
            {
                Debug.Log($"No dummy object found with the tag: {gameObjectTag}");
            }
            else
            {
                _maxHealth = maxHealth;
            }

        }

        //the healthbar follows the direction of the camera
        public void FollowCamera(Vector3 cameraPosition)
        {
            Vector3 relPos = _healthbarObject.transform.position - cameraPosition;
            Quaternion rot = Quaternion.LookRotation(relPos);
            _healthbarObject.transform.localRotation = rot;
        }

        //change the healthbar size
        public void ChangeHealthBarSize()
        {
            Transform transform = _healthbarObject.transform;
            float barLength = _currentHealth / MaxHealth;
            transform.localScale = new Vector3(_healthbarLength * barLength, transform.localScale.y, transform.localScale.z);
        }

        //set the healthbar over the object
        public void SetHealthbarPosition(Vector3 enemyPosition)
        {
            Transform transform = _healthbarObject.transform;
            transform.localPosition = new Vector3(enemyPosition.x, enemyPosition.y * 2.2f , enemyPosition.z);
        }

    }

}