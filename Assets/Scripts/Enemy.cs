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
    public int resourceDropAmount = 10; // How many resources this enemy will drop
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
        // Add resources when the enemy dies
        ResourceManager.Instance.AddResources(resourceDropAmount);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate( Vector3.left * speed * Time.deltaTime );

        // If the enemy goes off the screen (left side)
        if (transform.position.x < -2f) { // adjust based on your camera size    
            PlayerHealthManager.Instance.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Defender")) {
            Defender defender = other.GetComponent<Defender>();
            if(defender != null) {
                defender.TakeDamage(1); // You can customize how much damage enemies deal
            }

            Destroy(gameObject);
        }
        if (other.CompareTag("EndZone")) {
            if(PlayerHealthManager.Instance != null) {
                PlayerHealthManager.Instance.TakeDamage(1); // or however much damage you want
            }

            Destroy(gameObject);
        }
    }
}
