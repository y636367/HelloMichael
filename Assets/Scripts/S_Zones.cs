using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Zones : MonoBehaviour
{
    [SerializeField]
    private GameObject s_1 = null;
    [SerializeField]
    private GameObject s_2 = null;
    [SerializeField]
    private GameObject s_3 = null;
    [SerializeField]
    private GameObject s_4 = null;
    [SerializeField]
    private GameObject s_5 = null;
    [SerializeField]
    private GameObject s_6 = null;
    [SerializeField]
    private GameObject s_7 = null;
    [SerializeField]
    private GameObject s_8 = null;
    [SerializeField]
    private GameObject s_9 = null;
    [SerializeField]
    private GameObject s_10 = null;

    [SerializeField]
    private GameObject Bella = null;
    [SerializeField]
    private GameObject s_8_Zone = null;
    [SerializeField]
    private GameObject[] UnEnables = null;
    [SerializeField]
    private Batterys BatteryManager = null;

    Bella bella;
    Door_Only_Lock DOL;
    Toy_Box toy;
    Second_F_Box SBox;
    Bowl_1F bowl;
    Re_Match_Data RMD;
    Dynamic_Objects DO;
    void Start()
    {
        if (s_6 && s_7 && s_8 && s_9 && s_10 != null)
        {
            s_6.SetActive(false);
            s_7.SetActive(false);
            s_8.SetActive(false);
            s_9.SetActive(false);
            s_10.SetActive(false);
        }
        if (sceneManager.Instance.j != 4)
        {
            if (s_1 && s_2 && s_3 != null)
            {
                s_1.SetActive(true);
                s_2.SetActive(false);
                s_3.SetActive(false);
            }
            if (s_4 != null)
            {
                s_4.SetActive(false);
            }
            if (s_5 != null)
            {
                s_5.SetActive(false);
            }
        }
        else if(sceneManager.Instance.j == 4)
        {
            if (!sceneManager.Instance.Continue_Check)
            {
                if (s_1 && s_2 && s_3 != null)
                {
                    s_1.SetActive(false);
                    s_2.SetActive(false);
                    s_3.SetActive(false);
                }
                if (s_4 != null)
                {
                    s_4.SetActive(false);
                }
                if (s_5 != null)
                {
                    bella = FindObjectOfType<Bella>();
                    DOL = FindObjectOfType<Door_Only_Lock>();
                    toy = FindObjectOfType<Toy_Box>();

                    bella.fast_sleep();

                    toy.Clean_Toy();

                    DOL.Lock_only();

                    s_5.SetActive(true);
                }
            }
            else
            {
                if (!GameManager.Instance.Back_Point)
                {

                    s_1.SetActive(false);
                    s_2.SetActive(false);
                    s_3.SetActive(false);
                    s_5.SetActive(false);
                    s_6.SetActive(false);
                    s_7.SetActive(false);

                    Continue();
                }
                else
                {
                    s_1.SetActive(false);
                    s_2.SetActive(false);
                    s_3.SetActive(false);
                    s_5.SetActive(false);
                    s_6.SetActive(false);
                    s_7.SetActive(false);

                    Back();
                }
            }
        }
    }

    public void Story_2()
    {
        s_1.SetActive(false);
        s_2.SetActive(true);
        s_3.SetActive(false);
    }
    public void Story_3()
    {
        s_1.SetActive(false);
        s_2.SetActive(false);
        s_3.SetActive(true);
    }
    public void Story_4()
    {
        s_4.SetActive(true);
    }
    public void Story_6()
    {
        s_6.SetActive(true);
    }
    public void Story_7()
    {
        s_7.SetActive(true);
    }
    public void Story_8()
    {
        s_8.SetActive(true);
    }
    public void Story_9()
    {
        s_9.SetActive(true);
    }
    public void Story_10()
    {
        s_10.SetActive(true);
    }
    public void Continue()
    {
        SBox = FindObjectOfType<Second_F_Box>();
        bowl = FindObjectOfType<Bowl_1F>();
        DOL = FindObjectOfType<Door_Only_Lock>();
        toy = FindObjectOfType<Toy_Box>();
        RMD = FindObjectOfType<Re_Match_Data>();
        DO = FindObjectOfType<Dynamic_Objects>();

        Destroy(Bella);
        SBox.Boxes();
        bowl.Bowl();
        toy.Clean_Toy();
        DOL.Lock_only();
        DO.All_Lights_Off();

        for(int  i = 0; i < UnEnables.Length; i++)
        {
            Destroy(UnEnables[i]);
        }
        BatteryManager.GetComponent<Batterys>();
        BatteryManager.Count += 2;

        s_8_Zone.GetComponent<S_Zone>().enabled = false;
        Story_8();
    }
    public void Back()
    {
        SBox = FindObjectOfType<Second_F_Box>();
        bowl = FindObjectOfType<Bowl_1F>();
        DOL = FindObjectOfType<Door_Only_Lock>();
        toy = FindObjectOfType<Toy_Box>();
        DO = FindObjectOfType<Dynamic_Objects>();

        Re_Back_Point RBO = FindObjectOfType<Re_Back_Point>();

        SBox.Boxes();
        bowl.Bowl();
        toy.Clean_Toy();
        DOL.Lock_only();
        DO.All_Lights_Off();

        RBO.Re_();
    }
    public void Scene_Main()
    {
        sceneManager.Instance.Re_Main();
    }
}
