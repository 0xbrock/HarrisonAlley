using UnityEngine;
using System.Collections;

public class TargetExit : MonoBehaviour
{
    public float exitAfterSeconds = 10f; // how long to exist in the world
    public float exitAnimationSeconds = 1f; // should be >= time of the exit animation
	public AudioClip escapeSound;

    private bool startDestroy = false;
    private float targetTime;
	private TargetSpawner parent;
	private AudioSource source;

    // Use this for initialization
    void Start()
    {
        // set the targetTime to be the current time + exitAfterSeconds seconds
        targetTime = Time.time + exitAfterSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        // continually check to see if past the target time
        if (Time.time >= targetTime)
        {
			KillTarget();
        }
    }

    // destroy the gameObject when called
    void KillTarget()
    {
		source = parent.GetComponent<AudioSource> ();
		source.PlayOneShot (escapeSound);
		parent.SetOccupied (false);
		// if game manager exists, make adjustments based on target properties
		if (GameManager.gm)
			GameManager.gm.targetMiss(5, 0);
        // remove the gameObject
        Destroy(gameObject);
    }

	public void SetParent(TargetSpawner parent) {
		this.parent = parent;
	}
}
