using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Restart : MonoBehaviour
    {
        private Quaternion startRotation;
        private Vector3 startPosition;
        
        /// <summary>
        /// Player respawn at starting positions after losing.
        /// </summary>
        public void Start()
        {
            Containers.ActionContainer.OnRestart += RestartHandler;
            startPosition= transform.position;
            startRotation= transform.rotation;
        }
        private void RestartHandler()
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }
}

