using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text speedText;
    /// <summary>
    /// ����Ļ����ʾ����ת��
    /// </summary>
    /// <param name="rad"></param>
    public void UpdateSpeedText(int rad)
    {
        speedText.text = rad.ToString() + "/min";
    }
}
