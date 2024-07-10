using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Michel_Eyes : MonoBehaviour
{
    float Timing;
    float Count = 0.0f;

    bool Check = false;

    public bool this_time = true;

    Animator anim;

    [SerializeField]
    private string[] rollings;
    private void Awake()
    {
        anim = GetComponent<Animator>();

        Timing = Random.Range(5f, 15f);
        Check = true;
    }
    private void Update()
    {
        if(this_time)
            if (Check)
            {
                if (Timing > Count)
                {
                    Count += Time.deltaTime;
                }
                else
                {
                    Check = false;
                    Count = 0.0f;
                    Timing = Random.Range(5f, 15f);
                    Eyes_Moving();
                }
            }
    }
    private void Eyes_Moving()
    {
        anim.SetTrigger("On");
    }
    public void Chekc_true()
    {
        Check = true;
    }
    #region rollings
    private void rolling_1()
    {
        soundManager.Instance.PlaySoundEffect(rollings[0]);
    }
    private void rolling_2()
    {
        soundManager.Instance.PlaySoundEffect(rollings[1]);
    }
    private void rolling_3()
    {
        soundManager.Instance.PlaySoundEffect(rollings[2]);
    }
    private void rolling_4()
    {
        soundManager.Instance.PlaySoundEffect(rollings[3]);
    }
    private void rolling_5()
    {
        soundManager.Instance.PlaySoundEffect(rollings[4]);
    }
    private void rolling_6()
    {
        soundManager.Instance.PlaySoundEffect(rollings[5]);
    }
    #endregion

}
