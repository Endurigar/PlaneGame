using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private ParticleSystem smoke;
    private void Start()
    {
        AddListeners();
    }
    private void AddListeners()
    {
        ActionContainer.OnEffectsStateChanged += EffectsController;
    }
    private void EffectsController(bool check)
    {
        if(check)
        {
            explosion.Play();
            smoke.Play();
            return;
        }
        explosion.Stop();
        smoke.Stop();
    }
}
