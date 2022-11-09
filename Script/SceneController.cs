using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public SceneFader sceneFaderPrefabs;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject); 
    }

    public void SwitchToGameScene()
    {
        StartCoroutine(SwitchScene("GameScene"));
    }

    public void SwitchToStartScene()
    {
        StartCoroutine(SwitchScene("StartScene"));
    }

    public IEnumerator SwitchScene(string scene)
    {
        SceneFader fade = Instantiate(sceneFaderPrefabs);

        if (scene != "")
        {
            yield return StartCoroutine(fade.FadeOut(0.5f));
            yield return SceneManager.LoadSceneAsync(scene);
            yield return StartCoroutine(fade.FadeIn(0.5f));
            
            yield break;
        } 
    }
}
