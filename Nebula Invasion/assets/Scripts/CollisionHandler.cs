using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;

    [SerializeField] float loadLevelDelay = 1f;
    [SerializeField] float destroyDelay = .2f;

    void OnCollisionEnter(Collision other)
    {
        // Debug.Log(this.name + " collided with " + other.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log(this.name + " triggered by " + other.gameObject.name);

        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<PlayerControls>().enabled = false;

        Invoke("ReloadLevel", loadLevelDelay);

        ExplosionEffect();
    }

    void ExplosionEffect()
    {
        crashParticle.Play();

        Invoke("DestroyVehicle", destroyDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    void DestroyVehicle()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
}
