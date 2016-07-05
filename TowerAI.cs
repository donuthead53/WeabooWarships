using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TowerAI : MonoBehaviour {
	GameObject go;
	public Transform target;
	public GameObject bullet1;
	public GameObject front;

	public GameObject turret1;
	public GameObject turret2;
	public GameObject turret3;

	public float radius;
	public GameObject circle;
	private GameObject c;
	private GameObject f;

	private GameObject t1;
	private GameObject t2;
	private GameObject t3;

	public CircleCollider2D myCollider;

	public float fireTimer;
	public bool firing;

	public float speed;



	Vector3 diff;

	Vector3 t2diff;
	Vector3 t3diff;
	float rot_z;

	public bool turning = true;

	public float rotationSpeed;
	private Quaternion lookRotation;

	Vector3 mouseATM;

	Vector2 tmpDimension;
	float width;

	Vector3 frontVector; 
	Vector3 diffVector;

	public bool secondTurret;
	public bool thirdTurret;

	float bulletSpd;



	Vector3 frontPosition;
	Vector3 playerPosition;
	Vector3 targetLocation;
	Vector3 travelVector;
	void initializeVectorInformation(){
		tmpDimension.x = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

		width = tmpDimension.x / 2f * 0.26667f;
		playerPosition = new Vector3 (transform.position.x,transform.position.y,transform.position.z);
		frontPosition = new Vector3 (playerPosition.x + width, playerPosition.y, playerPosition.z);
		targetLocation = playerPosition;

	}

	void moveShip(){
		


		travelVector = targetLocation - frontPosition;
		Vector3 direction = frontPosition - playerPosition;
		direction = Quaternion.RotateTowards (Quaternion.Euler(direction), Quaternion.Euler(travelVector), 2).eulerAngles;

		Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D> ();
		Vector3 v = new Vector3 (direction.x, direction.y, direction.z);
		v.Normalize ();
		rigid.velocity = (v * speed);

		//frontPosition += direction;

	}



	// Use this for initialization
	void Start () {

		secondTurret = false;
		thirdTurret = false;
		tmpDimension.x = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
		width = tmpDimension.x / 2f * 0.26667f;
		//initializeVectorInformation ();
		//Vector3 frontVector = new Vector3 (transform.position.x+(tmpDimension.x/2*0.2667f), transform.position.y, transform.position.z);
		f = (GameObject)Instantiate (front, new Vector3 (transform.position.x, transform.position.y, transform.position.z),Quaternion.identity);

		speed = 1f;

		c = (GameObject)Instantiate (circle, new Vector3 (transform.position.x, transform.position.y, 0),Quaternion.identity);
		c.transform.localScale = new Vector3 (radius * 2.5f, radius * 2.5f, 0);

		t1 = (GameObject)Instantiate(turret1, new Vector3 (transform.position.x, transform.position.y, -8),Quaternion.identity);

		if (secondTurret == true) {
			t2 = (GameObject)Instantiate(turret1, new Vector3 (transform.position.x+0.5f, transform.position.y, -8),Quaternion.identity);
		}
		if (thirdTurret == true) {
			t3 = (GameObject)Instantiate(turret1, new Vector3 (transform.position.x-0.5f, transform.position.y, -8),Quaternion.identity);
		}


		myCollider = c.GetComponent<CircleCollider2D> ();
		myCollider.radius = 1.24f;

	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 mouseDiff = mouse - transform.position;
		mouseDiff.Normalize ();

		c.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		t1.transform.position = new Vector3 (transform.position.x, transform.position.y, -8);
		if (secondTurret == true) {
			t2.transform.position =	new Vector3 (transform.position.x + Mathf.Cos (transform.eulerAngles.z*Mathf.Deg2Rad)* width, transform.position.y + Mathf.Sin (transform.eulerAngles.z*Mathf.Deg2Rad)* width, transform.position.z);
		}
		if (thirdTurret == true) {
			t3.transform.position = new Vector3 (transform.position.x - Mathf.Cos (transform.eulerAngles.z*Mathf.Deg2Rad)* width, transform.position.y - Mathf.Sin (transform.eulerAngles.z*Mathf.Deg2Rad)* width, transform.position.z);
		}
			if (GameControl.mobs.Count <= 0) {
			
				target = null;
				firing = false;
			}

			//Range Collision

			if (GameControl.mobs.Count > 0) {
				//Debug.Log ("Mobs: "+GameControl.mobs [0].GetComponent<Collider2D> ().bounds);
				//Debug.Log ("Circles: "+myCollider.bounds);
				for (int i = 0; i < GameControl.mobs.Count; i++) {
					
					if (myCollider.IsTouching (GameControl.mobs [i].GetComponent<Collider2D> ())) {
					
						target = GameControl.mobs [i].transform;

						diff = target.position - transform.position;
						diff.Normalize ();

						if (secondTurret == true) {
							t2diff = target.position - t2.transform.position;
							t2diff.Normalize ();
						}
						if (thirdTurret == true) {
							t3diff = target.position - t3.transform.position;
							t3diff.Normalize ();
						}

						rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
						t1.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, rot_z - 90));
						if (secondTurret == true) {
							t2.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, rot_z - 90));
						}
						if (thirdTurret == true) {
							t3.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, rot_z - 90));
						}
						firing = true;
						break;
					} else {
						target = null;
						firing = false;
					}
					
				}
			}

//		//Moving Code
		//Moving Code
		if (turning == true) {

			float z = Mathf.Atan2 (mouseATM.y, mouseATM.x) * Mathf.Rad2Deg;


			f.transform.position = new Vector3 (transform.position.x + Mathf.Cos (transform.eulerAngles.z*Mathf.Deg2Rad)* width, transform.position.y + Mathf.Sin (transform.eulerAngles.z*Mathf.Deg2Rad)* width, transform.position.z);
			//Debug.Log ("f transform: "+f.transform.position);
			//Debug.Log ("real transform: "+transform.position);

			diffVector = f.transform.position - transform.position; 
			diffVector.Normalize ();

			float frontZ = Mathf.Atan2(diffVector.y, diffVector.x) * Mathf.Rad2Deg;
			//Debug.Log ("diff "+frontZ);
			Quaternion q;

			//Debug.Log (" Z: "+transform.eulerAngles.z);
			q = Quaternion.Euler(0f,0f,frontZ);



			transform.rotation = Quaternion.Slerp(q ,Quaternion.Euler(0,0,z),Time.deltaTime*1f);



			//Debug.Log ("MouseATM "+ transform.rotation);
			//Debug.Log ("Front Vector: "+ frontZ);
		}

		if (gameObject == GameControl.selected) {


			mouseDiff.Normalize ();
			Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D> ();

			if (Input.GetMouseButtonDown (1)) {
				mouseATM = mouseDiff;
				turning = true;
				Vector2 v = new Vector2 (mouseATM.x, mouseATM.y);
				v.Normalize ();
				rigid.velocity = (v * speed);
			}

		}
//		moveShip();
		//Firing Code
		if (firing == true) {
			bulletSpd = 30f;
			fireTimer -= Time.deltaTime;

			if (fireTimer < 0) {
				GameObject clone;
				GameObject clone1;
				GameObject clone2;

				clone = (GameObject)Instantiate (bullet1, transform.position, transform.rotation);

				Rigidbody2D rigid = clone.GetComponent<Rigidbody2D> ();
				rigid.velocity = new Vector2 (diff.x, diff.y) * bulletSpd;

				//sDebug.Log ("1: " + new Vector2 (diff.x, diff.y) * bulletSpd);


				if (secondTurret == true) {
					
					clone1 = (GameObject)Instantiate (bullet1, t2.transform.position, transform.rotation);

					Rigidbody2D rigid1 = clone1.GetComponent<Rigidbody2D> ();
					rigid1.velocity = new Vector2 (t2diff.x, t2diff.y)* bulletSpd;


					Destroy (clone1, 5.0f);
					//Debug.Log ("2: " + new Vector2 (t2diff.x, t2diff.y) * bulletSpd);

				}
				if (thirdTurret == true) {
					clone2 = (GameObject)Instantiate (bullet1, t3.transform.position, transform.rotation);

					Rigidbody2D rigid2 = clone2.GetComponent<Rigidbody2D> ();
					rigid2.velocity = new Vector2 (t3diff.x, t3diff.y)* bulletSpd;

					Destroy (clone2, 5.0f);
					//Debug.Log ("3: " + new Vector2 (t3diff.x, t3diff.y) * bulletSpd);
				}
				Destroy (clone, 5.0f);
				fireTimer = 0.2f;
			}
		}

		//Wave Code




		//Range Code
		if (GameControl.selected == gameObject) {
			c.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.5f);
		} 
		else {
			c.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
		}
	}

}
