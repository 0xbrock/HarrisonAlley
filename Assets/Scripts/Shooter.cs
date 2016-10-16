using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public AudioClip shootSound;

	private AudioSource source;
	private Camera camera;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			source.PlayOneShot (shootSound);
			shootRay ();
		}
		foreach (var touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				source.PlayOneShot (shootSound);
				shootRay ();
			}
		}
	}

	private void shootRay() {
		var bullet = Instantiate(projectile);
		bullet.transform.position = gameObject.transform.position + gameObject.transform.forward;
		var rb = bullet.GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * 1500);
	}
}
