using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGuns : MonoBehaviour
{
    private bool isPistolActive = true;
    private bool isRifleActive = false;
    private bool isGrapplingGunActive = false;

    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject rifle;
    [SerializeField] private GameObject grapling;
    public bool grappling = false;

    void Start()
    {
        // Activate the pistol and deactivate the rifle at the start
        ActivateWeapon(true, false, false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateWeapon(true, false, false);  // Switch to pistol
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateWeapon(false, true, false);  // Switch to rifle
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))//switch to grapling
        {
            ActivateWeapon(false, false, true);
        }
    }

    void ActivateWeapon(bool activatePistol, bool activateRifle, bool activateGrapplingGun)
    {
        isPistolActive = activatePistol;
        isRifleActive = activateRifle;
        isGrapplingGunActive = activateGrapplingGun;

        // Activate/deactivate the corresponding weapons
        pistol.SetActive(isPistolActive);
        rifle.SetActive(isRifleActive);
        grapling.SetActive(isGrapplingGunActive);

        if (activateGrapplingGun)
        {
            grappling = true;
        }
        else if (!activateGrapplingGun)
        {
            grappling = false;
        }
    }
}
