using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingBack : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadSceneAsync(AppScenes.MAIN_SCENE, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += FinishLoading;
    }

    void FinishLoading(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= FinishLoading;
        Destroy(this.gameObject);
    }
}
