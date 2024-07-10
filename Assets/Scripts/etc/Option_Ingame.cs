using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_Ingame : MonoBehaviour
{
    #region variable
    [Header("Panel")]
    [SerializeField]
    private GameObject OPTION;

    [Header("Option_Panel")]
    [SerializeField]
    private GameObject Option_Title;
    [SerializeField]
    private GameObject Game_Control;
    [SerializeField]
    private GameObject Video;
    [SerializeField]
    private GameObject KeyBinding;

    [Header("Option_Highlight")]
    [SerializeField]
    private GameObject Game_Control_H;
    [SerializeField]
    private GameObject Video_H;
    [SerializeField]
    private GameObject KeyBinding_H;

    [Header("Video_Highlight")]
    [SerializeField]
    private GameObject S_O;
    [SerializeField]
    private GameObject S_L;
    [SerializeField]
    private GameObject S_H;
    [SerializeField]
    private GameObject T_L;
    [SerializeField]
    private GameObject T_M;
    [SerializeField]
    private GameObject T_H;

    [Header("Key_Binding")]
    [SerializeField]
    private GameObject Move;
    [SerializeField]
    private GameObject Action;
    [SerializeField]
    private GameObject General;

    [Header("Key_Highlight")]
    [SerializeField]
    private GameObject Move_H;
    [SerializeField]
    private GameObject Action_H;
    [SerializeField]
    private GameObject General_H;

    [Header("Key_Binding_Highlight")]
    [SerializeField]
    private GameObject W_F;
    [SerializeField]
    private GameObject W_B;
    [SerializeField]
    private GameObject W_L;
    [SerializeField]
    private GameObject W_R;
    [SerializeField]
    private GameObject S_D;
    [SerializeField]
    private GameObject S;
    [SerializeField]
    private GameObject I;
    [SerializeField]
    private GameObject Z;
    [SerializeField]
    private GameObject O_I;
    [SerializeField]
    private GameObject P_S;
    [SerializeField]
    private GameObject P;

    [Header("Prevention of selection")]
    [SerializeField]
    private GameObject Key_Choice_Panel;

    bool Check = false;

    [Header("Sound")]
    [SerializeField]
    private string Button;
    [SerializeField]
    private string BGM;

    bool On = false;

    #endregion
    private void Awake()
    {
        Invoke("Play_BGM", 1f);
    }
    private void LateUpdate()
    {
        if (Check)
        {
            if (Input.anyKey)
            {
                Prevention_Off();
                Binding_Choice_Off();
            }
        }
    }
    public void Option_Panel_On()
    {
        soundManager.Instance.Pasue();
        OPTION.SetActive(true);
        O_P_Game_Control_On();
    }
    public void Option_Panel_Off()
    {
        soundManager.Instance.Play_Re();
        //Click_Button();
        OPTION.SetActive(false);
    }
    public void O_P_Game_Control_On()
    {
        Click_Button();
        Game_Control.SetActive(true);
        Game_Control_H.SetActive(true);
    }
    public void O_P_Game_Control_Off()
    {
        Game_Control.SetActive(false);
        Game_Control_H.SetActive(false);
    }
    public void O_P_Video_On()
    {
        Click_Button();
        Video.SetActive(true);
        Video_H.SetActive(true);
    }
    public void O_P_Video_Off()
    {
        Video.SetActive(false);
        Video_H.SetActive(false);
    }
    public void O_P_KeyBinding_On()
    {
        Click_Button();
        KeyBinding.SetActive(true);
        KeyBinding_H.SetActive(true);
    }
    public void O_P_KeyBinding_Off()
    {
        KeyBinding.SetActive(false);
        KeyBinding_H.SetActive(false);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
    }
    public void B_Move_On()
    {
        Click_Button();
        Move.SetActive(true);
        Move_H.SetActive(true);
    }
    public void B_Move_Off()
    {
        Move.SetActive(false);
        Move_H.SetActive(false);
    }
    public void B_Action_On()
    {
        Click_Button();
        Action.SetActive(true);
        Action_H.SetActive(true);
    }
    public void B_Action_Off()
    {
        Action.SetActive(false);
        Action_H.SetActive(false);
    }
    public void B_General_On()
    {
        Click_Button();
        General.SetActive(true);
        General_H.SetActive(true);
    }
    public void B_General_Off()
    {
        General.SetActive(false);
        General_H.SetActive(false);
    }
    public void W_F_()
    {
        Click_Button();
        W_F.SetActive(true);
    }
    public void W_B_()
    {
        Click_Button();
        W_B.SetActive(true);
    }
    public void W_L_()
    {
        Click_Button();
        W_L.SetActive(true);
    }
    public void W_R_()
    {
        Click_Button();
        W_R.SetActive(true);
    }
    public void S_D_()
    {
        Click_Button();
        S_D.SetActive(true);
    }
    public void S_()
    {
        Click_Button();
        S.SetActive(true);
    }
    public void I_()
    {
        Click_Button();
        I.SetActive(true);
    }
    public void Z_()
    {
        Click_Button();
        Z.SetActive(true);
    }
    public void O_I_()
    {
        Click_Button();
        O_I.SetActive(true);
    }
    public void P_S_()
    {
        Click_Button();
        P_S.SetActive(true);
    }
    public void P_()
    {
        Click_Button();
        P.SetActive(true);
    }
    public void Prevention_On()
    {
        Key_Choice_Panel.SetActive(true);
        Check = true;
    }
    public void Prevention_Off()
    {
        Key_Choice_Panel.SetActive(false);
        Check = false;
    }
    public void Binding_Choice_Off()
    {
        W_F.SetActive(false);
        W_B.SetActive(false);
        W_L.SetActive(false);
        W_R.SetActive(false);
        S_D.SetActive(false);
        S.SetActive(false);
        I.SetActive(false);
        Z.SetActive(false);
        O_I.SetActive(false);
        P_S.SetActive(false);
        P.SetActive(false);
    }
    public void Shadow_Off()
    {
        Click_Button();
        S_O.SetActive(true);
        S_L.SetActive(false);
        S_H.SetActive(false);
    }
    public void Shadow_Low()
    {
        Click_Button();
        S_O.SetActive(false);
        S_L.SetActive(true);
        S_H.SetActive(false);
    }
    public void Shadow_High()
    {
        Click_Button();
        S_O.SetActive(false);
        S_L.SetActive(false);
        S_H.SetActive(true);
    }
    public void Texture_Low()
    {
        Click_Button();
        T_L.SetActive(true);
        T_M.SetActive(false);
        T_H.SetActive(false);
    }
    public void Texture_Middle()
    {
        Click_Button();
        T_L.SetActive(false);
        T_M.SetActive(true);
        T_H.SetActive(false);
    }
    public void Texture_High()
    {
        Click_Button();
        T_L.SetActive(false);
        T_M.SetActive(false);
        T_H.SetActive(true);
    }
    public void Go_Main()
    {
        Click_Button();
        sceneManager.Instance.Go_Main();
    }
    public void Key_Reset()
    {
        Click_Button();
        Key_Manager.Instance.Reset_KeySetting();
    }
    public void Cursor_unvisiable()
    {
        Cursor.visible = false;
        //커서 감추기
        Cursor.lockState = CursorLockMode.Locked;
        //위치 고정
    }
    public void ESC_key_Menu()
    {
        Key_Manager.Instance.Check = false;
        O_P_Game_Control_On();
        O_P_KeyBinding_Off();
        O_P_Video_Off();
        Option_Panel_Off();
        Cursor_unvisiable();
    }
    public void Return_Menu()
    {
        //Click_Button();
        GameManager.Instance.Return_Menu_Option();
        GameManager.Instance.Option_ = false;
    }
    public void Set_Key()
    {
        sceneManager.Instance.First_Menu = false;
    }
    private void Click_Button()
    {
        if (On)
        {
            soundManager.Instance.PlaySoundEffect(Button);
            Debug.Log("Button");
        }
    }
    private void Play_BGM()
    {
        try
        {
            soundManager.Instance.PlaySoundBGM(BGM);
        }
        catch (NullReferenceException) { }
        On = true;
    }
}
