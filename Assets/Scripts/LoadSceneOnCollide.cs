using UnityEngine;
using System.Collections;

public class LoadSceneOnCollide : MonoBehaviour {
	public string SceneToLoad;

	void OnCollisionEnter(Collision newCollision) {
		if (newCollision.gameObject.tag == "Projectile") {
			GameObject loadingObject = GameObject.FindGameObjectsWithTag ("LoadingText")[0];
			var renderer = loadingObject.GetComponent<MeshRenderer> ();
			renderer.enabled = true;
			Application.LoadLevel (SceneToLoad);
		}
	}

}
