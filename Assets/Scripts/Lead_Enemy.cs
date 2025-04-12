using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lead_Enemy : Enemy
{
    protected override bool IsDamageEffective(DamageType type)
    {
        return type == DamageType.Explosive || type == DamageType.Magic;
    }
}
