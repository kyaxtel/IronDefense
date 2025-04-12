using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 1f;
    public DamageType damageType = DamageType.Normal;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > 11f) {
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Enemy")) {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null) {
                enemy.TakeDamage(damage, damageType);
            }

            Destroy(gameObject);
        }
    }
}
