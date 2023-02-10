using Containers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject panelHandler;
        [SerializeField] private GameObject points;
        [SerializeField] private TMP_Text panelText;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private float timeRemaining;
        private readonly KeyCode keyStart = KeyCode.W;
        private bool timerIsRunning;

        /// <summary>
        ///     Starting a countdown after the launch by the player.
        /// </summary>
        private void FixedUpdate()
        {
            CountdownStart();
        }

        private void CountdownStart()
        {
            if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(keyStart))
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
                    if (seconds < 1)
                        timerText.text = "GO";
                    else
                        timerText.text = Mathf.Clamp(seconds, 1, 4).ToString();
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
}