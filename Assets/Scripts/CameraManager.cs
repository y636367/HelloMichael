using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Camera[] Cameras = null;

    [SerializeField]
    private GameObject Player = null;

    [Header("PlayerPosition")]
    [SerializeField]
    private Transform[] Positions = null;

    public int camera_Num = 0;

    anima anima;
    Camera_Scripts CS;
    Player player;
    HitRayCast hit;
    public void B_CameraChange()
    {
        Bella.instance.Start_talk();

        CS = FindObjectOfType<Camera_Scripts>();
        CS.Re_dir(Positions[camera_Num].localEulerAngles.x, Positions[camera_Num].localEulerAngles.y);

        Player.transform.position = Positions[camera_Num].position;

        Player.SetActive(false);
        Cameras[camera_Num].gameObject.SetActive(true);
        camera_Num+=1;
        ChatController.instance.Script_On = true;
        StartCoroutine(sceneManager.Instance.Camera_Fade_In());
    }
    public void B_return_Play()
    {
        Bella.instance.Start_sleep();

        Cameras[camera_Num-1].gameObject.SetActive(false);
        Player.SetActive(true);

        player = FindObjectOfType<Player>();
        player.Move_Ok = true;

        GameManager.Instance.camera_NUM = camera_Num;
        StartCoroutine(sceneManager.Instance.Story_Fade_In());
    }
    public void CameraChange()
    {
        anima = FindObjectOfType<anima>();
        hit = FindObjectOfType<HitRayCast>();

        hit.Focus_On.SetActive(false);

        camera_Num=GameManager.Instance.camera_NUM;

        CS = FindObjectOfType<Camera_Scripts>();
        CS.Re_dir(Positions[camera_Num].localEulerAngles.x, Positions[camera_Num].localEulerAngles.y);

        Player.transform.position = Positions[camera_Num].position;

        Player.SetActive(false);
        Cameras[camera_Num].gameObject.SetActive(true);
        camera_Num += 1;

        if (camera_Num == 2)
        {
            anima.camera_a();
        }
    }
    public void return_Play()
    {
        if (Player.activeSelf == false)
        {
            Player.SetActive(true);

            player = FindObjectOfType<Player>();
            player.Move_Ok = true;
            player.Stading();
        }

        Cameras[camera_Num - 1].gameObject.SetActive(false);

        GameManager.Instance.camera_NUM = camera_Num;
    }
    public void return_Play_2()
    {
        Player.SetActive(true);

        player = FindObjectOfType<Player>();
        player.Move_Ok = true;
    }
}
