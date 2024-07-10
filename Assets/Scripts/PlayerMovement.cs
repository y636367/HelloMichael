using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; //이동속도
    private Vector3 moveForce; //이동 힘

    [SerializeField]
    private float gravity; //중력 계수

    private CharacterController characterController;

    public Quaternion R;
    private Player player;

    public bool walkCheck = false;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        player=FindObjectOfType<Player>();
    }

    void Update()
    {
        if (!characterController.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }

        if (player.Move_Ok)
        {
            characterController.Move(moveForce * Time.deltaTime);
        }
        //초당 moveForce 만큼 움직임
        else
        {
            characterController.Move(moveForce * 0);
        }
    }

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        //음수는 적용 안되게
        get => moveSpeed;
    }

    public void MoveTo(Vector3 t_direction)
    {
        if (t_direction == Vector3.zero)
        {
            walkCheck = false;
        }
        else
            walkCheck = true;

        t_direction = R * new Vector3(t_direction.x, 0, t_direction.z);
        // 이동 방향 - 캐릭터의 회전 값 * 방향 값

        moveForce = new Vector3(t_direction.x * moveSpeed, moveForce.y, t_direction.z * moveSpeed);
    }
    public void Crouchto(float t_height)
    {
        characterController.height=Mathf.Lerp(characterController.height, t_height, Time.deltaTime * 8f);
    }
    public void Crouchto_back(float t_height)
    {
        characterController.height = Mathf.Lerp(characterController.height, t_height, Time.deltaTime * 8f);
    }
    public void Rotate(Quaternion t_R)
    {
        R = t_R;
    }
}
