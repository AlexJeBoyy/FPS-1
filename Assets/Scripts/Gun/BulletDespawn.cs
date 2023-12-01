using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject bulletMarkPrefab;
    public float despawnTime = 3f; // Lifetime of bullet
    
    private void Start()
    {

        // Start the despawn timer when the bullet is instantiated
        Invoke("DespawnBullet", despawnTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag("NPC") || collision.gameObject.CompareTag("Untagged"))
        {
            // If it does, despawn the bullet
            DespawnBullet();
        }
        if (collision.gameObject.CompareTag("Untagged"))
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 collisionNormal = collision.contacts[0].normal;

            // Calculate the rotation
            Quaternion rotation = Quaternion.LookRotation(collisionNormal, Vector3.up) * Quaternion.Euler(0f, 180f, 0f);

            // Create the bullet mark at the collision point with the correct rotation
            GameObject bulletMark = Instantiate(bulletMarkPrefab, collisionPoint, rotation);

            // Adjust the size of the bullet mark
            bulletMark.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            // Despawn the bullet
            Destroy(gameObject);
        }
    }
    private void DespawnBullet()
    {
        // Destroy's the bullet
        Destroy(gameObject);
    }
    private void InstantiateBulletMark(Vector3 position, Vector3 normal)
    {
        // Calculate the rotation based on the collision normal
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);

        // Instantiate the bullet mark prefab with the correct rotation
        GameObject bulletMark = Instantiate(bulletMarkPrefab, position, rotation);

        // Attach the BulletMarkController script to handle its lifetime
        BulletMark bulletMarkController = bulletMark.AddComponent<BulletMark>();
        bulletMarkController.lifeTime = 5f; // Adjust this value based on how long you want the bullet mark to be visible
    }

}
