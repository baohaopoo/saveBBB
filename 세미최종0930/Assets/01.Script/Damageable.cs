using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable
{
    void OnDamage(int damage, Vector3 hitPoint, Vector3 hitNormal);
}


