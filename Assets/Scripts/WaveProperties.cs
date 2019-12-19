using UnityEngine;

[CreateAssetMenu(fileName = "New WaveProperties", menuName = "WaveProperties")]
public class WaveProperties : ScriptableObject
{
    [SerializeField]
    private Enemy enemy = null;
    [SerializeField]
    private int amount = 0;
    [SerializeField]
    private float rate = 1;

    public Enemy Enemy
    {
        get
        {
            return enemy;
        }        
    }

    public int Amount
    {
        get
        {
            return amount;
        }        
    }

    public float Rate
    {
        get
        {
            return rate;
        }
        
    }
}
