using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class DiscoBall : MonoBehaviour
{
    // Game objects for the disco particles of purple color, red color and orange color prefabs
    public GameObject discoParticlePurple;
    public GameObject discoParticleRed;
    public GameObject discoParticleOrange;

    // This is used to continue looping through the spawn disco particles coroutine
    Coroutine spawnDiscoParticlesCoroutine;

    float randomizePurpleParticleDropped; // Randomizes where the purple particles should be dropped at
    float randomizeRedParticleDropped; // Randomizes where the red particles should be dropped at
    float randomizeOrangeParticleDropped; // Randomizes where the orange particles should be dropped at

    // Start is called before the first frame update
    void Start()
    {
        // Start the looping coroutine to continue looping through the spawn disco particles coroutine
        StartCoroutine(LoopCoroutine());
    }

    IEnumerator LoopCoroutine()
    {
        // Initialize the coroutine to start with the spawn disco particles
        spawnDiscoParticlesCoroutine = StartCoroutine(SpawnDiscoParticles());
        yield return spawnDiscoParticlesCoroutine;

        // Loop the spawn disco particles coroutine while the coroutine variable is not null
        while (spawnDiscoParticlesCoroutine != null)
        {
            spawnDiscoParticlesCoroutine = StartCoroutine(SpawnDiscoParticles());
            yield return spawnDiscoParticlesCoroutine;
        }
    }

    IEnumerator SpawnDiscoParticles()
    {
        // Wait for 1-4 seconds to instantiate the disco purple particle object
        yield return new WaitForSeconds(Random.Range(1, 4));

        discoParticlePurple = Instantiate(discoParticlePurple, (Vector2)transform.position +
            new Vector2(-0.5f, -1.0f), transform.rotation);

        // Wait for 1-4 seconds to instantiate the disco red particle object
        yield return new WaitForSeconds(Random.Range(1, 4));

        discoParticleRed = Instantiate(discoParticleRed, (Vector2)transform.position +
            new Vector2(0.0f, -1.0f), transform.rotation);

        // Wait for 1-4 seconds to instantiate the disco orange particle object
        yield return new WaitForSeconds(Random.Range(1, 4));

        discoParticleOrange = Instantiate(discoParticleOrange, (Vector2)transform.position +
            new Vector2(0.5f, -1.0f), transform.rotation);

        // Wait for 1 second
        yield return new WaitForSeconds(1);

        // Initialize the timer and lerp timer
        float lerpTimer = 0;
        float timer = 0;

        // Drop all the colored particles at random locations on the floor
        randomizePurpleParticleDropped = Random.Range(-4.0f, -4.9f);
        randomizeRedParticleDropped = Random.Range(-4.0f, -4.9f);
        randomizeOrangeParticleDropped = Random.Range(-4.0f, -4.9f);

        // While the timer is less than 15 seconds
        while (timer < 15.0f)
        {
            // Initialize these 3 local Vector2 variables for the moving down of each colored disco particle
            Vector2 moveDownPurpleParticle = new Vector2(discoParticlePurple.transform.position.x, 
                randomizePurpleParticleDropped);

            Vector2 moveDownRedParticle = new Vector2(discoParticleRed.transform.position.x,
                randomizeRedParticleDropped);

            Vector2 moveDownOrangeParticle = new Vector2(discoParticleOrange.transform.position.x,
                randomizeOrangeParticleDropped);

            // Increment both the lerp timer and timer by deltaTime
            lerpTimer += Time.deltaTime;
            timer += Time.deltaTime;

            // Lerp the colored particle's position by its position and the move down colored particles float
            // The lerp timer is divided by 5000 because I want the particles to fall slowly
            discoParticlePurple.transform.position = Vector2.Lerp(discoParticlePurple.transform.position,
                moveDownPurpleParticle, lerpTimer / 5000.0f);

            discoParticleRed.transform.position = Vector2.Lerp(discoParticleRed.transform.position,
            moveDownRedParticle, lerpTimer / 5000.0f);

            discoParticleOrange.transform.position = Vector2.Lerp(discoParticleOrange.transform.position,
            moveDownOrangeParticle, lerpTimer / 5000.0f);

            yield return null; // End the while loop after one frame when the timer exceeds 15 seconds
        }
    }
}
