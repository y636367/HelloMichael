using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bella : MonoBehaviour
{
    static public Bella instance;

    [SerializeField]
    private GameObject[] Dummy = null;

    [SerializeField]
    private GameObject Doll = null;

    public Animator animator;

    Door_Only_Lock DOL;
    S_Zones S_Zones;
    Michel michel;

    bool sleep = false;
    [Header("Sounds")]
    [SerializeField]
    private AudioSource Laughing;
    [SerializeField]
    private AudioClip laughing;
    void Awake()
    {
        if (instance == null)
            instance = this;

        animator = GetComponent<Animator>();
        Doll.SetActive(false);

        DOL=FindObjectOfType<Door_Only_Lock>();
        S_Zones= FindObjectOfType<S_Zones>();
        michel= FindObjectOfType<Michel>();

        Laughing=GetComponent<AudioSource>();
        Laughing.clip = laughing;

    }
    private void LateUpdate()
    {
        if (!sleep)
            if (GameManager.Instance.Option_)
            {
                animator.GetComponent<Animator>().speed = 0.0f;
                Laughing.enabled = false;
            }
            else
            {
                animator.GetComponent<Animator>().speed = 1.0f;
                Laughing.enabled = true;
            }
        else
            Laughing.enabled = false;
    }
    public void Start_talk()
    {
        sleep = true;
        animator.SetBool("Talking", true);
    }
    public void Start_sleep()
    {
        sleep = true;
        animator.SetBool("Sleep", true);
        for(int i=0;i<Dummy.Length;i++)
        {
            Destroy(Dummy[i]);
        }
        Doll.SetActive(true);
        S_Zones.Story_2();
        DOL.Lock_only();
    }
    public void fast_sleep()
    {
        sleep = true;
        animator.SetTrigger("Fast_Sleep");
        for (int i = 0; i < Dummy.Length; i++)
        {
            Destroy(Dummy[i]);
        }
        michel.Destroy_Fakedoll();
    }
}
