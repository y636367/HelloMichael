using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Micheal_Time : MonoBehaviour
{
    [SerializeField]
    private float Time_Count;

    private bool On = false;

    private void LateUpdate()
    {
        if (!GameManager.Instance.Option_)
        {
            if (On)
            {
                if (this.Time_Count > 0f)
                    this.Time_Count -= Time.deltaTime;
                else
                    Out_Time();
            }
        }
    }
    public void Get_TIme(float t_time)
    {
        this.Time_Count = t_time;
        this.On = true;
    }
    private void Out_Time()
    {
        this.On = false;
        this.Time_Count = 0.0f;

        Michel_Manager MM=FindObjectOfType<Michel_Manager>();
        MM.Re_Setting();

        this.gameObject.SetActive(false);
    }
}
