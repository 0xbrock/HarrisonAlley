using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {
	public GameObject targetPrefab;
	public float maxTimeBetweenSpawns;

	private double timeToSpawn;
	private bool occupied;

	void Start() {
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
	}

	private void SpawnTarget() {
		var target = Instantiate (targetPrefab);
		target.transform.position = gameObject.transform.position;
	}
}
