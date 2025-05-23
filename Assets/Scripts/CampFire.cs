using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int Damage;
    public float damageRate;

    List<IDamagelbe> things = new List<IDamagelbe>();

    private void Start()
    {
        InvokeRepeating("DealDamage", 0 , damageRate);
    }

    void DealDamage()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(Damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagelbe damaglbe))
        {
            things.Add(damaglbe);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamagelbe damaglbe))
        {
            things.Remove(damaglbe);
        }
    }
}
