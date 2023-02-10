using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sounds
{
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
           Containers.ActionContainer.OnMove += () => planeSound.Play();
           Containers.ActionContainer.OnHit += (() => explosion.Play());
           Containers.ActionContainer.OnCoinTriggerEnter += (() => coinsSound.Play());
       }
   } 
}

