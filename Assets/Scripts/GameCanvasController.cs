using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameCanvasController : MonoBehaviour
{
    public Text         m_currentAmmo;
    public Text         m_maxAmmo;
    public Text         m_healthValue;
    public GameObject   m_pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnExit()
    {
        SceneManager.LoadScene(AppScenes.LOADING_BACK_SCENE);
        MusicManager.Instance.PlaySound(AppSounds.BUTTON_SFX);
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(AppScenes.LOADING_SCENE);
        MusicManager.Instance.PlaySound(AppSounds.BUTTON_SFX);
    }

    public void OnResume()
    {
        MusicManager.Instance.PlaySound(AppSounds.BUTTON_SFX);
        Time.timeScale = 1;
        m_pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
