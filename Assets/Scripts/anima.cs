using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class anima : MonoBehaviour
{
    [SerializeField]
    private int anim_num;

    Second_F_Box SBox;
    Bowl_1F bowl;
    Door_Only_Lock Dol;
    Camera_2 camera_2;
    CameraManager cameraManager;
    Michel_Manager MM;
    CLown_Manager CM;
    Crawler_Manager crawler_m;
    Player player;
    Crawler crawler;
    void Awake()
    {
        SBox=FindObjectOfType<Second_F_Box>();
        bowl=FindObjectOfType<Bowl_1F>();
        Dol=FindObjectOfType<Door_Only_Lock>();
        cameraManager=FindObjectOfType<CameraManager>();

        player= FindObjectOfType<Player>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.anim_num == 1)
            {
                SBox.Boxes();
                Destroy(this.gameObject);
            }
            else if (this.anim_num == 2)
            {
                bowl.Bowl();
                Destroy(this.gameObject);
            }
            else if (this.anim_num == 3)
            {
                Dol.UnLock();
            }
            else if (this.anim_num == 4)
            {
                cameraManager.CameraChange();
            }
            else if (this.anim_num == 5)
            {
                Start_Survive_1();
            }
        }
    }
    private void Start_Survive_1()
    {
        GameManager.Instance.TimeOn = true;

        MM = FindObjectOfType<Michel_Manager>();
        MM.Start = true;

        CM = FindObjectOfType<CLown_Manager>();
        CM.Start = true;

        crawler_m = FindObjectOfType<Crawler_Manager>();
        crawler_m.crawler_On();

        player = FindAnyObjectByType<Player>();
        crawler = FindAnyObjectByType<Crawler>();
        player.crawler = crawler;

        Destroy_this();
    }
    public void camera_a()
    {
        camera_2 = FindObjectOfType<Camera_2>();

        camera_2.Camera_a();
    }
    public void Destroy_this()
    {
        Destroy(this.gameObject);
    }
}
