using UnityEngine;


public class Dummy : ScriptableObject
{
    public string Name;
    private Healthbar _healthbar;
    private GameObject _dummyObject;

    private void Init(string name, float maxHealth, GameObject dummyObject, GameObject healthbarObject, float healthbarLength) 
    {
        Name = name;
        _dummyObject = dummyObject;
        _dummyObject.name = name;
        _healthbar = Healthbar.CreateInstance(healthbarObject, maxHealth, healthbarLength);
    }

    public static Dummy CreateInstance(string name, float maxHealth, GameObject dummyObject, GameObject healthbarObject, float healthbarLength)
    {
        var data = ScriptableObject.CreateInstance<Dummy>();

        data.Init(name, maxHealth, dummyObject, healthbarObject, healthbarLength);
        return data;
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
        Transform transformObject = _dummyObject.transform;
        transformObject.localScale = new Vector3(transformObject.localScale.x, transformObject.localScale.y / 2, transformObject.localScale.z);

        float height = transformObject.localScale.y;
        GameObject eHalf1 = Instantiate(_dummyObject);
        transformObject.localPosition = new Vector3(transformObject.localPosition.x + 1, transformObject.localPosition.y + height + 1, transformObject.localPosition.z);

        Transform transformEh = eHalf1.transform;
        transformEh.localPosition = new Vector3(transformEh.localPosition.x, transformEh.localPosition.y - height, transformEh.localPosition.z);
        transformObject.Rotate(Vector3.right, 20);
    }
}


