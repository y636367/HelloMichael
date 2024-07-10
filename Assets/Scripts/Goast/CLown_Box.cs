using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLown_Box : MonoBehaviour
{
    Clown_clown clown;

    Animator animator;

    [SerializeField]
    private GameObject Parent;

    int k;

    private float Timer = 0;
    public bool Check = false;

    Player player;
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();

        k = Random.Range(5, 8);
    }
    void Update()
    {
        if(this.Check)
        {
            Timer += Time.deltaTime;
            if (Timer >= k)
            {
                this.Check = false;
                animator.SetTrigger("On");
                Timer = 0f;
            }
        }
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.Option_ || player.death)
            animator.GetComponent<Animator>().speed = 0.0f;
        else
            animator.GetComponent<Animator>().speed = 1.0f;
    }
    public void Start_Cam()
    {
        Player t_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(t_player.Life(3000))
            clown.Whoa();
    }
    void OnTriggerEnter(Collider other)
    {
        Set_Cam();
        if (other.CompareTag("Player"))
        {
            Start_Cam();
            deActive();
        }
    }
    public void Set_Cam()
    {
        GameObject t_player = GameObject.FindGameObjectWithTag("Player");
        GameObject Head = t_player.transform.Find("Head").gameObject;
        GameObject Main = Head.transform.Find("Main Camera").gameObject;

        clown = Main.transform.Find("Clown").gameObject.GetComponent<Clown_clown>();
    }

    private void Hold()
    {
        animator.SetTrigger("Hold");
        k = Random.Range(5, 8);
        this.Check = true;
    }
    private void deActive()
    {
        CLown_Manager CM=FindObjectOfType<CLown_Manager>();
        CM.Re_Setting();
        this.Parent.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
