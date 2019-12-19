using UnityEngine;

[CreateAssetMenu(fileName = "New BaseProperties", menuName = "BaseProperties")]
public class BaseProperties : ScriptableObject
{
    [SerializeField]
    private int maxHealth = 50;

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }        
    }
}
