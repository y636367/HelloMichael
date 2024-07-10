using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private GameObject light_object = null;
    [SerializeField]
    private GameObject Flash = null;
    [SerializeField]
    private GameObject UI= null;

    [SerializeField]
    private TMP_Text Battery = null;
    [SerializeField]
    private TMP_Text Timer= null;

    [SerializeField]
    private KeyCode KeyCodeSwitch;

    [SerializeField]
    private Player player;

    public int Battery_Count = 0;
    public float Flash_Timer = 30;

    public bool Check=false;
    bool no_battery = false;
    public bool First = true;

    [Header("Sounds")]
    [SerializeField]
    private string Flash_Switchs;
    void Awake()
    {
        Flash.SetActive(false);
        Battery_Count = 0;
        Flash_Timer= 30;

        player = FindObjectOfType<Player>();

        KeyCodeSwitch = KeySetting.keys[(KeyAction)9];
    }
    public void Flash_Get()
    {
        player = FindObjectOfType<Player>();
        this.player.FlashGet = true;
        Flash.SetActive(true);
        UI.SetActive(true);

        no_battery = false;
        light_object.SetActive(true);
        Check = true;
    }
    public void Flash_Drop()
    {
        player = FindObjectOfType<Player>();
        player.FlashGet = false;
        Flash.SetActive(false);
        UI.SetActive(false);
    }
    void Update()
    {
        if (player.FlashGet == true&&no_battery!=true)
        {
            if(Flash_Timer <= 30)
            {
                if (Flash_Timer > 0 && Check != false)
                {
                    if(player.Move_Ok)
                        Flash_Timer -= Time.deltaTime;
                }
                else if (Flash_Timer <= 0)
                {
                    Flash_Timer = 0;
                    Flash_Time();
                }
            }
            Flash_Switch();
        }

        Timer.text = Mathf.Round(Flash_Timer).ToString();
        Battery.text = string.Format("X{0}", Battery_Count);
    }
    private void Flash_Time()
    {
        if (Flash_Timer == 0 && Battery_Count == 0)
        {
            no_battery = true;
            light_object.SetActive(false);
            Check = false;
        }
        else if (Flash_Timer == 0 && no_battery!=true)
        {
            Battery_Count -= 1;
            Flash_Timer = Random.Range(8, 18);
        }
    }
    public void Battery_Counting()
    {
        Battery_Count += 1;
        no_battery = false;
    }
    private void Flash_Switch()
    {
        if (!GameManager.Instance.Option_)
        {
            if (Input.GetKeyDown(KeyCodeSwitch))
            {
                soundManager.Instance.PlaySoundEffect(Flash_Switchs);
                if (Check == true)
                {
                    light_object.SetActive(false);
                    Check = false;
                }
                else
                {
                    if (First == true)
                        First = false;
                    light_object.SetActive(true);
                    Check = true;
                }
            }
        }
    }
    public void Set_Key()
    {
        KeyCodeSwitch = KeySetting.keys[(KeyAction)9];
    }
    public void Re_set()
    {
        Battery_Count = 0;
        Flash_Timer = 30;
    }
}
