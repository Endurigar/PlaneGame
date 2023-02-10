using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Triggers
{
    public class CoinTrigger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem coinEffect;
        [SerializeField] private GameObject coinBody;
        
        /// <summary>
        /// Trigger coins/points.
        /// </summary>
        private void OnTriggerEnter(Collider coin)
        {
            Containers.ActionContainer.OnCoinTriggerEnter();
            coinBody.SetActive(false);
            coinEffect.gameObject.SetActive(true);
            StartCoroutine(Destroy());
        }
    
        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}

