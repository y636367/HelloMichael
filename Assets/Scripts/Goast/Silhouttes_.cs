using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silhouttes_ : MonoBehaviour
{
    [SerializeField]
    private int num;

    [SerializeField]
    private Sihouette_cam SCam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SCam.Start_anime(this.num);
            Goast_Surprise GS = FindObjectOfType<Goast_Surprise>();
            GS.Silhouette_S();
        }
    }
}
