using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    private int enemyKillCount = 0;
    public TextMeshProUGUI killCountText; // Reference to your TextMeshProUGUI component
    public int WinAmount = 25;
    public EnemySpawner enemySpawner;
    public int TotalAmount;

    public void Start()
    {

        enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
        TotalAmount = enemySpawner.enemyMax;
        WinAmount = TotalAmount - 5;
        killCountText.text = "Kills: " + "0" + "/" + WinAmount;
    }
    public void IncrementKillCount()
    {

        enemyKillCount++;
        // Update the TextMeshProUGUI to display the new kill count
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + enemyKillCount + "/" + WinAmount;
        }
        
        if (enemyKillCount == WinAmount)
        {
            YouWon();
        }
    }

    public void YouWon()
    {
        SceneManager.LoadScene("Won");
    }
}

