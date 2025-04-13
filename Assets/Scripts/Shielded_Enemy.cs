using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shielded_Enemy : Enemy
{
    public float shield = 3f; // Shield poitns before health

    public override void TakeDamage(float amount, DamageType type)
    {
        if (shield > 0) {
            shield -= amount;
            if (shield <= 0) {
                shield = 0;
            }
        }
        else {
            base.TakeDamage(amount, type);
        }
    }
}
