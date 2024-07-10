using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goast_Surprise : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField]
    private string[] Box_Surprise;
    [SerializeField]
    private string[] Micheal_Surprise;
    [SerializeField]
    private string Crawler_Surprise;
    [SerializeField]
    private string Silhouette_Surprise;
    [SerializeField]
    private string Death_Surprise;

    public void Box_S()
    {
        int i=Random.Range(0, Box_Surprise.Length);

        soundManager.Instance.PlaySoundEffect(Box_Surprise[i]);
    }
    public void Micheal_S()
    {
        int i = Random.Range(0, Micheal_Surprise.Length);

        soundManager.Instance.PlaySoundEffect(Micheal_Surprise[i]);
    }
    public void Crawler_S()
    {
        soundManager.Instance.PlaySoundEffect(Crawler_Surprise);
    }
    public void Silhouette_S()
    {
        soundManager.Instance.PlaySoundEffect(Silhouette_Surprise);
    }
    public void Death_S()
    {
        soundManager.Instance.PlaySoundEffect(Death_Surprise);
    }
}
