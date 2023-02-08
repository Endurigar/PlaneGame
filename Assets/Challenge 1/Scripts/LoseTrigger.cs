using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ActionContainer.OnHit();
    }
}
