using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
    public class CameraHolder : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private Vector3 offset = new Vector3(0, 2, -10);
        
        /// <summary>
        /// The player's camera is tied to his game model.
        /// </summary>
        private void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}

