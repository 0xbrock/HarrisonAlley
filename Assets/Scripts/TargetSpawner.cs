using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {
	public GameObject targetPrefab;
	public float maxTimeBetweenSpawns;
	public AudioClip spawnSound;

	private double timeToSpawn;
	private bool occupied;
	private AudioSource source;

	void Start() {
		source = gameObject.GetComponent<AudioSource> ();
		timeToSpawn = Random.Range (5.0f, maxTimeBetweenSpawns);
	}

	// Update is called once per frame
	void Update () {
		if (timeToSpawn < 0.0f && !occupied) {
			timeToSpawn = Random.Range (5.0f, maxTimeBetweenSpawns);
			SpawnTarget ();
			occupied = true;
		} else {
			timeToSpawn -= Time.deltaTime;
		}
	}

	public void SetOccupied(bool occupied) {
		this.occupied = occupied;
		if (occupied == false) {
			timeToSpawn = Random.Range (5.0f, maxTimeBetweenSpawns);
		}
	}

	private void SpawnTarget() {
		source.PlayOneShot (spawnSound);
		var target = Instantiate (targetPrefab);
		target.GetComponent<TargetBehavior> ().SetParent (this);
		target.GetComponent<TargetExit> ().SetParent (this);
		target.transform.position = gameObject.transform.position;
        target.transform.rotation = gameObject.transform.rotation;
	}
}
