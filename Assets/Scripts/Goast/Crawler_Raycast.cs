using UnityEngine;

public class Crawler_Raycast : MonoBehaviour
{
    private Ray ray;

    private RaycastHit hit;

    [SerializeField]
    float Range = 0f;

    [SerializeField]
    private Transform end_point = null;

    Vector3 rayDir;

    bool Count = false;

    private Door door;
    private void Awake()
    {
        door=FindObjectOfType<Door>();
    }
    private void Update()
    {
        rayDir=end_point.position-this.transform.position;

        if(Physics.Raycast(this.transform.position, rayDir, out hit,Range))
        {
            if (hit.transform.CompareTag("Door") && Count != true)
            {
                door.this_door_Goast(hit);
                door.DoorAnime_Goast();
                Count = true;
            }
            else
                Count = false;
        }
    }
}
