using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 1.5f;
    [SerializeField] ParticleSystem crashEffect;
     void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ground")){

            crashEffect.Play();
            Invoke("ReloadScene", delayTime);
        }
    }

    void ReloadScene(){
        Debug.Log("crashing!");
        SceneManager.LoadScene(0);
    }
}
