using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    Button backButton;
    Text speedText;

    protected void Awake()
    {
        backButton = transform.GetChild(0).GetComponent<Button>();
        speedText = transform.GetChild(1).GetComponent<Text>();
        backButton.onClick.AddListener(BackMainMenu);
    }
    /// <summary>
    /// ·µ»ØÖ÷²Ëµ¥
    /// </summary>
    public void BackMainMenu()
    {
        SceneController.Instance.SwitchToStartScene();
    }

    public void UpdateSpeedText(int rad)
    {
        speedText.text = rad.ToString() + "/min";
    }
}
