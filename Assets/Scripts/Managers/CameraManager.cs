using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager cameraInstance;

    public GameManager gameManager;
    public CinemachineBrain cinemachineBrain;
    public CinemachineVirtualCamera vCam;


    /// <summary>
    /// On awake, this function sets this game object to a camera manager singleton
    /// </summary
    private void Awake()
    {
        // Check if this game object already exists
        if (cameraInstance == null)
        {
            // Set this to game manager singleton
            cameraInstance = this;

            // Don't destroy between scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy this game object
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// When called, this function returns the current singleton instance of the game manager
    /// </summary>
    /// <returns>game manager instance</returns>
    public static CameraManager GetInstance()
    {
        return cameraInstance;
    }

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        // Set needed components
        SetComponents();

        FindCamera("Camera");

    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        cinemachineBrain = GetComponent<CinemachineBrain>();
    }


    /// <summary>
    /// When called, this function searchs for a camera based on name
    /// </summary>
    /// <param name="name">name of camera to find</param>
    public void FindCamera(string name)
    {
        vCam = GameObject.Find(name).GetComponent<CinemachineVirtualCamera>();
    }

    /// <summary>
    /// When called, this function sets the target for camera
    /// </summary>
    /// <param name="target">transform of target</param>
    public void SetCameraTarget(Transform target)
    {
        vCam.Follow = target;
        //vCam.LookAt = target;
    }

    /// <summary>
    /// When Called, this function set the size of camera
    /// </summary>
    /// <param name="size">desired size of camera</param>
    public void SetCameraSize(float size)
    {
        vCam.m_Lens.OrthographicSize = size;
    }

    /// <summary>
    /// When called, this function switches between two dirrent cameras based on priority
    /// </summary>
    /// <param name="startCamName">name of start camera in scene</param>
    /// <param name="endCamName">name of end camera in scene</param>
    public void SwitchCamera( string startCamName, string endCamName )
    {
        // Get temporary refernce to both cameras
        CinemachineVirtualCamera startCam = GameObject.Find(startCamName).GetComponent<CinemachineVirtualCamera>();
        CinemachineVirtualCamera endCam = GameObject.Find(endCamName).GetComponent<CinemachineVirtualCamera>();

        // Decrease priority of start camera
        startCam.Priority = 0;

        // Increase priority of end camera
        endCam.Priority = 10;
    }


}
