using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler_Sounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip Sounds;

    float soundON_Time;

    float TimeCount = 0.0f;

    Player player;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip= Sounds;

        soundON_Time = Random.Range(0, 7f);
        player = FindObjectOfType<Player>();
    }

    private void LateUpdate()
    {
        if (!GameManager.Instance.Option_ && !player.death)
        {
            TimeCount += Time.deltaTime;

            if (TimeCount >= soundON_Time)
            {
                TimeCount = 0.0f;
                _audioSource.PlayOneShot(Sounds);
                soundON_Time = Random.Range(0, 7f);
            }
        }
    }
}
