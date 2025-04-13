using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Defender : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1f;
    public float timer;
    public float damage = 1f;
    public DamageType damageType = DamageType.Normal;
    public int placementCost = 20; // The cost to place this defender
    public float health = 3f; // Set initial health

    public void TakeDamage(float amount) {
        health -= amount;

        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate) {
            Shoot();
            timer = 0f;
        }    
    }

    void Shoot() {
        GameObject bullet = Instantiate( bulletPrefab, shootPoint.position, Quaternion.identity );
        
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null) {
            bulletScript.damage = damage;
            bulletScript.damageType = damageType;
        }
    }

    public void PlaceDefender(Vector3 position) {
        if (ResourceManager.Instance.SpendResources(placementCost)) {
            Instantiate(gameObject, position, Quaternion.identity); // Instantiate defender
        }
        else {
            Debug.Log("Not enough resources to place this defender!");
        }
    }
}
