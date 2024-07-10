using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    public int list_num;

    [SerializeField]
    public GameObject[] turn_Off_list = null;
    [SerializeField]
    private TMP_Text Timer;
    [SerializeField]
    private TMP_Text Object_num;

    public int Stack = 0;

    public bool Clear_Check = false;

    public int camera_NUM;

    [SerializeField]
    public bool TimeOn = false;

    public float Minute = 5;
    public float Current_Minute;

    [SerializeField]
    private float Second = 0;

    public bool Game_Clear = false;
    public bool Save_Point = false;
    public bool Menu_Set = true;
    public bool Back_Point = false;
    public bool Option_ = false;
    public bool Dont_Option = true;
    public bool Survive_Succes = false;

    public Player player;
    HitRayCast hit;
    S_Zones s_Zones;
    Dynamic_Objects DO;
    Flashlight flashlight;
    S_Zones SZ;
    Batterys batterys;
    Michel_Manager MM;
    Michel_Manager_ MM_;
    CLown_Manager CM;
    Crawler crawler;
    Crawler_Manager crawler_Manager;
    Death_Cam death_cam;
    Re_Match_Data RMD;
    Re_Start_Fade RSF;
    Option_Ingame OI;

    [SerializeField]
    private KeyCode Pause; // 일시정지

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        Game_Clear = false;
        Save_Point = false;

        Dont_Option = true;

        Current_Minute = Minute;

        Pause = KeySetting.keys[(KeyAction)10];
    }
    void Start()
    {
        player = FindObjectOfType<Player>();
        hit = FindObjectOfType<HitRayCast>();
    }
    void Update()
    {
        if (!Menu_Set)
        {
            if (!player.death)
            {
                if (Input.GetKeyDown(Pause))
                {
                    if (Dont_Option)
                    {
                        if (!Option_)
                        {
                            Option_ = true;
                            player.Cursor_visiable();
                            player.Move_Ok = false;
                            player.Scene_Change = true;
                            Key_Manager.Instance.Check = true;
                            soundManager.Instance.Pasue();
                            OI.Option_Panel_On();
                        }
                        else
                        {
                            Option_ = false;
                            player.Cursor_unvisiable();
                            if (!player.Now_Chat)
                            {
                                player.Move_Ok = true;
                            }
                            player.Scene_Change = false;
                            Key_Manager.Instance.Check = false;
                            soundManager.Instance.Play_Re();
                            OI.ESC_key_Menu();
                        }
                    }
                }
            }
            if (Clear_Check)
            {
                ChatController.instance.Clean_List();
                Clear_Check = false;
            }

            if (TimeOn)
            {
                Timer.gameObject.SetActive(true);
                Timer_On();
            }
        }
    }
    public void Return_Menu_Option()
    {
        player.Cursor_unvisiable();
        if (!player.Now_Chat)
        {
            player.Move_Ok = true;
        }
        player.Scene_Change = false;
    }
    public void Check_Update()
    {
        Clear_Check = true;
    }
    public void Toy_Stack()
    {
        Toy_Box.instance.Stack_Toy(Stack);
        Stack-=1;
        Object_num.text = Stack.ToString();
        if (Stack == 0)
        {
            s_Zones = FindObjectOfType<S_Zones>();
            Object_num.gameObject.SetActive(false);
            hit = FindObjectOfType<HitRayCast>();
            hit.Clear = false;
            s_Zones.Story_3();
            Check_Update();
        }
    }
    public void Object_list_On()
    {
        Object_num.gameObject.SetActive(true);
        Object_num.text = Stack.ToString();
    }
    public void Object_list_match()
    {
        GameObject Canvas_ = GameObject.FindGameObjectWithTag("Canvas_");
        GameObject UI_Canvas = GameObject.FindGameObjectWithTag("UI_Canvas");
        GameObject To_do_list = UI_Canvas.transform.Find("To_do_List").gameObject;
        Object_num = To_do_list.transform.Find("Num").GetComponent<TMP_Text>();
        Timer = UI_Canvas.transform.Find("Timer").GetComponent<TMP_Text>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        GameObject Head = player.transform.Find("Head").gameObject;
        GameObject Main = Head.transform.Find("Main Camera").gameObject;

        try
        {
            OI = Canvas_.GetComponent<Option_Ingame>();
            death_cam = Main.transform.Find("Death_Cam").gameObject.GetComponent<Death_Cam>();
        }
        catch (NullReferenceException) { }
    }
    public void Timer_On()
    {
        if (Second > 10)
        {
            Timer.text = ((int)Minute).ToString() + ":" + ((int)Second).ToString();
        }
        else
            Timer.text = ((int)Minute).ToString() + ":" + "0" + ((int)Second).ToString();

        if(player.Move_Ok)
            Second -= Time.deltaTime;

        if (Second < 0)
        {
            Second = 59.9f;
            Minute -= 1;
        }

        if (Minute < 0)
        {
            TimeOn = false;
            Timer.gameObject.SetActive(false);

            DO = FindObjectOfType<Dynamic_Objects>();
            DO.All_Lights_On();
            DO.Last_Door();

            flashlight= FindObjectOfType<Flashlight>();
            flashlight.Flash_Drop();

            SZ=FindObjectOfType<S_Zones>();
            SZ.Story_9();

            batterys=FindObjectOfType<Batterys>();
            batterys.Stop_Battery();

            try
            {
                MM = FindObjectOfType<Michel_Manager>();
                MM.Stop_Game();
            }
            catch (NullReferenceException) { }

            try
            {
                MM_ = FindObjectOfType<Michel_Manager_>();
                MM_.Stop_Game();
            }
            catch (NullReferenceException) { }

            try
            {
                CM = FindObjectOfType<CLown_Manager>();
                CM.Stop_Game();
            }
            catch(NullReferenceException) { }

            try
            {
                crawler = FindObjectOfType<Crawler>();
                crawler.Stop_Game();
            }
            catch (NullReferenceException) { }

            player.survive = false;
            player.Life_Survivie();

            Survive_Succes = true;

            ChatController.instance.Clean_List();
        }
    }
    public void Death()
    {
        player.death = true;
        player.Move_Ok = false;

        death_cam.Whoa();

        TimeOn = false;
        Timer.gameObject.SetActive(false);

        batterys = FindObjectOfType<Batterys>();
        batterys.Stop_Battery();

        try
        {
            MM = FindObjectOfType<Michel_Manager>();
            MM.Stop_Game();

            MM_ = FindObjectOfType<Michel_Manager_>();
            MM_.Stop_Game();

            CM = FindObjectOfType<CLown_Manager>();
            CM.Stop_Game();

            crawler = FindObjectOfType<Crawler>();
            crawler.Stop_Game();

        }
        catch (NullReferenceException) { }

        flashlight = FindObjectOfType<Flashlight>();
        flashlight.Flash_Drop();

        ChatController.instance.Clean_List();

        player.Blood_screen.gameObject.SetActive(false);

        hit.Range_Set();

        soundManager.Instance.StopAllSoundBGM();
        soundManager.Instance.StopAllSoundEffect();

        Goast_Surprise GS = FindObjectOfType<Goast_Surprise>();
        GS.Death_S();
    }
    public void Re_Setting_Player()
    {
        DO = FindObjectOfType<Dynamic_Objects>();
        DO.All_Cabinet_Close();
        DO.All_Chest_Close();
        DO.All_Doors_Close();
        DO.All_Doors_UnLock();

        player.Cursor_unvisiable();

        player.Move_Ok = true;
        player.Life_Screen_Re();

        if (flashlight == null)
        {
            GameObject Head = GameObject.FindGameObjectWithTag("Player_Head");
            flashlight = Head.transform.Find("Flashlight").gameObject.GetComponent<Flashlight>();
        }
        RMD = FindObjectOfType<Re_Match_Data>();
        RMD.Get_Flashlight(flashlight);

        player.death = false;
        player.Stading();

        player.Move_Ok = false;
    }
    public void Re_Back_Setting()
    {
        DO = FindObjectOfType<Dynamic_Objects>();
        DO.All_Cabinet_Close();
        DO.All_Chest_Close();
        DO.All_Doors_Close();
        DO.All_Doors_UnLock();

        player.Cursor_unvisiable();

        player.Move_Ok = true;
        player.Life_Screen_Re();

        player.death = false;
        player.Stading();

        player.Move_Ok = false;
        player.survive = false;
        player.Move_Ok = true;

        flashlight.Re_set();
    }
    public void Re_Play()
    {
        TimeOn = true;
        Minute = Current_Minute;
        Second = 0f;

        player.FlashGet = true;
        flashlight.Flash_Get();
        RMD.Set_Data_Flashlight();

        Timer.gameObject.SetActive(true);

        if (batterys == null)
        {
            batterys=FindObjectOfType<Batterys>();
        }
        batterys.Start_Battery();

        MM = FindObjectOfType<Michel_Manager>();
        MM.Start = true;
        MM_ = FindObjectOfType<Michel_Manager_>();
        MM_.Start = true;

        CM = FindObjectOfType<CLown_Manager>();
        CM.Start = true;

        crawler_Manager = FindObjectOfType<Crawler_Manager>();
        crawler_Manager.Setting_postion();
        crawler_Manager.crawler_On();

        hit.Range_ReSet();

        player.survive = true;

        RSF = FindObjectOfType<Re_Start_Fade>();
        RSF.Start_RE_Fade();

        player.Move_Ok = true;
    }
    private bool Scene_Check()
    {
        if (sceneManager.Instance.Start_Check)
        {
            Menu_Set = true;
            return true;
        }
        else
        {
            Menu_Set = false;
            return false;
        }
    }
    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Option_ = false;
        if (!Scene_Check())
            Object_list_match();
        else
            Cursor_On();
    }
    void OnDisable()
    {
        // 델리게이트 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void Cursor_On()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Get_Player(Player t_player)
    {
        player = t_player;
    }
    public void Set_Key()
    {
        Pause = KeySetting.keys[(KeyAction)10];
    }
}