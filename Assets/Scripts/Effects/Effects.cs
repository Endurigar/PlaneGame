using Containers;
using UnityEngine;

namespace Effects
{
    public class Effects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosion;
        [SerializeField] private ParticleSystem smoke;

        /// <summary>
        ///     Effects manager.
        /// </summary>
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
            if (check)
            {
                explosion.Play();
                smoke.Play();
                return;
            }

            explosion.Stop();
            smoke.Stop();
        }
    }
}