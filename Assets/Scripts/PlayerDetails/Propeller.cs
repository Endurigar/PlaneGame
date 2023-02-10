using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerDetails
{
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
            Containers.ActionContainer.OnMove += () => canMove = true;
            Containers.ActionContainer.OnRestart += () => canMove = false;
            Containers.ActionContainer.OnHit += () => canMove = false;
        }
    }
}

