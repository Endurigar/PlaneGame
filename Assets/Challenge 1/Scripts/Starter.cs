using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class Starter : MonoBehaviour
{
    private KeyCode keyStart = KeyCode.W;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject panelHandler;
    [SerializeField] GameObject points;
    [SerializeField] TMP_Text panelText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] private float timeRemaining;
    private bool timerIsRunning = false;
    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began || Input.GetKeyDown(keyStart))
        {
            timerIsRunning = true;
            panelText.text = string.Empty;
            panelHandler.SetActive(false);
        }
        if (timerIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                float seconds = Mathf.FloorToInt(timeRemaining % 60);
                if (seconds<1)
                {
                    timerText.text = "GO";
                }
                else
                {
                    timerText.text = Mathf.Clamp(seconds, 1, 4).ToString();
                }
                    
            }
            else
            {
                ActionContainer.OnMove();
                timerIsRunning = false;
                points.SetActive(true);
                panel.SetActive(false);
                timerText.gameObject.SetActive(false);
                enabled = false;
            }
        }
    }
}
