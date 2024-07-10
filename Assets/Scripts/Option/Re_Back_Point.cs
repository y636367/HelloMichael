using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Re_Back_Point : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Return_Objects;

    [SerializeField]
    private GameObject[] Back_Objects;

    [SerializeField]
    private S_Zone[] S_Zone;

    [SerializeField]
    private Transform PositionData;
    [SerializeField]
    private Quaternion RotationData;

    [SerializeField]
    private GameObject Player;


    Camera_Scripts CS;
    public void Re_()
    {
        Re_Box();
        Re_Postion();
        Re_Status();
        Re_Off();
        Re_Zone_Count();
    }
    private void Re_Box()
    {
        for(int i = 0; i < Return_Objects.Length; i++)
        {
            Return_Objects[i].gameObject.SetActive(true);
        }
    }
    private void Re_Postion()
    {
        Player.SetActive(false);
        Player.transform.position = PositionData.position;

        Player.SetActive(true);

        RotationData = new Quaternion(this.gameObject.transform.eulerAngles.x, this.gameObject.transform.eulerAngles.y, this.gameObject.transform.eulerAngles.z, 0);

        CS = FindObjectOfType<Camera_Scripts>();
        CS.Re_dir(RotationData.eulerAngles.x, RotationData.eulerAngles.y);
    }
    private void Re_Status()
    {
        Player.GetComponent<Player>().FlashGet = false;
    }
    private void Re_Off()
    {
        for (int i = 0; i < Back_Objects.Length; i++)
        {
            Back_Objects[i].gameObject.SetActive(false);
        }
    }
    private void Re_Zone_Count()
    {
        for (int i = 0; i < S_Zone.Length; i++)
        {
            S_Zone[i].Count_Back();
        }
    }
}
