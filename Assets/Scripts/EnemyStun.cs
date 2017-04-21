using UnityEngine;
using System.Collections;

public class EnemyStun : MonoBehaviour {

	bool stun = false;
	public GameObject obj;
	int stuncount=0;
	// if Player hits the stun point of the enemy, then call Stunned on the enemy
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			// tell the enemy to be stunned
			this.GetComponentInParent<Enemy>().Stunned();
			stun = true;
			//make the player bounce off the enemy
			other.gameObject.GetComponent<CharacterController2D>().EnemyBounce();
		}
	}
	void Update(){
		if (stun) {
			stuncount++;
			if (stuncount == 3) {
				obj.SetActive (true);
			}
			stun = false;
		}
	}
}
