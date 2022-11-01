using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleSpinner : MonoBehaviour
{
    public float startSpeed = 0;
    public float currentSpeed = 0;
    public float deltaSpeed = 1f;
    public UIManager ui;

    float delta;
    int rad;
    Vector2 touchPosition;
    float touchDeltaPositionLog;

    public void Awake()
    {
        delta = Time.fixedDeltaTime;
        ui = GetComponent<UIManager>();
    }

    public void FixedUpdate()
    {
        ui.UpdateSpeedText(0);

        //判断手指是否滑动屏幕
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentSpeed += deltaSpeed;
            if (currentSpeed > 30)
            {
                currentSpeed = 30;
            }
            print("SPEED按住:" + currentSpeed);
            SpinnerRotate();
            PrintSpeed();
        }

        //判断陀螺是否处于手指滑动后并离开屏幕状态
        if (touchDeltaPositionLog != 0 && Input.touchCount == 0)
        {
            SpeedDecrease();
            PrintSpeed();
        }
    }

    /// <summary>
    /// 手指离开屏幕时降低陀螺转速
    /// </summary>
    public void SpeedDecrease()
    {
        print("DISTANCE======:"+touchDeltaPositionLog);
        print("SPEED离开:"+currentSpeed);
        if (touchDeltaPositionLog > 200)
        {
            touchDeltaPositionLog = 200;
        }
        transform.Rotate(Vector3.forward * touchDeltaPositionLog * delta * currentSpeed);
        if (currentSpeed > 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, startSpeed, delta * 0.05f);
        }
    }

    /// <summary>
    /// 触屏控制陀螺旋转
    /// </summary>
    public void SpinnerRotate()
    {
        touchPosition = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        //print(touchDeltaPosition);
        touchDeltaPositionLog = touchDeltaPosition.x + touchDeltaPosition.y;

        if (touchDeltaPosition.x > touchDeltaPosition.y && touchDeltaPositionLog > 0)
        {
            if(touchPosition.y > 0.5f)
            {
                transform.Rotate(Vector3.forward * -touchDeltaPosition.x * delta * currentSpeed);
                touchDeltaPositionLog = -touchDeltaPosition.x;
            }
            else
            {
                transform.Rotate(Vector3.forward * touchDeltaPosition.x * delta * currentSpeed);
                touchDeltaPositionLog = touchDeltaPosition.x;
            }  
        }
        else if (touchDeltaPosition.x < touchDeltaPosition.y && touchDeltaPositionLog > 0)
        {
            if (touchPosition.x > 0.5f)
            {
                transform.Rotate(Vector3.forward * touchDeltaPosition.y * delta * currentSpeed);
                touchDeltaPositionLog = touchDeltaPosition.y;
            }
            else
            {
                transform.Rotate(Vector3.forward * -touchDeltaPosition.y * delta * currentSpeed);
                touchDeltaPositionLog = -touchDeltaPosition.y;
            }
        }
        else if (touchDeltaPosition.x > touchDeltaPosition.y && touchDeltaPositionLog < 0)
        {
            if (touchPosition.x > 0.5f)
            {
                transform.Rotate(Vector3.forward * touchDeltaPosition.y * delta * currentSpeed);
                touchDeltaPositionLog = touchDeltaPosition.y;
            }
            else
            {
                transform.Rotate(Vector3.forward * -touchDeltaPosition.y * delta * currentSpeed);
                touchDeltaPositionLog = -touchDeltaPosition.y;
            }

            
        }
        else if (touchDeltaPosition.x < touchDeltaPosition.y && touchDeltaPositionLog < 0)
        {
            if (touchPosition.y > 0.5f)
            {
                transform.Rotate(Vector3.forward * -touchDeltaPosition.x * delta * currentSpeed);
                touchDeltaPositionLog = -touchDeltaPosition.x;
            }
            else 
            {
                transform.Rotate(Vector3.forward * touchDeltaPosition.x * delta * currentSpeed);
                touchDeltaPositionLog = touchDeltaPosition.x;
            }
        }
        else
        {
            return;
        }
        
    }

    /// <summary>
    /// 将陀螺转速计算整理为：圈/分钟
    /// </summary>
    public void PrintSpeed()
    { 

        rad = Mathf.RoundToInt((currentSpeed * Mathf.Abs(touchDeltaPositionLog) * delta * 50 * 60) / 360);
        ui.UpdateSpeedText(rad);
    }
}
