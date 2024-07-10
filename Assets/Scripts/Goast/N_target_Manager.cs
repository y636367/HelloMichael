using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_target_Manager : MonoBehaviour
{
    [SerializeField]
    private Transform[] targets = null;

    Crawler crawler;
    public void Update_Target()
    {
        int k = Random.Range(0, targets.Length);

        crawler = FindObjectOfType<Crawler>();
        crawler.Set_destination(targets[k]);
    }
}
