using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Crawler_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Respon_postion;

    private GameObject Now_On = null;
    private GameObject priveous = null;

    [SerializeField]
    private GameObject crawler = null;

    [SerializeField]
    private float Time_Range;

    private float hold_timer = 0f;
    private bool hold = false;
    public bool Check = false;

    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if (!GameManager.Instance.Option_ || !player.death)
        {
            if (hold)
            {
                hold_timer += Time.deltaTime;

                if (hold_timer >= Time_Range)
                {
                    hold = false;
                    hold_timer = 0f;
                    crawler_On();
                }
            }
        }
    }
    public void Setting_postion()
    {
        while (!Check)
        {
            for (int i = 0; i < Respon_postion.Length; i++)
            {
                int k = Random.Range(0, 4);
                if (Respon_postion[i] != priveous && k == 1 && hold != true)
                {
                    crawler.transform.position = Respon_postion[i].transform.position;
                    Now_On = Respon_postion[i];
                    priveous = Now_On;
                    Check = true;
                    hold = true;
                }
            }
        }
    }

    public void crawler_On()
    {
        crawler.SetActive(true);
        crawler.GetComponent<Crawler>().Set_Player();
        crawler.GetComponent<Crawler>().Set_state();
        crawler.GetComponent<Crawler>().Not_touch = false;
    }
}
