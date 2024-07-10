using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class sceneManager : MonoBehaviour
{
    static public sceneManager Instance;

    [SerializeField]
    private string[] SceneName = null;

    [SerializeField]
    private Image image;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private GameObject Focus_Potin = null;

    [SerializeField]
    private int i;

    public int j;

    [SerializeField]
    private Player player;

    public bool Scene_ing = false;

    public bool Flash_Data = false;
    public bool Doll_Data = false;

    public bool Start_Check = true;
    public bool Continue_Check = false;

    public bool First_Menu = true;

    public CameraManager CM;
    public StoryManager SM;
    public Re_data RD;
    public Re_Match_Data RMD;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if(Instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);          

        i = 0;
        Start_Check = true;
    }
    public void Re_Main()
    {
        i = 0;
        j = i;

        Start_Check = false;
        First_Menu = false;

        SceneManager.LoadScene(SceneName[i]);
    }
    private void Next_Scene()
    {
        if (!Continue_Check || GameManager.Instance.Survive_Succes)
        {
            i += 1;
            j = i;
        }
        else
        {
            i = 4;
            j = i;
        }

        if (i == 0)
            Start_Check = true;
        else
            Start_Check = false;

        SceneManager.LoadScene(SceneName[i]);
    }
    public void Fin_Game()
    {
        if (SceneName[i].Equals("Stage_Dead"))
        {
            i = 0;
            j = i;
            Start_Check = false;
            First_Menu = false;
        }
        GameManager.Instance.Game_Clear = true;
        SceneManager.LoadScene(SceneName[i]);
    }
    public void Start_Play_Button()
    {
        StartCoroutine(Fade_Out());
    }
    public void Scene_Change()
    {
        player.Move_Ok = false;
        player.Scene_Change = true;
        ChatController.instance.Clean_List();

        Player t_Data=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Flash_Data = t_Data.FlashGet;
        Doll_Data= t_Data.DollGet;

        StartCoroutine(Fade_Out());
    }
    public void Scene_Start()
    {
        CM = FindObjectOfType<CameraManager>();
        SM = FindObjectOfType<StoryManager>();
        player=FindObjectOfType<Player>();

        player.Scene_Change = true;
        player.Move_Ok = false;

        if (j == 4)
        {
            RD=FindObjectOfType<Re_data>();
            RD.Set_Position_Object();

            if (sceneManager.Instance.Continue_Check)
            {
                GameManager.Instance.Get_Player(player);
                Continue_Setting();
            }
        }

        StartCoroutine(Fade_In());
    }
    public IEnumerator Story_Fade_Out()
    {
        GameManager.Instance.Dont_Option = false;

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / Speed));
            yield return null;
        }
        if (j == 2)
            CM.B_return_Play();
        else
            CM.return_Play();
    }
    public IEnumerator Story_Fade_In()
    {
        yield return new WaitForSeconds(0.01f);
        player.Move_Ok = false;
        player.Scene_Change = true;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a >= 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / Speed));
            yield return null;
        }
        player.Move_Ok = true;
        player.Scene_Change = false;
        GameManager.Instance.Dont_Option = true;
    }
    public IEnumerator Camera_Fade_Out()
    {
        GameManager.Instance.Dont_Option = false;
        player.Move_Ok = false;
        player.Scene_Change = true;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / Speed));
            yield return null;
        }
        if (j == 2)
        {
            CM.B_CameraChange();
        }
        else
        {
            CM.CameraChange();
        }
    }
    public IEnumerator Camera_Fade_In()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a >= 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / Speed));
            yield return null;
        }
        if(j==2)
            SM.Choice_Story();

        GameManager.Instance.Dont_Option = true;
    }
    public IEnumerator Fade_Out() 
    {
        GameManager.Instance.Dont_Option = false;
        Scene_ing = true;

        if (Focus_Potin != null)
        {
            Focus_Potin.SetActive(false);
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / Speed));
            yield return null;
        }
        Next_Scene();
    }
    public IEnumerator Fade_In()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a >= 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / Speed));
            yield return null;
        }
        soundManager.Instance.return_BGM_Volume();
        soundManager.Instance.return_SFX_Volume();
        Scene_ing = false;
        player.Move_Ok = true;
        player.Scene_Change = false;
        GameManager.Instance.Dont_Option = true;
        if (Focus_Potin != null)
        {
            Focus_Potin.SetActive(true);
        }
    }
    private void Find_Focus()
    {
        try
        {
            Focus_Potin = GameObject.FindGameObjectWithTag("Focus_Base");
        }
        catch (NullReferenceException) { }
    }
    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!SceneName[i].Equals("Start_"))
        {
            Scene_Start();
            Find_Focus();
            Key_Manager.Instance.Check = false;
            OptionManager.Instance.Set_Again_2();
            soundManager.Instance.StopAllSoundBGM();
        }
        else
        {
            Not_Again();
            Key_Manager.Instance.Check = true;
            if (!First_Menu)
                OptionManager.Instance.Set_Again();
        }
    }

    void OnDisable() 
    {
        // 델리게이트 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void Not_Again()
    {
        Focus_Potin = null;
        player = null;
        Start_Check = true;
    }
    private void Continue_Setting()
    {
        RMD = FindObjectOfType<Re_Match_Data>();
        RMD.Get_Player(player);
        RMD.Set_Survive();
    }
    public void Go_Main()
    {
        i = 0;
        j = i;

        SceneManager.LoadScene(SceneName[i]);
    }
}
