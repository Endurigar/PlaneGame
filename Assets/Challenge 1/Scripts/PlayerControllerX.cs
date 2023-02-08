using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private float autoSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float autoFall;
    [SerializeField] private Rigidbody playerBody;
    private int maxHeihgt = 20;
    private float correctionAngle = 0.2f;
    private float verticalInput;
    private float horizontalInput;
    private bool canMove;
    private  Gyroscope jyro;

    // Start is called before the first frame update
    private void Start()
    {
        jyro = Input.gyro;
        jyro.enabled = true;
        AddListeners();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        if (canMove == true)
        {
            if(transform.position.y >=maxHeihgt)
            {
                transform.DORotate(new Vector3(maxHeihgt, transform.rotation.y, transform.rotation.z), correctionAngle);
            }
#if UNITY_ANDROID
            if (SystemInfo.supportsGyroscope)
            {
                playerBody.transform.Rotate (0, -Input.gyro.rotationRateUnbiased.z * autoSpeed, 0);
                playerBody.transform.Rotate (-Input.gyro.rotationRateUnbiased.x,  0, 0);
            }
#endif
#if UNITY_EDITOR_WIN
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
#endif
            transform.position += (transform.forward * Time.deltaTime * autoSpeed);
            transform.RotateAround(transform.up, Time.deltaTime * rotationSpeed * verticalInput);
            transform.RotateAround(transform.right, Time.deltaTime * rotationSpeed * horizontalInput);
        }
    }
    private void AddListeners()
    {
        ActionContainer.OnHit += LoseHandler;
        ActionContainer.OnRestart += () => playerBody.constraints = RigidbodyConstraints.FreezeAll;
        ActionContainer.OnMove += () => canMove = true;
    }
    private void LoseHandler ()
    {
        canMove = false;
        playerBody.constraints = RigidbodyConstraints.None;
    }
}

