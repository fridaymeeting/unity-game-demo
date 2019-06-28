using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraControler : MonoBehaviour
{
    // Start is called before the first frame update
    public float triggerX;
    private GameObject player;
    private CinemachineVirtualCamera[] virtualCameras = new CinemachineVirtualCamera[5];
    private bool activated = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        virtualCameras=gameObject.GetComponentsInChildren<CinemachineVirtualCamera>();
        foreach (CinemachineVirtualCamera vc in virtualCameras)
        {
            if (vc.gameObject.name == "CM vcam1")
            {
                vc.gameObject.SetActive(true);
            }
            else
            {
                vc.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > triggerX && !activated)
        {
            foreach (CinemachineVirtualCamera vc in virtualCameras)
            {
                if (vc.gameObject.name== "CM vcam1")
                {
                    vc.gameObject.SetActive(false);
                }
                if (vc.gameObject.name == "CM vcam2")
                {
                    vc.gameObject.SetActive(true);
                }
            }
            activated = true;
            Invoke("Restore", 3);
        }
    }
    void Restore()
    {
        foreach (CinemachineVirtualCamera vc in virtualCameras)
        {
            if (vc.gameObject.name == "CM vcam1")
            {
                vc.gameObject.SetActive(true);
            }
            if (vc.gameObject.name == "CM vcam2")
            {
                vc.gameObject.SetActive(false);
            }
        }
    }
}
