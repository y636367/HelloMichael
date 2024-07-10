using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class OptionManager : MonoBehaviour
{
    static public OptionManager Instance;

    [Header("Objects")]
    [SerializeField]
    private Key_Text Key_Text = null;

    [Header("GameOption")]
    public bool Difficulty = false;

    [Header("ControlOption")]
    public bool Mouse_Invert = false;
    [SerializeField]
    private TMP_Text Invert;
    public Slider Mouse_Smooth;
    private float Smooth_value = 0f;
    [SerializeField]
    public float current_smooth;

    [Header("VideoOption")]
    private int Shadow_Quality; // 1~3 3이 고해상도 텍스쳐 사용
    private int Texture_Quality; // 1,3,5 5가 고해상도 텍스쳐 사용

    public int Current_S_Quality;
    public int Current_T_Quality;

    [SerializeField]
    private TMP_Dropdown resolution;
    List<Resolution> resolutions = new List<Resolution>();

    private int current_resolution_num = -1;

    FullScreenMode fullScreenMode;

    [SerializeField]
    private bool screenbutton; // 전체화면 체크

    [SerializeField]
    private TMP_Text Screen_Mode;

    int resolutionNum;
    private string R_num = "Resolution";

    private string Texture_ = "Texture";
    private string Shadow_ = "Shadow";

    private string Mode = "ScreenMode";
    // 0 window, 1 fullscreen

    private int setWidth = 1920;
    private int setHeight = 1080;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            PlayerPrefs.SetInt(R_num, -5);
            resolutionNum = PlayerPrefs.GetInt(R_num);

            Mouse_Smooth = Mouse_Smooth.GetComponent<Slider>();
            Mouse_Smooth.value = Smooth_value;
            current_smooth = Mouse_Smooth.value;

            Set_Shadow_High();
            Set_Texture_High();
            SetResolution();
            Set_Mode();

            Set_Resolution_Default();
            ChoiceButtion();

        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        SetResolution();
        Get_Mode();
        Set_Screen();
        Set_Resolution_Num();
        ChoiceButtion();
    }
    public void Difficulty_Nomal()
    {
        Difficulty = false;
        GameManager.Instance.Current_Minute = GameManager.Instance.Minute = 5f;
        
    }
    public void Difficulty_Hard()
    {
        Difficulty = true;
        GameManager.Instance.Current_Minute = GameManager.Instance.Minute = 7f;
    }
    public void Mouse_Invert_()
    {
        if (!Mouse_Invert)
        {
            Mouse_Invert = true;
            Invert.text = "on";
        }
        else
        {
            Mouse_Invert = false;
            Invert.text = "off";
        }

        try
        {
            Camera_Scripts CS=GameObject.FindObjectOfType<Camera_Scripts>();
            CS.Revers();
        }
        catch (NullReferenceException) { }
    }
    public void Set_Mouse_Smooth(float _value)
    {
        Mouse_Smooth.maxValue = 4.999f;
        Mouse_Smooth.minValue = -4.999f;

        current_smooth = _value = Mouse_Smooth.value;

        try
        {
            Camera_Scripts CS = GameObject.FindObjectOfType<Camera_Scripts>();
            CS.Get_Sensitivity(current_smooth);

            try
            {
                Set_Value set_value = GameObject.FindObjectOfType<Set_Value>();
                set_value.Get_Mouse_S();
            }
            catch (NullReferenceException) { }
            try
            {
                Option_Value option_value = GameObject.FindObjectOfType<Option_Value>();
                option_value.Get_Mouse_S();
            }
            catch (NullReferenceException) { }
        }
        catch(NullReferenceException) { }
    }
    public void SetResolution()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate >= 60)
            {
                Resolution currentResolution = Screen.resolutions[i];
                bool addResolution = true;

                // resolutions 리스트에 이미 같은 비율의 해상도가 있는지 확인
                for (int j = 0; j < resolutions.Count; j++)
                {
                    Resolution existingResolution = resolutions[j];
                    if (currentResolution.width == existingResolution.width &&
                        currentResolution.height == existingResolution.height)
                    {
                        // 이미 같은 비율의 해상도가 있고, 현재 해상도의 refreshRate가 더 높다면 갱신
                        if (currentResolution.refreshRate > existingResolution.refreshRate)
                        {
                            resolutions.Remove(resolutions[j]);
                        }
                        else
                        {
                            addResolution = false; // 현재 해상도를 추가하지 않음
                        }
                    }
                }

                if (addResolution)
                {
                    resolutions.Add(currentResolution); // 현재 해상도를 resolutions 리스트에 추가
                }
            }
        }

        resolution.options.Clear();

        int optionValue = 0;

        foreach (Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
            resolution.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
            {
                resolution.value = optionValue;
            }
            optionValue++;
        }
    }

    private void Set_Mode()
    {
        screenbutton = true;
        PlayerPrefs.SetInt(Mode, 1);
    }
    private void Get_Mode()
    {
        int t_Mode= PlayerPrefs.GetInt(Mode);

        switch (t_Mode)
        {
            case 0:
                fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }

    public void OptionChange(int x)
    {
        resolutionNum = x;
        PlayerPrefs.SetInt(R_num,resolutionNum);
    }

    public void ChoiceButtion()
    {
        Texture_Quality = Current_T_Quality = PlayerPrefs.GetInt(Texture_);
        Shadow_Quality = Current_S_Quality = PlayerPrefs.GetInt(Shadow_);
        //Prefs로 불러옴

        QualitySettings.SetQualityLevel(Current_T_Quality, true);
        //텍스쳐 품질 적용
        switch (Current_S_Quality)
        {
            case 0:
                QualitySettings.shadows = UnityEngine.ShadowQuality.Disable;
                QualitySettings.shadowResolution = ShadowResolution.Low;
                break;
            case 2:
                QualitySettings.shadows = UnityEngine.ShadowQuality.All;
                QualitySettings.shadowResolution = ShadowResolution.Medium;
                break;
            case 3:
                QualitySettings.shadows = UnityEngine.ShadowQuality.All;
                QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
                break;
        }
        QualitySettings.shadowResolution = (ShadowResolution)Shadow_Quality;
        //그림자 텍스쳐 적용

        resolutionNum = PlayerPrefs.GetInt(R_num);

        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullScreenMode);
        //Screen 전체 옵션 적용

        if ((float)setWidth / setHeight < (float)resolutions[resolutionNum].width / resolutions[resolutionNum].height) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)resolutions[resolutionNum].width / resolutions[resolutionNum].height); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)resolutions[resolutionNum].width / resolutions[resolutionNum].height) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
        Debug.Log("Width " + resolutions[resolutionNum].width + " Height " + resolutions[resolutionNum].height + " Mode " + fullScreenMode);
    }
    public void FullScreenCheck(bool isFull)
    {
        fullScreenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    private void Set_Screen()
    {
        int t_Mode = PlayerPrefs.GetInt(Mode);

        switch (t_Mode)
        {
            case 0:
                screenbutton = false;
                break;
            case 1:
                screenbutton = true;
                break;
        }

        if (screenbutton)
        {
            Screen_Mode.text = "on";
            PlayerPrefs.SetInt(Mode, 1);
            fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen_Mode.text = "off";
            PlayerPrefs.SetInt(Mode, 0);
            fullScreenMode = FullScreenMode.Windowed;
        }
    }
    public void Screen_Mode_Text()
    {
        if (!screenbutton)
        {
            screenbutton = true;
            Screen_Mode.text = "on";
            PlayerPrefs.SetInt(Mode, 1);
            FullScreenCheck(screenbutton);
        }
        else
        {
            screenbutton = false;
            Screen_Mode.text = "off";
            PlayerPrefs.SetInt(Mode, 0);
            FullScreenCheck(screenbutton);
        }
    }
    public void Set_Shadow_Off()
    {      
        Current_S_Quality = Shadow_Quality = 0;
        PlayerPrefs.SetInt(Shadow_, 0);
    }
    public void Set_Shadow_Middle()
    {
        Current_S_Quality = Shadow_Quality = 2;
        PlayerPrefs.SetInt(Shadow_, 2);
    }
    public void Set_Shadow_High()
    {
        Current_S_Quality = Shadow_Quality = 3;
        PlayerPrefs.SetInt(Shadow_, 3);
    }
    public void Set_Texture_Low()
    {
        Current_T_Quality = Texture_Quality = 2;
        PlayerPrefs.SetInt(Texture_, 2);
    }
    public void Set_Texture_Middle()
    {
        Current_T_Quality = Texture_Quality = 3;
        PlayerPrefs.SetInt(Texture_, 3);
    }
    public void Set_Texture_High()
    {
        Current_T_Quality = Texture_Quality = 5;
        PlayerPrefs.SetInt(Texture_, 5);
    }
    public void Set_Again()
    {
        GameObject Start_Main = GameObject.FindGameObjectWithTag("Main_Menu");
        GameObject Option_Panel = Start_Main.transform.Find("Canv_Options").gameObject;
        GameObject Panels = Option_Panel.transform.Find("PANELS").gameObject;

        #region Set_Control
        GameObject Panel_Control = Panels.transform.Find("PanelControls").gameObject;
        GameObject Invert_Btn = Panel_Control.transform.Find("Inverse_Btn").gameObject;

        Invert = Invert_Btn.transform.Find("invertmousetext").gameObject.GetComponent<TMP_Text>();
        Mouse_Smooth = Panel_Control.transform.Find("SmoothingSlider").gameObject.GetComponent<Slider>();
        #endregion

        #region Set_Video
        GameObject Panel_Video = Panels.transform.Find("PanelVideo").gameObject;
        GameObject Full_Screen_Btn = Panel_Video.transform.Find("FullScreen_Btn").gameObject;

        resolution = Panel_Video.transform.Find("Resolution_Drop").gameObject.GetComponent<TMP_Dropdown>();
        Screen_Mode = Full_Screen_Btn.transform.Find("fullscreentext").gameObject.GetComponent<TMP_Text>();
        #endregion

        Key_Text.Set_Text();
    }
    public void Set_Again_2()
    {
        GameObject Canvas_ = GameObject.FindGameObjectWithTag("Canvas_");
        GameObject Canv_Options = Canvas_.transform.Find("Canv_Options").gameObject;
        GameObject Panels = Canv_Options.transform.Find("PANELS").gameObject;

        #region Set_Game_Control
        GameObject Panel_Game_Control = Panels.transform.Find("PanelGame_Controls").gameObject;
        GameObject Invert_Btn = Panel_Game_Control.transform.Find("Inverse_Btn").gameObject;

        Invert = Invert_Btn.transform.Find("invertmousetext").gameObject.GetComponent<TMP_Text>();
        Mouse_Smooth = Panel_Game_Control.transform.Find("SmoothingSlider").gameObject.GetComponent<Slider>();
        #endregion

        #region Set_Video
        GameObject Panel_Video = Panels.transform.Find("PanelVideo").gameObject;
        GameObject Full_Screen_Btn = Panel_Video.transform.Find("FullScreen_Btn").gameObject;

        Screen_Mode = Full_Screen_Btn.transform.Find("fullscreentext").gameObject.GetComponent<TMP_Text>();
        #endregion

        Key_Text.Set_Text_2();
    }
    private void Set_Resolution_Default()
    {
        current_resolution_num = PlayerPrefs.GetInt(R_num);

        if (current_resolution_num != -5)
        {
            resolution.value = current_resolution_num;
            resolution.Select();
            resolution.RefreshShownValue();

            OptionChange(current_resolution_num);
        }
        else
        {
            var Last_Num = (int)(resolutions.Count - 1);

            resolution.value = Last_Num;
            resolution.Select();
            resolution.RefreshShownValue();

            OptionChange(Last_Num);
        }
    }
    private void Set_Resolution_Num()
    {
        resolution.value = PlayerPrefs.GetInt(R_num);
        resolution.Select();
        resolution.RefreshShownValue();
    }
    public void Scene_Set_Resolution()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullScreenMode);
        //Screen 전체 옵션 적용      

        if ((float)setWidth / setHeight < (float)resolutions[resolutionNum].width / resolutions[resolutionNum].height) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)resolutions[resolutionNum].width / resolutions[resolutionNum].height); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)resolutions[resolutionNum].width / resolutions[resolutionNum].height) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }
    public void Scene_Set_Resolution(Camera t_camera)
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullScreenMode);
        //Screen 전체 옵션 적용      

        if ((float)setWidth / setHeight < (float)resolutions[resolutionNum].width / resolutions[resolutionNum].height) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)resolutions[resolutionNum].width / resolutions[resolutionNum].height); // 새로운 너비
            t_camera.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)resolutions[resolutionNum].width / resolutions[resolutionNum].height) / ((float)setWidth / setHeight); // 새로운 높이
            t_camera.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }
}