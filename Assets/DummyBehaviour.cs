using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehaviour : MonoBehaviour
{
    private Enemy.Enemy Tom;
    public GameObject enemyPrefab;
    private Trainingball.Trainingball Trainingball;
    public GameObject Camera;
    public List<Enemy.Enemy> Enemies;

    public void Cut()
    {
        Tom.SplitObject();
    }

    public void Damage()
    {
        Tom.SetDamage(50);
        if (0 <= Tom.GetCurrentHealth())
        {
            Cut();
        }
    }

    public void SpawnEnemy()
    {
        Enemies.Add(new Enemy.Enemy("Palpatine", 100, enemyPrefab, "Healthbar"));
    }
    public Enemy.Enemy[] GetEnemyFromName(string name)
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy1");
        for (int i = 0; i < enemyList.Length; i++)
        {
            if (enemyList[i].name == name)
                return enemyList[i];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Tom = new Enemy.Enemy("Tom", 50, enemyPrefab, "Healthbar");
        Trainingball = new Trainingball.Trainingball("TrainingBallTag", "TBall");
    }

    private void Update()
    {
        EnemyCollision enemyCollision = new EnemyCollision(); 
        Vector3 cameraPosition = Camera.transform.position;
        
        Tom.FollowCamera(cameraPosition);
        Trainingball.FollowCamera(cameraPosition,Camera.transform.forward, 50);
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.Touch))
        {
            SpawnEnemy();
        }
        if (enemyCollision.IsHit())
        {
            string enemyName = enemyCollision.GetNameOfCollision();

        }
    }
}
