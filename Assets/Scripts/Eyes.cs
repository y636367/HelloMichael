using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField]
    private GameObject Player = null;

    private void Update()
    {
        UpdateTarget();
    }
    void UpdateTarget()
    {
        Vector3 to = Player.transform.position;
        Vector3 monster = transform.position;
        to.y = 0.0f;
        monster.y = 0.0f;

        Vector3 to_player = to - monster;
        //Vector3.Forward X Why?
        transform.rotation = Quaternion.FromToRotation(Vector3.left, to_player);
    }
}
