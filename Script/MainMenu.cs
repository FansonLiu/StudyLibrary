using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
    Button newGameBtn;
    Button continueBtn;
    Button quitBtn;
    Button soundBtnOn;
    Button soundBtnOff;

    bool muteState = false;

    Image image1;
    Image image2;

   

    private void Awake()
    {
        newGameBtn = transform.GetChild(0).GetComponent<Button>();
        continueBtn = transform.GetChild(1).GetComponent<Button>();
        quitBtn = transform.GetChild(2).GetComponent<Button>();
        soundBtnOn = transform.GetChild(3).GetComponent<Button>();
        soundBtnOff = transform.GetChild(4).GetComponent<Button>();

        image1 = transform.GetChild(5).GetComponent<Image>();
        image2 = transform.GetChild(6).GetComponent<Image>();

        newGameBtn.onClick.AddListener(NewGame);
        continueBtn.onClick.AddListener(ContinueGame);
        quitBtn.onClick.AddListener(QuitGame);
        soundBtnOn.onClick.AddListener(HandlePlayMusic);
        soundBtnOff.onClick.AddListener(HandlePlayMusic);
    }

    public void FixedUpdate()
    {
        image1.transform.Rotate(Vector3.forward * 30 * Time.fixedDeltaTime);
        image2.transform.Rotate(-Vector3.forward * 30 * Time.fixedDeltaTime);
    }

    public void HandlePlayMusic()
    {
        muteState = !muteState;
        AudioManager.Instance.audioMusic.mute = muteState;
        soundBtnOn.gameObject.SetActive(!muteState);
        soundBtnOff.gameObject.SetActive(muteState);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        AudioManager.Instance.PlayClickSound();
        //转换场景
        SceneController.Instance.SwitchToGameScene();
    }

    public void ContinueGame()
    {
        AudioManager.Instance.PlayClickSound();
        //转换场景，读取进度
        SceneController.Instance.SwitchToGameScene();
    }
    public void QuitGame()
    {
        AudioManager.Instance.PlayClickSound();
        Application.Quit();
    }

}
