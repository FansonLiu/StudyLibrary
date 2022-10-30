using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    Button quitButton;

    public void Awake()
    {
        quitButton = transform.GetChild(0).GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("ÍË³öÓÎÏ·");
    }
}
