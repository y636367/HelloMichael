using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BTN_Matching : MonoBehaviour
{
    #region variable
    [Header("Main_Play")]
    [SerializeField]
    private Button Game_Start;
    [SerializeField]
    private Button Game_Continue;

    [Header("Option")]
    [SerializeField]
    private Button Option_P;

    [Header("Option_Game")]
    [SerializeField]
    private Button Nomal_;
    [SerializeField]
    private Button Hard_;

    [Header("Option_Control")]
    [SerializeField]
    private Slider Smooth_Slider;
    [SerializeField]
    private Button Inverse;

    [Header("Option_Video")]
    [SerializeField]
    private Button Done_;
    [SerializeField]
    private Button FullScreen_;
    [SerializeField]
    private Button Shadow_Off;
    [SerializeField]
    private Button Shadow_Low;
    [SerializeField]
    private Button Shadow_High;
    [SerializeField]
    private Button Texture_Low;
    [SerializeField]
    private Button Texture_Med;
    [SerializeField]
    private Button Texture_High;
    [SerializeField]
    private TMP_Dropdown Resolution_;

    [Header("Option_KeyBinding")]
    [SerializeField]
    private Button Reset_;
    [SerializeField]
    private Button Assign_1;
    [SerializeField]
    private Button Assign_2;
    [SerializeField]
    private Button Assign_3;
    [SerializeField]
    private Button Assign_4;
    [SerializeField]
    private Button Assign_5;
    [SerializeField]
    private Button Assign_6;
    [SerializeField]
    private Button Assign_7;
    [SerializeField]
    private Button Assign_8;
    [SerializeField]
    private Button Assign_9;
    [SerializeField]
    private Button Assign_10;
    [SerializeField]
    private Button Assign_11;

    #endregion
    private void Awake()
    {
        Find_Objects();
        Event_AddListener();
    }
    private void Find_Objects()
    {
        GameObject Start_Main = GameObject.FindGameObjectWithTag("Main_Menu");

        GameObject Main_Panel = Start_Main.transform.Find("Canv_Main").gameObject;
        GameObject Play = Main_Panel.transform.Find("PLAY").gameObject;
        GameObject Verticall = Play.transform.Find("VerticalLayout").gameObject;

        Game_Start = Verticall.transform.Find("Btn_NewGame").gameObject.GetComponent<Button>();
        Game_Continue = Verticall.transform.Find("Btn_Continue").gameObject.GetComponent<Button>();

        GameObject Option_Panel = Start_Main.transform.Find("Canv_Options").gameObject;

        GameObject Buttons = Option_Panel.transform.Find("BUTTONS").gameObject;

        Option_P = Buttons.transform.Find("Btn_Video").gameObject.GetComponent<Button>();

        GameObject Panels = Option_Panel.transform.Find("PANELS").gameObject;

        GameObject Panel_Game = Panels.transform.Find("PanelGame").gameObject;

        Nomal_ = Panel_Game.transform.Find("NormDif_Btn").gameObject.GetComponent<Button>();
        Hard_ = Panel_Game.transform.Find("HardDif_Btn").gameObject.GetComponent<Button>();

        GameObject Panel_Control = Panels.transform.Find("PanelControls").gameObject;

        Smooth_Slider = Panel_Control.transform.Find("SmoothingSlider").gameObject.GetComponent<Slider>();
        Inverse = Panel_Control.transform.Find("Inverse_Btn").gameObject.GetComponent<Button>();

        GameObject Panel_Video = Panels.transform.Find("PanelVideo").gameObject;

        Done_ = Panel_Video.transform.Find("Btn_Done").gameObject.GetComponent<Button>();
        FullScreen_ = Panel_Video.transform.Find("FullScreen_Btn").gameObject.GetComponent<Button>();
        Shadow_Off = Panel_Video.transform.Find("ShadowOff_Btn").gameObject.GetComponent<Button>();
        Shadow_Low = Panel_Video.transform.Find("ShadowLow_Btn").gameObject.GetComponent<Button>();
        Shadow_High = Panel_Video.transform.Find("ShadowHigh_Btn").gameObject.GetComponent<Button>();
        Texture_Low = Panel_Video.transform.Find("TextureLow_Btn").gameObject.GetComponent<Button>();
        Texture_Med = Panel_Video.transform.Find("TextureMed_Btn").gameObject.GetComponent<Button>();
        Texture_High = Panel_Video.transform.Find("TextureHigh_Btn").gameObject.GetComponent<Button>();
        Resolution_ = Panel_Video.transform.Find("Resolution_Drop").gameObject.GetComponent<TMP_Dropdown>();

        GameObject Panel_Key = Panels.transform.Find("PanelKeyBindings").gameObject;

        Reset_ = Panel_Key.transform.Find("Reset_Btn").gameObject.GetComponent<Button>();

        GameObject MoveMentPanel = Panel_Key.transform.Find("MovementPanel").gameObject;
        GameObject ActionPanel = Panel_Key.transform.Find("ActonPanel").gameObject;
        GameObject GeneralPanel = Panel_Key.transform.Find("GeneralPanel").gameObject;

        Assign_1 = MoveMentPanel.transform.Find("Btn_Assign_1").gameObject.GetComponent<Button>();
        Assign_2 = MoveMentPanel.transform.Find("Btn_Assign_2").gameObject.GetComponent<Button>();
        Assign_3 = MoveMentPanel.transform.Find("Btn_Assign_3").gameObject.GetComponent<Button>();
        Assign_4 = MoveMentPanel.transform.Find("Btn_Assign_4").gameObject.GetComponent<Button>();
        Assign_5 = MoveMentPanel.transform.Find("Btn_Assign_5").gameObject.GetComponent<Button>();
        Assign_6 = MoveMentPanel.transform.Find("Btn_Assign_6").gameObject.GetComponent<Button>();

        Assign_7 = ActionPanel.transform.Find("Btn_Assign_7").gameObject.GetComponent<Button>();
        Assign_8 = ActionPanel.transform.Find("Btn_Assign_8").gameObject.GetComponent<Button>();
        Assign_9 = ActionPanel.transform.Find("Btn_Assign_9").gameObject.GetComponent<Button>();
        Assign_10 = ActionPanel.transform.Find("Btn_Assign_10").gameObject.GetComponent<Button>();

        Assign_11 = GeneralPanel.transform.Find("Btn_Assign_11").gameObject.GetComponent<Button>();
    }
    private void Event_AddListener()
    {
        #region Play
        Game_Start.onClick.AddListener(Start_On);
        Game_Continue.onClick.AddListener(Continue_On);
        #endregion

        #region Option
        Option_P.onClick.AddListener(Resolution_On);
        #endregion

        #region Option_Game
        Nomal_.onClick.AddListener(Nomal_On);
        Hard_.onClick.AddListener(Hard_On);
        #endregion

        #region Option_Control
        Smooth_Slider.onValueChanged.AddListener(Smooth_);
        Inverse.onClick.AddListener(Inverse_);
        #endregion

        #region Option_Video
        Done_.onClick.AddListener(Done_On);
        FullScreen_.onClick.AddListener(FullScreen_On);
        Shadow_Off.onClick.AddListener(Shadow_Off_On);
        Shadow_Low.onClick.AddListener(Shadow_Low_On);
        Shadow_High.onClick.AddListener(Shadow_High_On);
        Texture_Low.onClick.AddListener(Texture_Low_On);
        Texture_Med.onClick.AddListener(Texture_Med_On);
        Texture_High.onClick.AddListener(Texture_High_On);
        Resolution_.onValueChanged.AddListener(Resolution_On);
        #endregion

        #region Option_Vinding
        Reset_.onClick.AddListener(Reset_Key);
        Assign_1.onClick.AddListener(Assign_1_On);
        Assign_2.onClick.AddListener(Assign_2_On);
        Assign_3.onClick.AddListener(Assign_3_On);
        Assign_4.onClick.AddListener(Assign_4_On);
        Assign_5.onClick.AddListener(Assign_5_On);
        Assign_6.onClick.AddListener(Assign_6_On);
        Assign_7.onClick.AddListener(Assign_7_On);
        Assign_8.onClick.AddListener(Assign_8_On);
        Assign_9.onClick.AddListener(Assign_9_On);
        Assign_10.onClick.AddListener(Assign_10_On);
        Assign_11.onClick.AddListener(Assign_11_On);
        #endregion
    }
    private void Start_On()
    {
        sceneManager.Instance.Continue_Check = false;
        sceneManager.Instance.Start_Play_Button();
    }
    private void Continue_On()
    {
        sceneManager.Instance.Continue_Check = true;
        sceneManager.Instance.Start_Play_Button();
    }
    private void Resolution_On()
    {
        OptionManager.Instance.SetResolution();
    }
    private void Nomal_On()
    {
        OptionManager.Instance.Difficulty_Nomal();
    }
    private void Hard_On()
    {
        OptionManager.Instance.Difficulty_Hard();
    }
    private void Smooth_(float t_value)
    {
        OptionManager.Instance.Set_Mouse_Smooth(t_value);
    }
    private void Inverse_()
    {
        OptionManager.Instance.Mouse_Invert_();
    }
    private void Done_On()
    {
        OptionManager.Instance.ChoiceButtion();
    }
    private void FullScreen_On()
    {
        OptionManager.Instance.Screen_Mode_Text();
    }
    private void Shadow_Off_On()
    {
        OptionManager.Instance.Set_Shadow_Off();
    }
    private void Shadow_Low_On()
    {
        OptionManager.Instance.Set_Shadow_Middle();
    }
    private void Shadow_High_On()
    {
        OptionManager.Instance.Set_Shadow_High();
    }
    private void Texture_Low_On()
    {
        OptionManager.Instance.Set_Texture_Low();
    }
    private void Texture_Med_On()
    {
        OptionManager.Instance.Set_Texture_Middle();
    }
    private void Texture_High_On()
    {
        OptionManager.Instance.Set_Texture_High();
    }
    private void Resolution_On(int t)
    {
        OptionManager.Instance.OptionChange(t);
    }
    private void Reset_Key()
    {
        Key_Manager.Instance.Reset_KeySetting();
    }
    private void Assign_1_On()
    {
        Key_Manager.Instance.ChangeKey(0);
    }
    private void Assign_2_On()
    {
        Key_Manager.Instance.ChangeKey(1);
    }
    private void Assign_3_On()
    {
        Key_Manager.Instance.ChangeKey(2);
    }
    private void Assign_4_On()
    {
        Key_Manager.Instance.ChangeKey(3);
    }
    private void Assign_5_On()
    {
        Key_Manager.Instance.ChangeKey(4);
    }
    private void Assign_6_On()
    {
        Key_Manager.Instance.ChangeKey(5);
    }
    private void Assign_7_On()
    {
        Key_Manager.Instance.ChangeKey(6);
    }
    private void Assign_8_On()
    {
        Key_Manager.Instance.ChangeKey(7);
    }
    private void Assign_9_On()
    {
        Key_Manager.Instance.ChangeKey(8);
    }
    private void Assign_10_On()
    {
        Key_Manager.Instance.ChangeKey(9);
    }
    private void Assign_11_On()
    {
        Key_Manager.Instance.ChangeKey(10);
    }
}
