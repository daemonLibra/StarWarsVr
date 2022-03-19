using UnityEngine;

namespace Enemmy
{
    public class Enemy : Object
    {
        public Healthbar.Healthbar Healthbar;
        private readonly string _name;
        public GameObject EnemyObject;

        public Enemy(string Name, float MaxHealth, string DummyType)
        {
            EnemyObject = GameObject.FindGameObjectWithTag(DummyType);
            //GameObject.Instantiate(EnemyObject);
            Healthbar = new Healthbar.Healthbar
            {
                MaxHealth = MaxHealth,
                CurrentHealth = MaxHealth
            };
        }
    }
}

