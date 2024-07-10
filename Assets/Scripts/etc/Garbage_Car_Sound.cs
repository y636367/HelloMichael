using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage_Car_Sound : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField]
    private AudioSource Crash;
    [SerializeField]
    private AudioSource Trash_Car;

    private void Awake()
    {
        Crash = GetComponent<AudioSource>();
        Trash_Car = GetComponent<AudioSource>();
    }
    private void crash()
    {
        Crash.Play();
    }
    private void trash_car()
    {
        Trash_Car.Play();
    }
}
