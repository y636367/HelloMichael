using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_Scripts : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxisSpeed = 5;// 카메라 x축 회전속도
    [SerializeField]
    private float rotCamYAxisSpeed = 5;// 카메라 y축 회전속도

    [SerializeField]
    private float sensitivity; // 회전 부드러움 정도
    // -2~7

    private float limitMinX = -80; // 카메라 x축 회전 범위 (최소)
    private float limitMatX = 85; // 카메라 x축 회전 범위 (최대)
    public float eulerAngleX;
    public float eulerAngleY;

    bool Invert_Check = false;

    private Quaternion t_Rotation;

    private PlayerMovement PM;

    void Awake()
    {
        PM = FindObjectOfType<PlayerMovement>();

        sensitivity = OptionManager.Instance.current_smooth;
    }
    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * (rotCamXAxisSpeed + sensitivity); // 마우스 좌/우 이동으로 카메라 y축 회전

        if (!Invert_Check)
            eulerAngleX -= mouseY * (rotCamYAxisSpeed + sensitivity); // 마우스 위/아래 이동으로 카메라 x축 회전
        else
            eulerAngleX += mouseY * (rotCamYAxisSpeed + sensitivity); // 마우스 위/아래 이동으로 카메라 x축 (반전)회전

        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMatX);
        
        t_Rotation = transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);

        PM.Rotate(t_Rotation);
    }

    private float ClampAngle(float angle,float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }

    public void Re_dir(float x, float y)
    {
        eulerAngleX = x;
        eulerAngleY = y;
    }
    public void Revers()
    {
        Invert_Check = OptionManager.Instance.Mouse_Invert;
    }
    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Revers();
    }
    void OnDisable()
    {
        // 델리게이트 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void Get_Sensitivity(float t_sen)
    {
        sensitivity = t_sen;
    }
}
