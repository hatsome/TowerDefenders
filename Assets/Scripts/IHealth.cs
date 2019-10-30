using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    event Action Die;
    event Action<float> OnHealthPCTChanged;
    void setMaxHealth(int amount);
    void TakeDamage(int damage);
}
