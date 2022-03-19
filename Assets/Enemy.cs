using UnityEngine;

namespace Enemy
{
    public class Enemy : Object
    {
        private Healthbar.Healthbar _healthbar;
        private GameObject _enemyObject;

        public Enemy(string Name, float MaxHealth, string DummyType, string HealthbarType)
        {
            _enemyObject = GameObject.FindGameObjectWithTag(DummyType);
            _enemyObject.name = Name;

            _healthbar = new Healthbar.Healthbar(HealthbarType, MaxHealth)
            {
                CurrentHealth = MaxHealth
            };

            _healthbar.SetHealthbarPosition();
        }

        //the healthbar follows the direction of the camera
        public void FollowCamera(Vector3 CameraPosition)
        {
            _healthbar.FollowCamera(CameraPosition);
        }

        //get the current health of the healthbar object
        public float GetCurrentHealth() 
        {
            return _healthbar.CurrentHealth;
        }

        //subtracts the damage value from the current health and updates the healthbar size
        public void SetDamage(float Damage) 
        {
            _healthbar.CurrentHealth -= Damage;
            _healthbar.ChangeHealthBarSize();
        }

        //Splits the object into two smaller pieces
        public void SplitObject() 
        {
            Transform transformObject = _enemyObject.transform;

            transformObject.localScale = new Vector3(transformObject.localScale.x, transformObject.localScale.y / 2, transformObject.localScale.z);
           
            float height = transformObject.localScale.y;

            GameObject EHalf1 = Instantiate(_enemyObject);

            transformObject.localPosition = new Vector3(transformObject.localPosition.x + 1, transformObject.localPosition.y + height + 1, transformObject.localPosition.z);

            EHalf1.transform.localPosition = new Vector3(EHalf1.transform.localPosition.x, EHalf1.transform.localPosition.y - height, EHalf1.transform.localPosition.z);
            transformObject.Rotate(Vector3.right, 20);
        }
    }
}

