using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BaseProperties", menuName = "BaseProperties")]
public class BaseProperties : ScriptableObject
{
    [SerializeField]
    private int maxHealth = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
