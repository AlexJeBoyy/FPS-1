using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints = 100f;
    [SerializeField] private Slider slider;

    private void Update()
    {
        if (slider != null)
        {
            slider.value = healthPoints;
        }
    }
    public void TakeDamage(float damage)

    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            SceneManager.LoadScene("Dead");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Check to see if the Collider's name is "Chest"
        if (collision.gameObject.CompareTag("NPC"))
        {
            //Output the message
            Debug.Log("you lost health" + healthPoints);
            TakeDamage(10);
        }
    }
}

