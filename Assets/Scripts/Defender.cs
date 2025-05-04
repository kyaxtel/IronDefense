using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class Defender : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1f;
    public float timer;
    public float damage = 1f;
    public DamageType damageType = DamageType.Normal;
    public int placementCost = 20;
    public float health = 3f;

    private GridTile currentTile;

    public void UpgradeHealth(float amount) {
        health += amount; // Increase health by the upgrade amount
    }

    public void UpgradeDamage(float amount)
    {
        damage += amount;
        Debug.Log("New damage: " + damage);
    }

    public void UpgradeFireRate(float amount) {
        fireRate = Mathf.Max(0.1f, fireRate - amount); // Lower fireRate = faster shooting
    }

    public void SetTile(GridTile tile)
    {
        currentTile = tile;
    } 

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Inform the tile that we're gone
        if (currentTile != null)
        {
            currentTile.OnDefenderDied();
        }

        Destroy(gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = damage;
            bulletScript.damageType = damageType;
        }
    }

    public void PlaceDefender(Vector3 position, GridTile tile)
    {
        if (ResourceManager.Instance.SpendResources(placementCost))
        {
            GameObject obj = Instantiate(gameObject, position, Quaternion.Euler(0,120,0)); // Make a copy
            Defender newDefender = obj.GetComponent<Defender>();
            tile.PlaceDefender(newDefender); // Tell the tile it now owns this defender
        }
        else
        {
            Debug.Log("Not enough resources to place this defender!");
        }
    }

    void OnMouseDown()
    {
        UpgradeManager.Instance.SetSelectedDefender(this);
        Debug.Log("Selected defender for upgrade: " + gameObject.name);
    }
}
