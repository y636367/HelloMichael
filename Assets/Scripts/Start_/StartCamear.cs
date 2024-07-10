using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StartCamear : MonoBehaviour
{
    [SerializeField]
    private GameObject Guides;
    [SerializeField]
    private GameObject Head;
    [SerializeField]
    private Camera player_Head_Camera;
    [SerializeField]
    private GameObject[] Garbages;

    Player player;

    [Header("Sounds")]
    [SerializeField]
    private string CarDoor_Close;
    [SerializeField]
    private string Breath_Low;
    [SerializeField]
    private string Walk_1;
    [SerializeField]
    private string Walk_2;
    [SerializeField]
    private string Walk_3;
    [SerializeField]
    private string Crash;
    [SerializeField]
    private string Man_Oof_2;
    [SerializeField]
    private string Trash_Car;
    [SerializeField]
    private string Thumb_2;
    [SerializeField]
    private string Object_Drop;
    [SerializeField]
    private string Groaning;


    bool rotate = false;
    bool move = false;
    private void Awake()
    {
        player=FindObjectOfType<Player>();
    }
    private void LateUpdate()
    {
        if (!player.Scene_Change&&!rotate)
        {
            player.Scene_Change = true;
            rotate = true;
        }

        if (player.Move_Ok&&!move)
        {
            player.Move_Ok = false;
            move = true;
        }
    }
    private void Guide_On()
    {
        Guides.SetActive(true);

        player.Scene_Change = false;
        player.Move_Ok = true;
        Head.transform.localRotation = Quaternion.Euler(0, 0, 0);

        for(int i= 0; i < Garbages.Length; i++)
        {
            Garbages[i].SetActive(true);
        }
        audiolistener();
        Destroy(this.gameObject);
    }
    private void audiolistener()
    {
        player_Head_Camera.GetComponent<AudioListener>().enabled = true;
    }
    private void cardoor_close()
    {
        soundManager.Instance.PlaySoundEffect(CarDoor_Close);
    }
    private void breath_low()
    {
        soundManager.Instance.PlaySoundEffect(Breath_Low);
    }
    private void walk_1()
    {
        soundManager.Instance.PlaySoundEffect(Walk_1);
    }
    private void walk_2()
    {
        soundManager.Instance.PlaySoundEffect(Walk_2);
    }
    private void walk_3()
    {
        soundManager.Instance.PlaySoundEffect(Walk_3);
    }
    private void crash()
    {
        soundManager.Instance.PlaySoundEffect(Crash);
    }
    private void man_oof()
    {
        soundManager.Instance.PlaySoundEffect(Man_Oof_2);
    }
    private void trash_car()
    {
        soundManager.Instance.PlaySoundEffect(Trash_Car);
    }
    private void thumb_2()
    {
        soundManager.Instance.PlaySoundEffect(Thumb_2);
    }
    private void object_drop()
    {
        soundManager.Instance.PlaySoundEffect(Object_Drop);
    }
    private void groaning()
    {
        soundManager.Instance.PlaySoundEffect(Groaning);
    }
}