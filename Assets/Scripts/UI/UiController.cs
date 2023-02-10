using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

namespace UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject handler;
        [SerializeField] private GameObject target;
        [SerializeField] private Button restart;
        [SerializeField] private Button start;
        [SerializeField] private TMP_Text textHandler;
        
        /// <summary>
        /// UI management.
        /// </summary>
        private void Start()
        {
            AddListeners();
        }
        private void AddListeners()
        {
            Containers.ActionContainer.OnHit += LoseHandler;
            restart.onClick.AddListener(OnClickRestart);
            start.onClick.AddListener(Move);
        }
        private void LoseHandler()
        {
            textHandler.text = "YOU CRASHED";
            Containers.ActionContainer.OnEffectsStateChanged(true);
            panel.SetActive(true);
            handler.SetActive(true);
            restart.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                OnClickRestart();
            }
        }
        private void OnClickRestart()
        {
            Containers.ActionContainer.OnRestart();
            Containers.ActionContainer.OnEffectsStateChanged(false);
            Cursor.lockState = CursorLockMode.Locked;
            start.gameObject.SetActive(true);
            panel.SetActive(false);
            handler.SetActive(false);
            restart.gameObject.SetActive(false);
            
        }
        private void Move()
        {
            Containers.ActionContainer.OnMove();
            start.gameObject.SetActive(false);
        }
    }
}

