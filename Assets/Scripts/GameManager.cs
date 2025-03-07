using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager manager;
    public static int score;
    public static int bulletsLeft;
    public static int enemy;
    [SerializeField] TextMeshProUGUI EnemyText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ResultText;

    [SerializeField] List<Image> BulletsLeft;
    public static bool GameEnded = false;

    [SerializeField] GameObject ResultMenu;

    private void Awake()
    {
        manager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        GameEnded = false;
        enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        score = 0;

        ResultMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
        EnemyText.text = enemy.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void CheckWin()
    {
        if (GameEnded)
            return;
        if (enemy <= 0)
        {
            GameEnded = true;
            ResultMenu.SetActive(true);
            ResultText.text = "You Won! " + score.ToString();
        }
        else if (bulletsLeft <= 0)
        {
            ResultMenu.SetActive(true);
            ResultText.text = "You Lost! " + score.ToString();
            GameEnded = true;

        }
    }

    public void UpdateBulletCount(int bulletsLeft)
    {
        BulletsLeft[bulletsLeft].enabled = false;

        GameManager.bulletsLeft--;

        CheckWin();

    }
}
