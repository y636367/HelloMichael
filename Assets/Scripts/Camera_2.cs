using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_2 : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private GameObject Doll = null;

    CameraManager manager;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Camera_a()
    {
        Doll.SetActive(true);
        animator.SetBool("On", true);
        GameManager.Instance.Dont_Option = false;
    }
    void Clear_Doll()
    {
        Destroy(Doll);
    }
    private void Camera_b()
    {
        animator.SetBool("Second_On", true);
        GameManager.Instance.Dont_Option = false;
    }
    private void Change_Camera()
    {
        manager=FindObjectOfType<CameraManager>();

        manager.return_Play();
    }
    private void Change_Camera_2()
    {
        manager = FindObjectOfType<CameraManager>();
        GameManager.Instance.Dont_Option = true;
        manager.return_Play_2();
    }
}
