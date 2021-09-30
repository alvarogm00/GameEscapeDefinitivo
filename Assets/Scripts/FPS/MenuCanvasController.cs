using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasController : MonoBehaviour
{
    //public AudioClip    m_onClickSound;
    public GameObject   m_mainMenu;
    public GameObject   m_options;
    public Slider       m_musicSlider;
    public Slider       m_sfxSlider;

    AudioSource         m_audioSource;

    void Start()
    {
        MusicManager.Instance.PlayBackgroundMusic(AppSounds.MAIN_TITLE_MUSIC);

        m_musicSlider.value = MusicManager.Instance.MusicVolume;
        m_sfxSlider.value = MusicManager.Instance.SfxVolume;
    }

    void Update()
    {
        
    }

    public void OnGameType1()
    {
        //m_audioSource.PlayOneShot(m_onClickSound, 1);
        Blackboard.m_gameType = GameType.PLAYER_VS_AI;
        SceneManager.LoadScene(AppScenes.LOADING_SCENE);
        MusicManager.Instance.PlaySound(AppSounds.BUTTON_SFX);
    }

    public void OnGameType2()
    {
        //m_audioSource.PlayOneShot(m_onClickSound, 1);
        Blackboard.m_gameType = GameType.PLAYER_VS_PLAYER;
        SceneManager.LoadScene(AppScenes.LOADING_SCENE);
        MusicManager.Instance.PlaySound(AppSounds.BUTTON_SFX);
    }

    public void OnOptions(bool isOptions)
    {
        m_mainMenu.SetActive(!isOptions);
        m_options.SetActive(isOptions);

        if (!isOptions)
        {
            MusicManager.Instance.MusicVolumeSave = m_musicSlider.value;
            MusicManager.Instance.SfxVolumeSave = m_sfxSlider.value;
        }

        MusicManager.Instance.PlaySound(AppSounds.BUTTON_SFX);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnMusicValueChanged()
    {
        MusicManager.Instance.MusicVolume = m_musicSlider.value;
    }

    public void OnSfxValueChanged()
    {
        MusicManager.Instance.SfxVolume = m_sfxSlider.value;
    }
}
