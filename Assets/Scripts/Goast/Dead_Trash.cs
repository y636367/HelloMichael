using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Trash : MonoBehaviour
{
    [SerializeField]
    private GameObject Cam_Position = null;
    [SerializeField]
    private GameObject Player_Head = null;
    [SerializeField]
    private GameObject Player = null;
    [SerializeField]
    private Camera next_Cam = null;
    [SerializeField]
    private Transform Ground_Position = null;

    [SerializeField]
    private GameObject[] Focus_ = null;

    [SerializeField]
    private float Speed;

    public bool Check = false;

    [SerializeField]
    private Dead_animation DA;

    private void Awake()
    {
        {
            Check = false;
        }
    }
    public void Dead_Start()
    {
        Dead_Standing();
        StartCoroutine(Moving_Cam());
        StartCoroutine(Rotation_Cam());
        Invoke("On_",0.1f);
    }
    private void Update()
    {
        if (Check)
        {
            DA.Start_Motion();
        }
    }
    private void Dead_Standing()
    {
        Cam_Position.transform.position = Player_Head.transform.position;
        Cam_Position.transform.rotation = Player_Head.transform.localRotation;

        Cam_Position.SetActive(true);

        for (int i = 0; i < Focus_.Length; i++)
        {
            Focus_[i].gameObject.SetActive(false);
        }

        Player.SetActive(false);
    }
    IEnumerator Moving_Cam()
    {
        float y_position = Cam_Position.transform.position.y;
        float z_position = Cam_Position.transform.position.z;

        while (Vector3.Magnitude(Cam_Position.transform.position - Ground_Position.position)>=4.7f)
        {
            y_position = Mathf.Lerp(Cam_Position.transform.position.y, Ground_Position.position.y, Time.deltaTime*Speed);
            z_position = Mathf.Lerp(Cam_Position.transform.position.z, Ground_Position.position.z, Time.deltaTime*Speed);

            Cam_Position.transform.position = new Vector3(Cam_Position.transform.position.x, y_position, z_position);
            yield return null;
        }
        Cam_Position.transform.position = new Vector3(Cam_Position.transform.position.x, y_position, z_position);
    }
    IEnumerator Rotation_Cam()
    {
        while (Cam_Position.transform.rotation!=Ground_Position.localRotation)
        {
            Cam_Position.transform.rotation = Quaternion.Slerp(Cam_Position.transform.rotation, Ground_Position.localRotation, Time.deltaTime*Speed);
            yield return null;
        }
        Cam_Position.transform.rotation = Ground_Position.localRotation;
    }
    private void On_()
    {
        Check = true;
    }
}
