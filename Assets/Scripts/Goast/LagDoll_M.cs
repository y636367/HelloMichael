using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagDoll_M : MonoBehaviour
{
    [SerializeField]
    private float current_HP = 10.0f;

    [SerializeField]
    private LagDoll_Frag lag_frag;

    [SerializeField]
    private GameObject Lag_Doll;
    public void On_Damage()
    {
        float Damage = Random.Range(1.0f, 5.0f);

        current_HP -= Damage;

        if (current_HP <= 0.0f)
        {
            Lag_Doll.SetActive(false);
            lag_frag.On_();
        }
    }
}
