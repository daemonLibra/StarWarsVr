using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : ScriptableObject
{
    private float _maxHealth;
    private float _currentHealth;
    private GameObject _healthbarObject;
    private float _healthbarLength;
    public float MaxHealth
    {
        get { return _maxHealth; }
    }
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    private void Init(GameObject gameObject, float maxHealth, float healthbarLength) 
    {
        _maxHealth = maxHealth;
        _healthbarObject = gameObject;
        _currentHealth = maxHealth;
        _healthbarLength = healthbarLength;
        _healthbarObject.transform.localScale = new Vector3(healthbarLength, _healthbarObject.transform.localScale.y, _healthbarObject.transform.localScale.z);
    }

    public static Healthbar CreateInstance (GameObject gameObject, float maxHealth, float healthbarLength)
    {
        var data = ScriptableObject.CreateInstance<Healthbar>();
        data.Init(gameObject,maxHealth, healthbarLength);

        return data;
    }

    //change the healthbar size
    public void ChangeHealthBarSize()
    {
        Transform transform = _healthbarObject.transform;
        Debug.Log("davor: " + transform.localScale);
        float barLength = _currentHealth / MaxHealth;
        transform.localScale = new Vector3(_healthbarLength * barLength, transform.localScale.y, transform.localScale.z);
        Debug.Log("danach: " + transform.localScale);
    }
}
