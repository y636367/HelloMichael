using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Crawler : MonoBehaviour
{
    [SerializeField]
    public Vector3 Run_previous_player;

    [SerializeField]
    private Transform target;

    private bool Nomal_target = false;

    public bool Player_sound = false;

    [SerializeField]
    private bool _Find = false;

    private bool anima_over = false;

    private bool Get_Player = false;

    bool Hold_count = false;

    public bool Not_touch = false;

    [SerializeField]
    private float Holding_Error = 0.0f;
    [SerializeField]
    private float Error_Check;

    NavMeshAgent agent;
    Animator animator;

    N_target_Manager target_manager;
    Crawler_A_Collider CAC;
    Crawler_Manager CM;
    Collision_Crawler CC;
    Player player;

    enum State{
        Idle,
        Walk,
        Run,
        Attack,
        Hold
    }
    State state;
    private void Awake()
    {
        animator= GetComponent<Animator>();
        agent=GetComponent<NavMeshAgent>();
        target_manager=FindObjectOfType<N_target_Manager>();
        CAC=FindObjectOfType<Crawler_A_Collider>();
        CM=FindObjectOfType<Crawler_Manager>();
        CC=FindObjectOfType<Collision_Crawler>();
        player = FindObjectOfType<Player>();

        state= State.Idle;
        agent.enabled = false;
        target_manager.Update_Target();
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.Option_||player.death)
        {
            animator.GetComponent<Animator>().speed = 0.0f;
            if(agent.enabled)
            {
                agent.speed = 0f;
            }
        }
        else
        {
            if (_Find)
            {
                if (state == State.Idle)
                {
                    UpdateIdle();
                }
                else if (state == State.Walk)
                {
                    UpdateWalk();
                }
                else if (state == State.Run)
                {
                    UpdateRun();
                }
                else if (state == State.Attack)
                {
                    UpdateAttack();
                }
                else if (state == State.Hold)
                {
                    UpdateHold();
                }
            }

            animator.GetComponent<Animator>().speed = 1.0f;
            if (agent.enabled)
            {
                if (state == State.Walk)
                {
                    agent.speed = 3f;
                }
                else if (state == State.Run)
                {
                    agent.speed = 4.7f;
                }
            }
        }
    }
    private void UpdateIdle()
    {
        agent.speed = 0f;

        Hold_count = false;

        if(anima_over)
        {
            if (!Nomal_target)
            {
                target_manager.Update_Target();
            }
            anima_over = false;
            agent.enabled = true;
            state = State.Walk;
            animator.SetTrigger("Walk");
        }
    }
    private void UpdateWalk()
    {
        agent.speed = 3f;

        float distance = Vector3.Distance(transform.position, target.position);

        agent.destination = target.position;

        if (distance <= 1)
        {
            Nomal_target = false;
            target_manager.Update_Target();
            anima_over = false;
            agent.enabled = false;
            state = State.Idle;
            animator.SetTrigger("Idle");
        }
    }
    private void UpdateRun()
    {
        agent.speed = 4.7f;

        float distance = Vector3.Distance(transform.position, Run_previous_player);

        agent.destination = Run_previous_player;

        if (distance <= 2)
        {
            Get_Player_false();
            agent.enabled = false;
            anima_over = false;
            CAC.Attack_Check = false;
            CC.Player_sound = false;
            state = State.Hold;
            animator.SetTrigger("Hold");
        }

    }
    private void UpdateAttack()
    {
        agent.speed = 0f;

        CAC.Attack_Check = false;
        state = State.Idle;
        animator.SetTrigger("Idle");
        CM.Setting_postion();
        CC.Player_sound = false;
        this.gameObject.SetActive(false);

    }
    private void UpdateHold()
    {
        agent.speed = 0f;

        Nomal_target = false;
        if (anima_over)
        {
            if (Get_Player)
            {
                agent.enabled = true;
                CAC.Attack_Check = true;
                state = State.Run;
                animator.SetTrigger("Run");
            }
            else
            {
                anima_over = false;
                agent.enabled = false;
                target_manager.Update_Target();
                state = State.Idle;
                animator.SetTrigger("Idle");
            }
        }
    }
    public void Set_Player()
    {
        _Find = true;
    }
    public void Set_state()
    {
        state = State.Idle;
        agent.enabled = false;
        target_manager.Update_Target();
    }
    public void Stop_Game()
    {
        _Find = false;
        this.gameObject.SetActive(false);
    }
    public void Set_destination(Transform t_target)
    {
        target = t_target;
        Nomal_target = true;
    }
    public void animation_over()
    {
        anima_over = true;
    }
    public void Change_Hold()
    {
        if (!Hold_count&&!Not_touch)
        {
            Hold_count = true;
            Get_Player = true;
            anima_over = false;
            agent.enabled = false;
            state = State.Hold;
            animator.SetTrigger("Hold");
        }
    }
    public void Change_Attack()
    {
        agent.enabled = false;
        Not_touch = true;
        state = State.Attack;
        animator.SetTrigger("Attack");
    }
    public void Get_Player_false()
    {
        Get_Player = false;
    }
}
