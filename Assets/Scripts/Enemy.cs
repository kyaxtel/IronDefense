using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;

public enum EnemyType {
    Normal, 
    Fast,
    Shielded,
    Armored,
    Lead,
    Flying
}

public class Enemy : MonoBehaviour
{
    public float health = 5f;
    public float speed = 2f;
    public EnemyType enemyType;
    public bool isLead;

    public virtual void TakeDamage( float amount, DamageType type) {
        if (!IsDamageEffective(type)) return;

        health -= amount;
        if (health <= 0) {
            Die();
        }
    }

    protected virtual bool IsDamageEffective(DamageType type) {
        //Override in special types
        return true;
    }

    protected virtual void Die() {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate( Vector3.left * speed * Time.deltaTime );    
    }
}
