using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    public GameManager gameManager;
    public CinemachineVirtualCamera vCam;
    public Transform cameraTarget;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    void Start()
    {
        SetComponents();
        SetCameraTarget(cameraTarget);
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        vCam = GetComponent<CinemachineVirtualCamera>();
        cameraTarget = PlayerManager.GetInstance().transform;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    public void SetCameraTarget(Transform target)
    {
        vCam.Follow = target;
        vCam.LookAt = target;
    }
}
