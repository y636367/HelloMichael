using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy_Box : MonoBehaviour
{
    static public Toy_Box instance;

    [SerializeField]
    private GameObject[] Toys = null;

    [SerializeField]
    private GameObject Clean_Toys = null;

    [SerializeField]
    private GameObject M_Doll = null;
    [SerializeField]
    private GameObject Fake_Doll = null;

    int num = 0;
    int count = 0;
    void Awake()
    {
        if (instance== null)
            instance = this;

        for(int i=0;i<Toys.Length;i++)
        {
            Toys[i].SetActive(false);
        }
        M_Doll.SetActive(false);
    }

    public void Stack_Toy(int t_num)
    {
        if (count == 0)
        {
            num = t_num;
            count++;
        }
        Toys[num-t_num].SetActive(true);
        if ((num-t_num) == 5)
        {
            M_Doll.SetActive(true);
            Destroy(Fake_Doll);
        }
    }
    public void Clean_Toy()
    {
        for (int i = 0; i < Toys.Length; i++)
        {
            Toys[i].SetActive(true);
        }
        Destroy(Clean_Toys);
    }
}
