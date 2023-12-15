using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorLock : MonoBehaviour
{
    private PauseMenu pm;


    void Start()
    {
        pm = GetComponent<PauseMenu>();

    }

    // Update is called once per frame
    private void Update()
    {

        bool pauseMenu = pm.GameIsPaused;


        Scene scene = SceneManager.GetActiveScene();
        
         if (scene.name == "Level1" || scene.name == "Level2")
        {
            if (pauseMenu)
            {
                UnlockCursor();
            }
            else
            {
                LockCursor();
            }
           

        }
        else
        {
            UnlockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
