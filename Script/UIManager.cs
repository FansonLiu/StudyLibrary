using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text speedText;
    /// <summary>
    /// 在屏幕上显示陀螺转速
    /// </summary>
    /// <param name="rad"></param>
    public void UpdateSpeedText(int rad)
    {
        speedText.text = rad.ToString() + "/min";
    }
}
