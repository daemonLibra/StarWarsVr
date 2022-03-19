using UnityEngine;

namespace Enemy
{
    public class Enemy : Object
    {
        public Healthbar.Healthbar Healthbar;
        private GameObject _enemyObject;

        public Enemy(string Name, float MaxHealth, string DummyType, string HealthbarType)
        {
            _enemyObject = GameObject.FindGameObjectWithTag(DummyType);
            _enemyObject.name = Name;

            Healthbar = new Healthbar.Healthbar(HealthbarType, MaxHealth)
            {
                CurrentHealth = MaxHealth
            };
        }

        public void SetDamage(float Damage) 
        {
            Healthbar.CurrentHealth -= Damage;
            Healthbar.ChangeHealthBarSize();
        }

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

