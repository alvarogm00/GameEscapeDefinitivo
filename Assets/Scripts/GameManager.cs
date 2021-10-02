using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : TemporalSingleton<GameManager>
{
    float m_currentTime;
    float m_score;
    public int m_fpsKeys;

    public bool gametype1;
    public float m_maxTime;
    public int m_maxScore;
    public int m_numOfEnemies;
    public int m_maxNumOfEnemies;

    FPSDoor m_fpsDoor;
    GameCanvasController canvasController;

    public override void Awake()
    {
        base.Awake();
        canvasController = FindObjectOfType<GameCanvasController>();
        m_fpsDoor = FindObjectOfType<FPSDoor>();
    }
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        Time.timeScale = 1;

        if (Blackboard.m_gameType == GameType.PLAYER_VS_AI)
            SetGametype1();
        else if (Blackboard.m_gameType == GameType.PLAYER_VS_PLAYER)
            SetGameType2();

        EnemyManager.Instance.CreateEnemies(m_numOfEnemies, m_maxNumOfEnemies);

        canvasController.m_scoreValue.text = m_score.ToString();
        canvasController.m_finalScorePanel.SetActive(false);
        canvasController.m_pausePanel.SetActive(false);
    }

    void Update()
    {
        //if (gametype1)
        //{
        //    m_currentTime -= Time.deltaTime;
        //    if (m_currentTime <= 0)
        //    {
        //        SetFinalScorePanel();
        //    }
        //}
        //else
        //{
        //    m_currentTime += Time.deltaTime;
        //    if (m_score >= m_maxScore)
        //    {
        //        SetFinalScorePanel();
        //    }
        //}

        //canvasController.m_time.text = m_currentTime.ToString("F0");

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void EnemyKilled(GameObject enemy)
    {
        EnemyManager.Instance.EnemyDead(enemy);
        m_score += 10;
        canvasController.m_scoreValue.text = m_score.ToString();
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        canvasController.m_currentAmmo.text = currentAmmo.ToString();
        canvasController.m_maxAmmo.text = maxAmmo.ToString();
    }

    public void UpdateHealth(int currentHealth)
    {
        canvasController.m_healthValue.text = currentHealth.ToString();
    }

    public void SetFinalScorePanel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        canvasController.m_finalScorePanel.SetActive(true);
        Time.timeScale = 0;
        if (gametype1)
        {
            canvasController.m_finalScore.text = m_score.ToString();
        }
        else
        {
            canvasController.m_finalScore.text = m_currentTime.ToString();
        }
    }

    void PauseGame()
    {
        canvasController.m_pausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CheckFPSKeys(int keys)
    {
        if (keys < 3)
        {

        }
        else
        {
            m_fpsDoor.Open();
            EnemyManager.Instance.StopSpwaning(false);
        }
    }

    public void AddFPSKeys()
    {
        m_fpsKeys++;
        CheckFPSKeys(m_fpsKeys);
    }
    public void SetGametype1()
    {
        gametype1 = true;
        m_currentTime = m_maxTime;
        MusicManager.Instance.PlayBackgroundMusic(AppSounds.GAME1_MUSIC);
    }

    public void SetGameType2()
    {
        gametype1 = false;
        m_currentTime = 0;
        MusicManager.Instance.PlayBackgroundMusic(AppSounds.GAME2_MUSIC);
    }
}