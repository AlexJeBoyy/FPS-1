using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    [Header("Test")]
    public GameObject bulletMarkPrefab;
    public float despawnTime = 3f; // Adjust this value based on how long you want the bullet to exist
    public string despawnTag = "Obstacle"; // Adjust this tag based on what objects should trigger despawn

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
            // Instantiate the bullet mark at the collision point
            InstantiateBulletMark(collision.contacts[0].point, collision.contacts[0].normal);


            // Instantiate the bullet mark prefab at the collision point
            if (bulletMarkPrefab != null)
            {
                
                Instantiate(bulletMarkPrefab, collision.contacts[0].point, Quaternion.identity);
            }
            


        }
    }
    private void DespawnBullet()
    {
        // This method is called either by collision or the despawn timer
        Destroy(gameObject);
    }
    private void InstantiateBulletMark(Vector3 position, Vector3 normal)
    {
        // Instantiate the bullet mark prefab
        GameObject BulletMark = Instantiate(bulletMarkPrefab, position, Quaternion.LookRotation(normal));//problems
        // Attach the BulletMarkController script to handle its lifetime
        BulletMark bulletMarkController = BulletMark.AddComponent<BulletMark>();
        bulletMarkController.lifeTime = 5f; // Adjust this value based on how long you want the bullet mark to be visible
    }

}
