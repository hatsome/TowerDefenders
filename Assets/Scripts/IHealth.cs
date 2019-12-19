using System;

public interface IHealth
{
    event Action Die;
    event Action<int> OnMaxHealthChanged;
    event Action<int> OnHealthPCTChanged;
    void setMaxHealth(int amount);
    void TakeDamage(int damage);
}
