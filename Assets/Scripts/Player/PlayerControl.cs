using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private float autoSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float autoFall;
        [SerializeField] private Rigidbody playerBody;
        private bool canMove;
        private readonly float correctionAngle = 0.2f;
        private Gyroscope gyroscope;
        private float horizontalInput;
        private readonly int maxHeihgt = 20;
        private float verticalInput;

        /// <summary>
        ///  Implemented functionality for player movement and height control.
        /// </summary>
        private void Start()
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            AddListeners();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void FixedUpdate()
        {
            PlayerMove(canMove);
        }

        private void AddListeners()
        {
            Containers.ActionContainer.OnHit += LoseHandler;
            Containers.ActionContainer.OnRestart += () => playerBody.constraints = RigidbodyConstraints.FreezeAll;
            Containers.ActionContainer.OnMove += () => canMove = true;
        }

        private void LoseHandler()
        {
            canMove = false;
            playerBody.constraints = RigidbodyConstraints.None;
        }

        private void HaightControl()
        {
            if (transform.position.y >= maxHeihgt)
                transform.DORotate(new Vector3(maxHeihgt, transform.rotation.y, transform.rotation.z), correctionAngle);
        }

        private void PlayerMove(bool canMove)
        {
            if (canMove)
            {
                HaightControl();
#if UNITY_ANDROID
                if (SystemInfo.supportsGyroscope)
                {
                    playerBody.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.z * autoSpeed, 0);
                    playerBody.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
                }
#endif
#if UNITY_EDITOR_WIN
                verticalInput = Input.GetAxis("Vertical");
                horizontalInput = Input.GetAxis("Horizontal");
#endif
                transform.position += transform.forward * Time.deltaTime * autoSpeed;
                transform.RotateAround(transform.up, Time.deltaTime * rotationSpeed * verticalInput);
                transform.RotateAround(transform.right, Time.deltaTime * rotationSpeed * horizontalInput);
            }
        }
    }
}