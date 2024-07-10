using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
    public string name;//재생할 곡 이름
    public AudioClip clip; //곡
}
public class soundManager : MonoBehaviour
{
    static public soundManager Instance;
    //싱글톤 적용
    #region Singleton
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance!=this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        BGMSlider = BGMSlider.GetComponent<Slider>();
        SFXSlider = SFXSlider.GetComponent<Slider>();
        MasterSlider = MasterSlider.GetComponent<Slider>();
    }
    #endregion Singleton

    public AudioSource[] audioSourcesEffect;
    public AudioSource[] audioSourceBgm;

    public string[] playSoundName;

    public Sound[] EffectSound;
    public Sound[] BgmSound;

    public AudioMixer audioMixer;
    //오디오 믹서
    public Slider MasterSlider;
    public Slider BGMSlider;
    public Slider SFXSlider;

    private int Sceneindex = 0;

    float bgm_value = 0.55f;
    float sfx_value = 0.55f;
    float master_value = 0.55f;

    void Start()
    {
        playSoundName = new string[audioSourcesEffect.Length];

        SetFunction_UI();
    }
    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex != Sceneindex)
        {
            FInd_slider();
            Sceneindex = SceneManager.GetActiveScene().buildIndex;
        }

        SetBgm();
        SetSfx();
        SetMaster();
    }
    #region SoundEffect
    public void PlaySoundEffect(string name)
    {
        for (int i = 0; i < EffectSound.Length; i++)
        {
            if (name == EffectSound[i].name)
            {
                for (int j = 0; j < audioSourcesEffect.Length; j++)
                {
                    if (!audioSourcesEffect[j].isPlaying)
                    {
                        playSoundName[j] = EffectSound[i].name;
                        audioSourcesEffect[j].clip = EffectSound[i].clip;
                        audioSourcesEffect[j].Play();
                        return;
                    }
                }
                return;
            }
        }
    }

    public void StopAllSoundEffect()
    {
        for (int i = 0; i < audioSourcesEffect.Length; i++)
        {
            audioSourcesEffect[i].Stop();
        }
    }
    public void StopSoundEffect(string name)
    {
        for (int i = 0; i < audioSourcesEffect.Length; i++)
        {
            if (playSoundName[i] == name)
            {
                audioSourcesEffect[i].Stop();
                return;
            }
        }
    }
    #endregion SoundEffect
    #region Bgm
    public void PlaySoundBGM(string name)
    {
        for (int i = 0; i < BgmSound.Length; i++)
        {
            if (name == BgmSound[i].name)
            {
                for (int j = 0; j < audioSourceBgm.Length; j++)
                {
                    if (!audioSourceBgm[j].isPlaying)
                    {
                        playSoundName[j] = BgmSound[i].name;
                        audioSourceBgm[j].clip = BgmSound[i].clip;
                        audioSourceBgm[j].Play();
                        return;
                    }
                }
                return;
            }
        }
    }
    public void StopAllSoundBGM()
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            audioSourceBgm[i].Stop();
        }
    }
    public void StopSoundBGM(string name)
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            if (playSoundName[i] == name)
            {
                audioSourceBgm[i].Stop();
                return;
            }
        }
    }
    #endregion Bgm
    public void SetBgm()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(BGMSlider.value) * 20);
        //로그 연산 값 전달
    }
    public void SetSfx()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXSlider.value) * 20);
    }
    public void SetMaster()
    {
        audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
    }
    public void FInd_slider()
    {
        try
        {
            GameObject Main_Menu = GameObject.FindGameObjectWithTag("Main_Menu").gameObject;
            GameObject canvas_Option = Main_Menu.transform.Find("Canv_Options").gameObject;
            GameObject Panel = canvas_Option.transform.Find("PANELS").gameObject;
            GameObject Game_Panel = Panel.transform.Find("PanelGame").gameObject;

            BGMSlider = Game_Panel.transform.Find("MusicSlider_BGM").gameObject.GetComponent<Slider>();
            SFXSlider = Game_Panel.transform.Find("MusicSlider_SFX").gameObject.GetComponent<Slider>();
            MasterSlider = Game_Panel.transform.Find("MusicSlider").gameObject.GetComponent<Slider>();
        }
        catch (NullReferenceException)
        {
            GameObject Canvas_=GameObject.FindGameObjectWithTag("Canvas_").gameObject;
            GameObject canvas_Option = Canvas_.transform.Find("Canv_Options").gameObject;
            GameObject Panel = canvas_Option.transform.Find("PANELS").gameObject;
            GameObject Game_Panel = Panel.transform.Find("PanelGame_Controls").gameObject;

            BGMSlider = Game_Panel.transform.Find("MusicSlider_BGM").gameObject.GetComponent<Slider>();
            SFXSlider = Game_Panel.transform.Find("MusicSlider_SFX").gameObject.GetComponent<Slider>();
            MasterSlider = Game_Panel.transform.Find("MusicSlider").gameObject.GetComponent<Slider>();
        }
        SetFunction_UI_InGame();
        SetValue_UI();
    }
    #region First_Set_Sound_Slder
    private void SetFunction_UI()
    {
        ResetFunction_UI();

        BGMSlider.onValueChanged.AddListener(Function_Slider_BGM);
        SFXSlider.onValueChanged.AddListener(Function_Slider_SFX);
        MasterSlider.onValueChanged.AddListener(Function_Slider_Master);
    }
    private void SetFunction_UI_InGame()
    {
        BGMSlider.onValueChanged.AddListener(Function_Slider_BGM);
        SFXSlider.onValueChanged.AddListener(Function_Slider_SFX);
        MasterSlider.onValueChanged.AddListener(Function_Slider_Master);
    }
    private void Function_Slider_BGM(float _value)
    {
        bgm_value = _value;
    }
    private void Function_Slider_SFX(float _value)
    {
        sfx_value = _value;
    }
    private void Function_Slider_Master(float _value)
    {
        master_value = _value;
    }
    private void ResetFunction_UI()
    {
        BGMSlider.maxValue = 1.0f;
        SFXSlider.maxValue = 1.0f;
        MasterSlider.maxValue = 1.0f;

        BGMSlider.minValue = 0.0001f;
        SFXSlider.minValue = 0.0001f;
        MasterSlider.minValue = 0.0001f;

        BGMSlider.value = 0.55f;
        SFXSlider.value = 0.55f;
        MasterSlider.value = 0.55f;

        BGMSlider.wholeNumbers = false;
        SFXSlider.wholeNumbers = false;
        MasterSlider.wholeNumbers = false;

        audioMixer.SetFloat("BGM", Mathf.Log10(BGMSlider.value) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXSlider.value) * 20);
        audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
    }
    #endregion
    private void SetValue_UI()
    {
        BGMSlider.maxValue = 1.0f;
        SFXSlider.maxValue = 1.0f;
        MasterSlider.maxValue = 1.0f;

        BGMSlider.minValue = 0.0001f;
        SFXSlider.minValue = 0.0001f;
        MasterSlider.minValue = 0.0001f;
        //값 재설정 필요함

        BGMSlider.value = bgm_value;
        SFXSlider.value = sfx_value;
        MasterSlider.value = master_value;

        BGMSlider.wholeNumbers = false;
        SFXSlider.wholeNumbers = false;
        MasterSlider.wholeNumbers = false;

        audioMixer.SetFloat("BGM", Mathf.Log10(BGMSlider.value) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXSlider.value) * 20);
        audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
    }
    public bool now_SFX_Check(string name)
    {
        for (int i = 0; i < audioSourcesEffect.Length; i++)
        {
            if (playSoundName[i] == name)
            {
                if (audioSourcesEffect[i].isPlaying)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }
    public void Sounds_BGM_Fade_Out()
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            StartCoroutine(SBF(audioSourceBgm[i]));
        }
    }
    public IEnumerator SBF(AudioSource AS)
    {
        while (AS.volume >0f)
        {
            AS.volume-=Time.deltaTime*0.9f;
            yield return null;
        }
    }
    public void return_BGM_Volume()
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            audioSourceBgm[i].volume = BGMSlider.value;
        }
    }
    public void return_SFX_Volume()
    {
        for (int i = 0; i < audioSourcesEffect.Length; i++)
        {
            audioSourcesEffect[i].volume = SFXSlider.value;
        }
    }
    public void Pasue()
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            audioSourceBgm[i].Pause();
        }
        for (int i = 0; i < audioSourcesEffect.Length; i++)
        {
            audioSourcesEffect[i].Pause();
        }
    }
    public void Play_Re()
    {
        for (int i = 0; i < audioSourceBgm.Length; i++)
        {
            audioSourceBgm[i].UnPause();
        }
        for (int i = 0; i < audioSourcesEffect.Length; i++)
        {
            audioSourcesEffect[i].UnPause();
        }
    }
}
