using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_MousLook : MonoBehaviour
{
    #region UNITY SYSTEM
    // Use this for initialization
    private void Start()
    {
        Init(Body, Head);
    }
    // Update is called once per frame
    private void Update()
    {
        LookRotation(Body, Head);
    }
    #endregion

    #region CUSTOMER
    public Transform Body;
    public Transform Head;
    public float XSensitivity = 2f; //Get the sensity of horizontal mosue
    public float YSensitivity = 2f; //Get the sensity of veritcal mouse
    public bool clampVerticalRotation = true; //Whether open the limitation or not
    public float MinimumX = -90F; //Minimum limitation
    public float MaximumX = 90F;  //Maxmum limiation
    public bool smooth; //Whether set look smoothly or not
    public float smoothTime = 5f; //the total time of smoothly move
    public bool lockCursor = true; //Whether lock mouse cursor or not 
    private Quaternion m_CharacterTargetRot; //Control the object rotate horizontally
    private Quaternion m_CameraTargetRot; //Control the object rotate vertically
    private bool m_cursorIsLocked = true; //Is the mosue lock

    //Initialize    
    public void Init(Transform character, Transform camera)
    {
        m_CharacterTargetRot = character.localRotation; //获得角色自身选择的Q
        m_CameraTargetRot = camera.localRotation; //获得相机自身选择的Q
    }
    //Mosue look
    public void LookRotation(Transform character, Transform camera)
    {
        //获取鼠标x,y方向的加速度数值
        float yRot = Input.GetAxis("Mouse X") * XSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * YSensitivity;
        //根据鼠标x,y的数值获得对于的选择选择角度
        //欧拉角Euler(x,y,z)可理解为以谋一个坐标轴为转轴进行旋转
        //角色的水平角度变量以yRot为轴
        m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        //角色的纵向角度变量以xRot为轴
        m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);
        //是否开启x,y最大视角限制
        if (clampVerticalRotation)
            m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);
        //是否开启平滑观察模式
        if (smooth)
        {
            //利用球形差值进行平滑缓冲
            character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot,
                smoothTime * Time.fixedDeltaTime);
            camera.localRotation = Quaternion.Slerp(camera.localRotation, m_CameraTargetRot,
                smoothTime * Time.fixedDeltaTime);
        }
        else
        {
            character.localRotation = m_CharacterTargetRot;
            camera.localRotation = m_CameraTargetRot;
        }
        UpdateCursorLock();

        //Debug.Log(this.transform.rotation.x);
    }
    //mouse lock initial
    public void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (!lockCursor)
        {//we force unlock the cursor if the user disable the cursor locking helper
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    //mouse lock update
    public void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (lockCursor)
            InternalLockUpdate();
    }
    //?
    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }
        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    //?
    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        //将四元函数中的x的x*sin(角度/2)转化为x*tan(角度/2)
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
        //把实际选择的弧度数转换为角度数
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        //限制范围函数(现有数值，最小值，最大值)超过最大或最小值就按极端值来计算clamp(23,4,6)结果为6
        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);
        //返回四元函数的x值
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        return q;
    }
    #endregion
}
