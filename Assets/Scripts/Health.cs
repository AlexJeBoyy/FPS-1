using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 500f;
    private float healthPoints = 100f;
    [SerializeField] private Slider slider;
    private float lastDamageTime = 0f;
    [SerializeField] private float regenerationRate = 5f;
    private bool isRegenerating = false;

    private void Start()
    {
        healthPoints = maxHealth;
        lastDamageTime = Time.time;
    }
    private void Update()
    {
        if (slider != null)
        {
            slider.value = healthPoints;
            if (!isRegenerating && Time.time - lastDamageTime >= 10f)
            {
                isRegenerating = true;
            }
            if (isRegenerating)
            {
                
                RegenerateHealth();
            }

        }
    }
    public void TakeDamage(float damage)

    {
        healthPoints -= damage;

        lastDamageTime = Time.time;

        if (healthPoints <= 0)
        {
            SceneManager.LoadScene("Died");
        }
    }

    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("NPC"))
        {
            TakeDamage(3);
        }
    }

    private void RegenerateHealth()
    {
        if (Time.time - lastDamageTime >= 10f)
        {


            if (healthPoints <= maxHealth)
            {
                // Increase healthPoints gradually
                healthPoints += Time.deltaTime * regenerationRate;

                // Make sure healthPoints doesn't exceed the maximum value (let's say 100)
                healthPoints = Mathf.Min(healthPoints, maxHealth);
            }
            else
            {
                isRegenerating = false;
            }
        }
    }
}

