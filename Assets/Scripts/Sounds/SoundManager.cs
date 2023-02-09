using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource planeSound;
    [SerializeField] private AudioSource explosion;
    [SerializeField] private AudioSource coinsSound;
    
    /// <summary>
    /// Sound management.
    /// </summary>
    private void Start()
    {
        AddListeners();
    }
    private void AddListeners()
    {
        ActionContainer.OnMove += () => planeSound.Play();
        ActionContainer.OnHit += (() => explosion.Play());
        ActionContainer.OnCoinTriggerEnter += (() => coinsSound.Play());
    }
}
