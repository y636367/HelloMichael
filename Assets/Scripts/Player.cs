using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Transactions;
using System.ComponentModel;

public class Player : MonoBehaviour
{
    static public Player Instance;

    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeRun; //달리기 키
    [SerializeField]
    private KeyCode KeyCodeCrouch; //앉기 키
    [SerializeField]
    private KeyCode KeyCodeZoom; //확대 키
    [SerializeField]
    private KeyCode KeyCodeFoward; //전방
    [SerializeField]
    private KeyCode KeyCodeBackWard; //후방
    [SerializeField]
    private KeyCode KeyCodeLeft; //왼쪽
    [SerializeField]
    private KeyCode KeyCodeRight; //오른쪽

    [Header("Zoom")]
    [SerializeField]
    private float zoom_in;
    [SerializeField]
    private float zoom_out;
    [SerializeField]
    private float smooth;

    [Header("FearGauge")]
    private float gague_Max = 100;
    [SerializeField]
    private Slider Bar = null;
    [SerializeField]
    private float current_gague;

    [Header("Life")]
    private float Life_Max = 100;
    [SerializeField]
    private float current_life;
    [SerializeField]
    public Image Blood_screen = null;
    [SerializeField]
    private GameObject Death_canvas = null;

    [SerializeField]
    private float height; //Player 높이
    [SerializeField]
    private float CrouchHeight; //앉은 높이
    [SerializeField]
    private float StandingHeight; //서있는 높이

    private Camera_Scripts rotateToMouse;
    private PlayerMovement moveMent;
    private Status status;
    private Flashlight flashlight;
    public Crawler crawler;

    public bool FragmentGet = false;
    public bool HammerGet = false;
    public bool FlashGet = false;
    public bool DollGet = false;
    public bool Move_Ok = false;
    public bool See_Michel = false;
    public bool Scene_Change = false;
    public bool Now_Chat = false;
    public bool RemoteGet = false;
    public bool Move_Check = false;

    public bool isRun = false;
    public bool isCrouch = false;
    public bool isZoom = false;

    public bool survive = false;

    private bool Recovery = false;
    private float Re_charging = 0f;

    public bool death = false;

    [Header("Sounds")]
    [SerializeField]
    private string breathing_Low;
    [SerializeField]
    private string breathing_High;

    private float breat_Count = 7f;
    private float last_Count;
    private float timepassed = 0.0f;
    private bool danger = false;
    private float Life_Re_Back = 3.5f;
    private bool Re_Life_Check = false;
    private void Awake()
    {
        Cursor_unvisiable();

        current_gague = gague_Max;
        current_life = Life_Max;

        rotateToMouse = FindObjectOfType<Camera_Scripts>();
        moveMent = GetComponent<PlayerMovement>();
        status = GetComponent<Status>();
        flashlight = FindObjectOfType<Flashlight>();

        try
        {
            Blood_screen.color = new Color(Blood_screen.color.r, Blood_screen.color.g, Blood_screen.color.b, 0);
        }
        catch (NullReferenceException) { }

        keyCodeRun = KeySetting.keys[(KeyAction)4];
        KeyCodeCrouch = KeySetting.keys[(KeyAction)5];
        KeyCodeZoom = KeySetting.keys[(KeyAction)7];

        KeyCodeFoward = KeySetting.keys[(KeyAction)0];
        KeyCodeBackWard = KeySetting.keys[(KeyAction)1];
        KeyCodeLeft = KeySetting.keys[(KeyAction)2];
        KeyCodeRight = KeySetting.keys[(KeyAction)3];

        last_Count = breat_Count;
    }
    public void Cursor_visiable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Cursor_unvisiable()
    {
        Cursor.visible = false;
        //커서 감추기
        Cursor.lockState = CursorLockMode.Locked;
        //위치 고정
    }
    void Update()
    {
        if (!GameManager.Instance.Option_)
        {
            if (death != true)
            {
                if (Move_Ok)
                {
                    Crouching();
                    UpdateMove();
                }
                if (!Scene_Change)
                {
                    UpdateRotate();
                    Zoom();
                }
                if (survive)
                {
                    Fear();
                    if (current_life < 100 && Re_charging > 3f)
                    {
                        Life_Re();
                    }
                    else if (current_life > 100)
                    {
                        current_life = 100;
                        Re_charging = 0f;
                        Recovery = false;
                    }

                    if (Recovery == true)
                    {
                        Re_charging += Time.deltaTime;
                    }
                    Life_Breathing();
                    timepassed += Time.deltaTime;
                    if (timepassed >= breat_Count)
                    {
                        Breathing_S();
                        timepassed = 0.0f;
                    }
                    LIfe_Screen();
                }
            }
        }
        Moving_Check();
    }
    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, MouseY);
    }
    private void UpdateMove()
    {
        float w = 0, b = 0, l = 0, r = 0, x = 0, z = 0;

        if (Input.GetKey(KeyCodeFoward))
        {
            w = 1f;
        }
        if (Input.GetKey(KeyCodeBackWard))
        {
            b = -1f;
        }
        if (Input.GetKey(KeyCodeLeft))
        {
            l = -1f;
        }
        if (Input.GetKey(KeyCodeRight))
        {
            r = 1f;
        }

        x = l + r;
        z = w + b; ;

        // 이동 판단
        if (x != 0 || z != 0)
        {
            isRun = false;

            if (z > 0 && isCrouch != true) isRun = Input.GetKey(keyCodeRun);

            moveMent.MoveSpeed = isRun == true ? status.RunSpeed : status.WalkSpeed;
        }

        moveMent.MoveTo(new Vector3(x, 0, z).normalized);
    }
    private void Crouching() //앉기 확인
    {
        if (Input.GetKeyDown(KeyCodeCrouch))
        {
            if (isCrouch != true)
            {
                isCrouch = true;
                try
                {
                    Collision_Crawler CC = FindObjectOfType<Collision_Crawler>();
                    CC.Player_sound = false;
                }
                catch (NullReferenceException) { }
            }
            else
            {
                isCrouch = false;
            }
        }

        if (isCrouch)
        {
            moveMent.Crouchto(CrouchHeight);
        }
        else
        {
            moveMent.Crouchto_back(StandingHeight);
        }
    }
    private void Zoom()
    {
        isZoom = Input.GetKey(KeyCodeZoom);

        if (isZoom)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom_in, Time.deltaTime * smooth);
        }
        else
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom_out, Time.deltaTime * smooth);
    }
    public void Fear()
    {
        if (survive)
        {
            try
            {
                if (!flashlight.Check)
                {
                    if (current_gague > 0)
                    {
                        Bar.value = current_gague -= 10 * Time.deltaTime;
                        Life_Re_Back = 3.5f;
                    }
                    else if (current_gague <= 0)
                    {
                        Bar.value = current_gague = 0.0f;
                        Life_Re_Back = 3.5f;
                    }
                }
                else
                {
                    if (current_gague < gague_Max && current_gague >= 0)
                    {
                        if (!Re_Life_Check)
                        {
                            Life_Re_Back -= Time.deltaTime;
                            if (Life_Re_Back <= 0)
                            {
                                Re_Life_Check = true;
                                Life_Re_Back = 3.5f;
                            }
                        }
                        else
                        {
                            Bar.value = current_gague += 8.5f * Time.deltaTime;
                            if (current_gague >= gague_Max)
                                Re_Life_Check = false;
                        }
                    }
                }
                if (current_gague <= 0 && !flashlight.Check)
                {
                    Life(10);
                }
            }
            catch (NullReferenceException)
            {
            }
        }
    }
    private void Life_Re()
    {
        if (flashlight.Check == true)
        {
            current_life += 10 * Time.deltaTime;
        }
    }
    public bool Life(int Multy)
    {
        current_life -= Multy * Time.deltaTime;

        Recovery = true;
        Re_charging = 0f;

        if (current_life <= 0)
        {
            Move_Ok = false;
            death = true;
            GameManager.Instance.Death();
            return false;
        }
        return true;
    }
    private void LIfe_Screen()
    {
        try
        {
            Color color = Blood_screen.color;
            color.a = 1.0f - (current_life * (1.0f / 100.0f));
            Blood_screen.color = color;
        }
        catch (NullReferenceException) { }
    }
    public void Life_Screen_Re()
    {
        current_life = 100f;
        Bar.value = current_gague = gague_Max;

        Color color = Blood_screen.color;
        color.a = 0.0f;
        Blood_screen.color = color;

        Blood_screen.gameObject.SetActive(true);
    }
    public void Life_Survivie()
    {
        current_life = 100f;
        Bar.value = current_gague = gague_Max;
        Blood_screen.gameObject.SetActive(false);
    }
    public void Get_Data()
    {
        FlashGet = sceneManager.Instance.Flash_Data;
        DollGet = sceneManager.Instance.Doll_Data;
    }
    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Get_Data();
    }

    void OnDisable()
    {
        // 델리게이트 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void Stading()
    {
        if (isCrouch)
        {
            moveMent.Crouchto_back(StandingHeight);
            isCrouch = false;
        }
    }
    public void Set_Key()
    {
        keyCodeRun = KeySetting.keys[(KeyAction)4];
        KeyCodeCrouch = KeySetting.keys[(KeyAction)5];
        KeyCodeZoom = KeySetting.keys[(KeyAction)7];

        KeyCodeFoward = KeySetting.keys[(KeyAction)0];
        KeyCodeBackWard = KeySetting.keys[(KeyAction)1];
        KeyCodeLeft = KeySetting.keys[(KeyAction)2];
        KeyCodeRight = KeySetting.keys[(KeyAction)3];
    }
    private void Life_Breathing()
    {
        if (current_life <= 100 && current_life >= 80)
        {
            breat_Count = 8f;
            danger = false;
        }
        else if (current_life <= 79 && current_life >= 66)
        {
            breat_Count = 5.9f;
            danger = false;
        }
        else if (current_life <= 65 && current_life >= 46)
        {
            breat_Count = 3.3f;
            danger = false;
        }
        else if (current_life <= 45 && current_life >= 26)
        {
            breat_Count = 1.6f;
            danger = true;
        }
        else if (current_life <= 25 && current_life >= 16)
        {
            breat_Count = 0.8f;
            danger = true;
        }
        else if (current_life <= 15 && current_life > 0)
        {
            breat_Count = 0.45f;
            danger = true;
        }
    }
    private void Breathing_S()
    {
        if (danger)
        {
            soundManager.Instance.PlaySoundEffect(breathing_High);
        }
        else
        {
            soundManager.Instance.PlaySoundEffect(breathing_Low);
        }
    }
    private void Moving_Check()
    {
        if (!isCrouch)
        {
            if (Input.GetKey(KeyCodeFoward) || Input.GetKey(KeyCodeBackWard) || Input.GetKey(KeyCodeLeft) || Input.GetKey(KeyCodeRight))
            {
                Move_Check = true;
                try
                {
                    crawler.Run_previous_player = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                }
                catch (NullReferenceException) { }
            }
            else
                Move_Check = false;
        }
        else
            Move_Check = false;
    }
}

