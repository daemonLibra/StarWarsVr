using UnityEngine;

namespace Enemy
{
    public class Enemy : Object
    {
        public string Name;
        private Healthbar.Healthbar _healthbar;
        private GameObject _enemyObject;
        private bool _isHit;

        public Enemy(string name, float maxHealth, GameObject dummyObject, string healthBarTag)
        {
            Name = name;
            _enemyObject = dummyObject;
            if (_enemyObject is null)
            {
                Debug.Log($"No dummy object found with the tag: {dummyObject}");
            }
            else
            {
                _enemyObject.name = name;

                _healthbar = new Healthbar.Healthbar(healthBarTag, maxHealth)
                {
                    CurrentHealth = maxHealth
                };

                _healthbar.SetHealthbarPosition(_enemyObject.transform.localPosition);
            }  
        }

        //the healthbar follows the direction of the camera
        public void FollowCamera(Vector3 cameraPosition)
        {
            _healthbar.FollowCamera(cameraPosition);
        }

        //get the current health of the healthbar object
        public float GetCurrentHealth() 
        {
            return _healthbar.CurrentHealth;
        }

        //subtracts the damage value from the current health and updates the healthbar size
        public void SetDamage(float damage) 
        {
            _healthbar.CurrentHealth -= damage;
            _healthbar.ChangeHealthBarSize();
        }

        //Splits the object into two smaller pieces
        public void SplitObject() 
        {
            Transform transformObject = _enemyObject.transform;
            transformObject.localScale = new Vector3(transformObject.localScale.x, transformObject.localScale.y / 2, transformObject.localScale.z);
            
            float height = transformObject.localScale.y;
            GameObject eHalf1 = Instantiate(_enemyObject);
            transformObject.localPosition = new Vector3(transformObject.localPosition.x + 1, transformObject.localPosition.y + height + 1, transformObject.localPosition.z);

            Transform transformEh = eHalf1.transform;
            transformEh.localPosition = new Vector3(transformEh.localPosition.x, transformEh.localPosition.y - height, transformEh.localPosition.z);
            transformObject.Rotate(Vector3.right, 20);
        }

    }
}

