using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;

    [SerializeField] int scorePerHit = 15;
    [SerializeField] int enemyHitPoints = 3;

    Scoreboard scoreboard;
    Rigidbody rb;
    GameObject parentGameObject;
    AudioSource audioSource;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        parentGameObject = GameObject.FindWithTag("Spawn At Runtime");

        AddRigidbody();
    }

    void AddRigidbody()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        PointsAddedToScoreboard();

        if (enemyHitPoints < 1)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {

        //Debug.Log("Destroyed " + this.gameObject.name + " by " + other.gameObject.name);
        Destroy(gameObject);

        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);

        fx.transform.parent = parentGameObject.transform;

        scoreboard.IncreaseScore(scorePerHit);
    }

    void PointsAddedToScoreboard()
    {
        enemyHitPoints--;

        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);

        vfx.transform.parent = parentGameObject.transform;
    }
}
