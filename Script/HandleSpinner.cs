using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleSpinner : MonoBehaviour
{
    public float startSpeed = 0;
    public float currentSpeed = 0;
    public float deltaSpeed = 10;
    public UIManager ui;

    float delta;
    int rad;
    float touchDeltaPositionLog;

    public void Awake()
    {
        delta = Time.fixedDeltaTime;
        ui = GetComponent<UIManager>();
    }

    public void FixedUpdate()
    {
        ui.UpdateSpeedText(0);

        //�ж���ָ�Ƿ񻬶���Ļ
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentSpeed += deltaSpeed;
            SpinnerRotate();
        }

        //�ж������Ƿ�����ָ�������뿪��Ļ״̬
        if (touchDeltaPositionLog != 0 && Input.touchCount == 0)
        {
            SpeedDecrease();
            //������ת�ټ�������Ϊ��Ȧ/����
            rad = Mathf.RoundToInt((currentSpeed * Mathf.Abs(touchDeltaPositionLog) * delta * 50 * 60) / 360);
            ui.UpdateSpeedText(rad);
        }


    }

    /// <summary>
    /// ��ָ�뿪��Ļʱ��������ת��
    /// </summary>
    public void SpeedDecrease()
    {
        transform.Rotate(0, 0, -touchDeltaPositionLog * delta * currentSpeed);
        if (currentSpeed > 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, startSpeed, delta * 0.35f);
        }
    }

    /// <summary>
    /// ��������������ת
    /// </summary>
    public void SpinnerRotate()
    {
        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        transform.Rotate(-Vector3.forward * touchDeltaPositionLog * delta * currentSpeed);
        touchDeltaPositionLog = touchDeltaPosition.x;
    }
}
