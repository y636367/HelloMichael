using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Player_Ground : MonoBehaviour
{
    private Ray ray;

    [SerializeField]
    private RaycastHit hit;

    [SerializeField]
    private float range;

    [Header("Sounds")]
    [SerializeField]
    private string[] Grounds;
    [SerializeField]
    private string[] Stairs;
    [SerializeField]
    private string[] Grass;
    [SerializeField]
    private string[] Basement_Stairs;
    [SerializeField]
    private string[] Basement;
    [SerializeField]
    private string[] Floor;

    [SerializeField]
    int num = 0;

    float walkTime = 0.0f;
    [SerializeField]
    private Player player;
    [SerializeField]
    private PlayerMovement PM;
    private void LateUpdate()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Crawler"));
        layerMask = ~layerMask;

        ray = new Ray(this.transform.position,this.transform.forward);

        if (Physics.Raycast(ray,out hit, range, layerMask))
        {
            if (PM.walkCheck)
            {
                if (!player.isCrouch)
                {
                    if (hit.transform.CompareTag("Ground"))
                    {
                        walkTime += Time.deltaTime;   

                        if (player.isRun)
                        {
                            if (walkTime >= 0.45f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Grounds[num]);
                                walkTime = 0.0f;
                            }
                        }
                        else
                        {
                            if (walkTime >= 0.7f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Grounds[num]);
                                walkTime = 0.0f;
                            }
                        }
                        if (!player.Move_Ok)
                        {
                            if (soundManager.Instance.now_SFX_Check(Grounds[num]))
                                soundManager.Instance.StopSoundEffect(Grounds[num]);
                        }
                    }
                    else if (hit.transform.CompareTag("Grass"))
                    {
                        walkTime += Time.deltaTime;

                        if (player.isRun)
                        {
                            if (walkTime >= 0.45f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Grass[num]);
                                walkTime = 0.0f;
                            }
                        }
                        else
                        {
                            if (walkTime >= 0.7f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Grass[num]);
                                walkTime = 0.0f;
                            }
                        }
                        if (!player.Move_Ok)
                        {
                            if (soundManager.Instance.now_SFX_Check(Grass[num]))
                                soundManager.Instance.StopSoundEffect(Grass[num]);
                        }
                    }
                    else if (hit.transform.CompareTag("Stairs"))
                    {
                        walkTime += Time.deltaTime;

                        if (player.isRun)
                        {
                            if (walkTime >= 0.45f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Stairs[num]);
                                walkTime = 0.0f;
                            }
                        }
                        else
                        {
                            if (walkTime >= 0.7f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Stairs[num]);
                                walkTime = 0.0f;
                            }
                        }
                        if (!player.Move_Ok)
                        {
                            if (soundManager.Instance.now_SFX_Check(Stairs[num]))
                                soundManager.Instance.StopSoundEffect(Stairs[num]);
                        }
                    }
                    else if (hit.transform.CompareTag("Floor"))
                    {
                        walkTime += Time.deltaTime;

                        if (player.isRun)
                        {
                            if (walkTime >= 0.45f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Floor[num]);
                                walkTime = 0.0f;
                            }
                        }
                        else
                        {
                            if (walkTime >= 0.7f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Floor[num]);
                                walkTime = 0.0f;
                            }
                        }
                        if (!player.Move_Ok)
                        {
                            if (soundManager.Instance.now_SFX_Check(Floor[num]))
                                soundManager.Instance.StopSoundEffect(Floor[num]);
                        }
                    }
                    else if (hit.transform.CompareTag("Basement"))
                    {
                        walkTime += Time.deltaTime;

                        if (player.isRun)
                        {
                            if (walkTime >= 0.45f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Basement[num]);
                                walkTime = 0.0f;
                            }
                        }
                        else
                        {
                            if (walkTime >= 0.7f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Basement[num]);
                                walkTime = 0.0f;
                            }
                        }
                        if (!player.Move_Ok)
                        {
                            if (soundManager.Instance.now_SFX_Check(Basement[num]))
                                soundManager.Instance.StopSoundEffect(Basement[num]);
                        }
                    }
                    else if (hit.transform.CompareTag("Basement_stairs"))
                    {
                        walkTime += Time.deltaTime;

                        if (player.isRun)
                        {
                            if (walkTime >= 0.45f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Basement_Stairs[num]);
                                walkTime = 0.0f;
                            }
                        }
                        else
                        {
                            if (walkTime >= 0.7f)
                            {
                                if (num < 6)
                                    num += 1;
                                else
                                    num = 0;

                                if (num == 6)
                                    num = 0;

                                soundManager.Instance.PlaySoundEffect(Basement_Stairs[num]);
                                walkTime = 0.0f;
                            }
                        }
                        if (!player.Move_Ok)
                        {
                            if (soundManager.Instance.now_SFX_Check(Basement_Stairs[num]))
                                soundManager.Instance.StopSoundEffect(Basement_Stairs[num]);
                        }
                    }
                }
            }
            else
                walkTime = 0.0f;
        }
    }
}