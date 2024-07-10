using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer_Animation_Sounds : MonoBehaviour
{
    [Header("Sounds_InHouse")]
    [SerializeField]
    private string[] thumbs_;
    [SerializeField]
    private string[] oofs_;
    [SerializeField]
    private string micheal_laughing;
    [SerializeField]
    private string Man_Scriming;
    [SerializeField]
    private string Question;

    [Header("Sounds_Dead")]
    [SerializeField]
    private string[] walks;
    [SerializeField]
    private string[] Rolling;
    [SerializeField]
    private string Car_crash;
    [SerializeField]
    private string Groing;

    private void thumb_s_1()
    {
        soundManager.Instance.PlaySoundEffect(thumbs_[0]);
    }
    private void thumb_s_2()
    {
        soundManager.Instance.PlaySoundEffect(thumbs_[1]);
    }
    private void thumb_s_3()
    {
        soundManager.Instance.PlaySoundEffect(thumbs_[2]);
    }
    private void thumb_s_4()
    {
        soundManager.Instance.PlaySoundEffect(thumbs_[3]);
    }
    private void thumb_s_Last()
    {
        soundManager.Instance.PlaySoundEffect(thumbs_[4]);
    }
    private void oof_s_1()
    {
        soundManager.Instance.PlaySoundEffect(oofs_[0]);
    }
    private void oof_s_2()
    {
        soundManager.Instance.PlaySoundEffect(oofs_[1]);
    }
    private void oof_s_3()
    {
        soundManager.Instance.PlaySoundEffect(oofs_[2]);
    }
    private void oof_s_4()
    {
        soundManager.Instance.PlaySoundEffect(oofs_[3]);
    }
    private void oof_s_5()
    {
        soundManager.Instance.PlaySoundEffect(oofs_[4]);
    }
    private void oof_s_6()
    {
        soundManager.Instance.PlaySoundEffect(oofs_[5]);
    }
    private void micheal_Laughing()
    {
        soundManager.Instance.PlaySoundEffect(micheal_laughing);
    }
    private void man_scriming()
    {
        soundManager.Instance.PlaySoundEffect(Man_Scriming);
    }
    private void question()
    {
        soundManager.Instance.PlaySoundEffect(Question);
    }
    private void walk_1()
    {
        soundManager.Instance.PlaySoundEffect(walks[0]);
    }
    private void walk_2()
    {
        soundManager.Instance.PlaySoundEffect(walks[1]);
    }
    private void walk_3()
    {
        soundManager.Instance.PlaySoundEffect(walks[2]);
    }
    private void walk_4()
    {
        soundManager.Instance.PlaySoundEffect(walks[3]);
    }
    private void walk_5()
    {
        soundManager.Instance.PlaySoundEffect(walks[4]);
    }
    private void walk_6()
    {
        soundManager.Instance.PlaySoundEffect(walks[5]);
    }
    private void rolling_1()
    {
        soundManager.Instance.PlaySoundEffect(Rolling[0]);
    }
    private void rolling_2()
    {
        soundManager.Instance.PlaySoundEffect(Rolling[1]);
    }
    private void rolling_3()
    {
        soundManager.Instance.PlaySoundEffect(Rolling[2]);
    }
    private void rolling_4()
    {
        soundManager.Instance.PlaySoundEffect(Rolling[3]);
    }
    private void rolling_5()
    {
        soundManager.Instance.PlaySoundEffect(Rolling[4]);
    }
    private void rolling_6()
    {
        soundManager.Instance.PlaySoundEffect(Rolling[5]);
    }
    private void car_crash()
    {
        soundManager.Instance.PlaySoundEffect(Car_crash);
    }
    private void groing()
    {
        soundManager.Instance.PlaySoundEffect(Groing);
    }
}
