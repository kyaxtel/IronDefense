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
}
