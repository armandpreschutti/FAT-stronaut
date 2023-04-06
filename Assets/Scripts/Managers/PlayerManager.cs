using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public LocomotionHandler LocomotionHandler;
    public PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        LocomotionHandler= GetComponent<LocomotionHandler>();
        playerInput= GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
