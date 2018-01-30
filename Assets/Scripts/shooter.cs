using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {
    
	public GameObject projectile,gun;
	private Animator animator;
	private GameObject projectileParent;
	private Spawner myLaneSpawner;

	void Start () {
		animator = GameObject.FindObjectOfType <Animator> ();
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");

		}
		SetMyLaneSpawner ();

	}
	void Update () {
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	} 
	bool IsAttackerAheadInLane() {
		//Exit if no attacker in Lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		// If there are attacker, are they ahead?
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x){
				return true;
			}
		}
		// Attacker in lane, but behind us.
		return false; 
	}
	void SetMyLaneSpawner () {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();
		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + "can't find spawner in Lane");
	}

	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
