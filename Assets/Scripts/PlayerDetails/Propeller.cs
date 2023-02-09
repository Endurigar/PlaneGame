using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    private bool canMove = false;
    private float propellerSpeed = 20f;
    
    /// <summary>
    /// Propeller settings and its functionality.
    /// </summary>
    private void Start()
    {
        AddListeners();
    }
    private void Update()
    {
        if(canMove == true)
        {
        var currentEuler = transform.localEulerAngles;
        currentEuler.z += propellerSpeed;
        transform.localEulerAngles= currentEuler;
        }
    }
    private void AddListeners()
    {
        ActionContainer.OnMove += () => canMove = true;
        ActionContainer.OnRestart += () => canMove = false;
        ActionContainer.OnHit += () => canMove = false;
    }
}
