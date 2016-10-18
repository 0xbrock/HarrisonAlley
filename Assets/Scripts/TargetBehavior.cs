using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{
    public int scoreAmount = 0;
    public float timeAmount = 0.0f;

    public GameObject explosionPrefab;
	public AudioClip deathSound;

	private AudioSource source;
	private TargetSpawner parent;

	void Start() {
	}

    // when collided with another gameObject
    void OnCollisionEnter(Collision newCollision)
    {
		source = parent.GetComponent<AudioSource> ();
        // exit if there is a game manager and the game is over
        if (GameManager.gm && GameManager.gm.gameIsOver)
            return;

        // only do stuff if hit by a projectile
        if (newCollision.gameObject.tag == "Projectile")
        {
            if (explosionPrefab)
            {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            // if game manager exists, make adjustments based on target properties
            if (GameManager.gm)
                GameManager.gm.targetHit(scoreAmount, timeAmount);

			source.PlayOneShot (deathSound);
			parent.SetOccupied (false);

            // destroy the projectile
            Destroy(newCollision.gameObject);

            // destroy self
            Destroy(gameObject);
        }
    }

	public void SetParent(TargetSpawner parent) {
		this.parent = parent;
	}
}
