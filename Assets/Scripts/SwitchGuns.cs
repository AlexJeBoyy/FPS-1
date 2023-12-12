using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGuns : MonoBehaviour
{
    private bool isPistolActive = true; 
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject rifle;

    void Start()
    {
        // Activate the pistol and deactivate the rifle at the start
        pistol.SetActive(true);
        rifle.SetActive(false);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(true); // Switch to pistol
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(false); // Switch to rifle
        }
    }

    void SwitchWeapon(bool switchToPistol)
    {
        isPistolActive = switchToPistol;

        // Activate/deactivate the corresponding weapons
        pistol.SetActive(isPistolActive);
        rifle.SetActive(!isPistolActive);
    }
}
