using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [Header("Script")]
    [SerializeField]
    private string[] Script;

    public int control = 0;

    ChatController CC;
    HitRayCast hit;
    Dummy_Eyes DE;
    void Awake()
    {
        CC = FindObjectOfType<ChatController>();
        hit=FindObjectOfType<HitRayCast>();
        DE= FindObjectOfType<Dummy_Eyes>();
    }
    public void Choice_Story()
    {
        Story_();
    }
    void Story_()
    {
        CC.GetScribt(this.Script);
        CC.turnOn_Story();
        hit.Story = 1;
        DE.start_a();
    }
}
