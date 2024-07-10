using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRayCast : MonoBehaviour
{
    Camera mainCamera;

    private Ray ray;
    [SerializeField]
    private RaycastHit hit; //RayCast에 Hit된 객체

    [SerializeField]
    public GameObject Focus_On = null;

    [SerializeField]
    private GameObject Focus_Battery = null;

    [SerializeField]
    private float Range = 5;

    [SerializeField]
    public float Hit_Distance;

    bool Hit_Check = false;
    bool Dynamic_Check = false;

    public int Story = 0;
    public bool Clear = false;

    [SerializeField]
    private KeyCode KeyCodeInterction; //상호작용 키

    [SerializeField]
    private bool Delay_Check = false;

    #region Object
    private Door door;
    private Light_s light;
    private Flashlight flash;
    private Lid lid;
    private Chest chest;
    private Cabinet_Bottom cabinet;
    private Michel michel;
    private Trash trash;
    private Start_Play SP;
    private Flash_Script FS;
    private Light_Range LR;
    private Michel_Surprise MS;
    private Michel_Manager MM;
    private Michel_Manager_ MM_;
    private Hammer hammer;
    private Grab_Hammer GH;
    private LagDoll_Frag LF;
    private Dead_Goast DG;
    private Book_Number_Check BNC;
    [SerializeField]
    private Player player;
    private Batterys batterys;
    #endregion

    [Header("Sounds")]
    [SerializeField]
    private string Zone_Door_Open;
    [SerializeField]
    private string Book_Open;
    [SerializeField]
    private string Battery_Get;
    [SerializeField]
    private string Object_Get;
    [SerializeField]
    private string Object_Drop;
    [SerializeField]
    private string Flash_Get;
    [SerializeField]
    private string Screaming_Last;
    void Awake()
    {
        if(Delay_Check)
            Invoke("On_AudioListener", 1.8f);

        mainCamera = Camera.main;

        door = FindObjectOfType<Door>();
        light = FindObjectOfType<Light_s>();
        chest = FindObjectOfType<Chest>();
        cabinet = FindObjectOfType<Cabinet_Bottom>();
        player = FindObjectOfType<Player>();
        batterys = FindObjectOfType<Batterys>();
        michel = FindObjectOfType<Michel>();
        SP= FindObjectOfType<Start_Play>();
        FS=FindObjectOfType<Flash_Script>();
        MM=FindObjectOfType<Michel_Manager>();
        MM_ = FindObjectOfType<Michel_Manager_>();
        hammer =FindObjectOfType<Hammer>();
        BNC = FindObjectOfType<Book_Number_Check>();

        flash = FindObjectOfType<Flashlight>();
        lid = FindObjectOfType<Lid>();

        KeyCodeInterction = KeySetting.keys[(KeyAction)6];
    }
    void Update()
    {
        ZoneChecking();
    }

    void ZoneChecking()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Crawler"))
            | (1 << LayerMask.NameToLayer("Sounds_Zone")) | (1 << LayerMask.NameToLayer("ScriptOn_Zone"));
        layerMask = ~layerMask;

        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        try
        {
            LR = FindObjectOfType<Light_Range>();
            LR.light_Range(hit.distance);
        }
        catch (NullReferenceException) { }

        if (Physics.Raycast(ray, out hit, Range, layerMask))
        {

            Hit_Check = true;
            if (!hit.transform.CompareTag("Untagged") && !hit.transform.CompareTag("Ground") && !hit.transform.CompareTag("Grass")
                && !hit.transform.CompareTag("Stairs") && !hit.transform.CompareTag("Basement") && !hit.transform.CompareTag("Floor")
                && !hit.transform.CompareTag("Basement_stairs"))
            {
                Dynamic_Check = true;
            }
            else
                Dynamic_Check = false;
            if (player.Move_Ok)
                if (Input.GetKeyDown(KeyCodeInterction))
                {
                    if (hit.transform.CompareTag("Door"))
                    {
                        door.this_door(hit);
                        door.DoorAnime();
                    }
                    else if (hit.transform.CompareTag("Light"))
                    {
                        light.this_light(hit);
                        light.LightCheck();
                    }
                    else if (hit.transform.CompareTag("Lid"))
                    {
                        lid.Lid_animation();
                    }
                    else if (hit.transform.CompareTag("Destroy"))
                    {
                        soundManager.Instance.PlaySoundEffect(Flash_Get);
                        player.FlashGet = true;
                        GameManager.Instance.Back_Point = true;
                        FS.Grab_Flash();
                        flash.Flash_Get();
                    }
                    else if (hit.transform.CompareTag("Chest"))
                    {
                        chest.this_Chest(hit);
                        chest.ChestAnime();
                    }
                    else if (hit.transform.CompareTag("Cabinet"))
                    {
                        cabinet.this_Cabinet(hit);
                        cabinet.CabinetAnime();
                    }
                    else if (hit.transform.CompareTag("Zone"))
                    {
                        soundManager.Instance.StopAllSoundEffect();
                        soundManager.Instance.PlaySoundEffect(Zone_Door_Open);
                        soundManager.Instance.Sounds_BGM_Fade_Out();
                        sceneManager.Instance.Scene_Change();
                    }
                    else if (hit.transform.CompareTag("Trash"))
                    {
                        trash = FindObjectOfType<Trash>();
                        trash.Trash_();
                    }
                    else if (hit.transform.CompareTag("Michel"))
                    {
                        soundManager.Instance.PlaySoundEffect(Object_Get);
                        michel.Michel_get(hit);
                        michel.Grab_michel();
                    }
                    else if (hit.transform.CompareTag("Toy"))
                    {
                        if (Story == 1&&Clear==true)
                        {
                            soundManager.Instance.PlaySoundEffect(Object_Get);
                            Destroy(hit.transform.gameObject);
                            GameManager.Instance.Toy_Stack();
                        }
                    }
                    else if (hit.transform.CompareTag("Hammer"))
                    {
                        soundManager.Instance.PlaySoundEffect(Object_Get);
                        player.HammerGet = true;
                        player.DollGet = false;
                        hammer.Grab_Hammer();
                    }
                    else if (hit.transform.CompareTag("Frag"))
                    {
                        soundManager.Instance.PlaySoundEffect(Object_Get);
                        LF = FindObjectOfType<LagDoll_Frag>();
                        if (LF.Check)
                        {
                            LF.Next_Story_2();
                        }
                    }
                    else if (hit.transform.CompareTag("Dead_Trash"))
                    {
                        soundManager.Instance.PlaySoundEffect(Screaming_Last);
                        ChatController.instance.Clean_List();
                        DG =FindObjectOfType<Dead_Goast>();
                        DG.Start_Dead();
                    }
                    else if (hit.transform.CompareTag("RemoteControl"))
                    {
                        soundManager.Instance.PlaySoundEffect(Object_Get);
                        player.RemoteGet = true;
                        hit.transform.GetComponent<Chain>().Object_On();
                        hit.transform.gameObject.SetActive(false);
                    }
                    else if (hit.transform.CompareTag("Return_Remote"))
                    {
                        soundManager.Instance.PlaySoundEffect(Object_Drop);
                        player.RemoteGet = false;
                        hit.transform.GetComponent<Chain>().Object_On();
                        hit.transform.gameObject.SetActive(false);
                    }
                    else if (hit.transform.CompareTag("Guide_Book"))
                    {
                        soundManager.Instance.PlaySoundEffect(Book_Open);
                        BNC.List_Num(hit.transform.gameObject.GetComponent<Guide_Books>().BookNumber);
                    }
                    else if (hit.transform.CompareTag("Frame"))
                    {
                        hit.transform.GetComponent<Frame_Scripts>().Scripts();
                    }
                    if (player.FlashGet != false)
                    {
                        if (hit.transform.CompareTag("Battery"))
                        {
                            soundManager.Instance.PlaySoundEffect(Battery_Get);
                            flash.Battery_Counting();
                            batterys.Count += 1;
                            batterys.Get_Battery_num(hit.collider.GetComponent<Battery_numbering>().numbering);
                            batterys.Get_Floor_num(hit.collider.GetComponent<Battery_numbering>().floor);
                            batterys.Start_Battery();
                            hit.collider.gameObject.SetActive(false);
                        }
                    }
                }
                else if (hit.transform.CompareTag("Surprised"))
                {
                    SP.StP(hit);
                    SP.WaitSceond();
                }
                else if (hit.transform.CompareTag("Michel_surprise_1"))
                {
                    Goast_Surprise GS=FindObjectOfType<Goast_Surprise>();
                    GS.Micheal_S();

                    MS = FindObjectOfType<Michel_Surprise>();
                    MS.Set_Cam();
                    MS.Start_Cam();
                    MM.Re_Setting();
                    hit.transform.gameObject.SetActive(false);
                }
                else if (hit.transform.CompareTag("Michel_surprise_2"))
                {
                    Goast_Surprise GS = FindObjectOfType<Goast_Surprise>();
                    GS.Micheal_S();

                    MS = FindObjectOfType<Michel_Surprise>();
                    MS.Set_Cam();
                    MS.Start_Cam();
                    MM_.Re_Setting();
                    hit.transform.gameObject.SetActive(false);
                }
                else if (hit.transform.CompareTag("LagDoll"))
                {
                    GH = FindObjectOfType<Grab_Hammer>();
                    try
                    {
                        GH.fragment(hit);
                    }
                    catch (NullReferenceException) { }

                    player.See_Michel = true;
                }
                else if (!hit.transform.CompareTag("LagDoll"))
                {
                    player.See_Michel = false;
                }
        }
        else
            Hit_Check = false;

        if (Hit_Check == true && Dynamic_Check == true && ChatController.instance.Script_On == false
            && sceneManager.Instance.Scene_ing == false && player.death != true)
        {
            if (!hit.transform.CompareTag("Battery"))
            {
                Focus_On.SetActive(true);
                Focus_Battery.SetActive(false);
            }
            else
                Focus_Battery.SetActive(true);
        }
        else
        {
            Focus_On.SetActive(false);
            Focus_Battery.SetActive(false);
        }
    }
    public void Range_Set()
    {
        Range = 1000f;
    }
    public void Range_ReSet()
    {
        Range = 5f;
    }
    public void Set_Key()
    {
        KeyCodeInterction = KeySetting.keys[(KeyAction)6];
    }
    private void On_AudioListener()
    {
        mainCamera.GetComponent<AudioListener>().enabled = true;
    }
}
