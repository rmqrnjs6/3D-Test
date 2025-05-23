using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagelbe 
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagelbe
{

    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition hunger { get { return uiCondition.hunger; } }
    Condition stemina { get { return uiCondition.stemina; } }

    public float noHungerHealthDecay;

    public event Action OnTakeDamage;

    void Update()
    {
        hunger.Add(hunger.passiveValue * Time.deltaTime);
        stemina.Add(stemina.passiveValue * Time.deltaTime);

        if(hunger.curValue <= 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("Á×À½");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        OnTakeDamage?.Invoke();
    }

    public bool UseStemina(float amount)
    {
        if(stemina.curValue - amount < 0f)
        {
            return false;
        }

        stemina.Subtract(amount);
        return true;
    }
}
