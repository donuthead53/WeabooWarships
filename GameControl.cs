using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static bool online;
	public static bool skip;

	public static int lastNode;

	public static int lives;
	public static int money;
	public static int wave;

	public Text LivesText;
	public Text MoneyText;
	public Text WaveText;
	public Text TimerText;

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public static GameObject selected;

	public static List<GameObject> mobs;
	private bool sent;
	private float timer;
	int displayTimer;
	private float timer2;
	int totalWaves;



	// Use this for initialization
	void Start () {
		lastNode = 2;
		online = false;
		selected = null;
		mobs = new List<GameObject>();
		sent = false;
		timer = 5f;
		displayTimer = (int)timer;
		lives = 20;
		money = 0;
		wave = 0;
		totalWaves = 7;
	}
	
	// Update is called once per frame
	void Update () {
		if (lives <= 0) {
			SceneManager.LoadScene ("menu");
		}
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
		if (Input.GetMouseButtonDown (0)) {
			if (hit != null & hit.collider != false) {
				if (hit.collider.tag == "tower") {
					selected = hit.collider.gameObject;
				} else {
					selected = null;
				}
			}
			else {
				selected = null;
			}
		}


		LivesText.text = lives.ToString();
		MoneyText.text = money.ToString();
		WaveText.text = wave.ToString () + "/" + totalWaves;
		if (online == true) {
			displayTimer = (int)timer;
			TimerText.text = displayTimer.ToString ();

		} 
		else {
	
			TimerText.text = "";
		}
		if (wave == 0) {
			online = true;
			timer -= Time.deltaTime;
			if (timer <= 0) {
				wave++;
				online = false;
				sent = false;
				timer = 15f;
				timer2 = 5f;
			}
		}
		if (wave == 1) {
			if (sent == false) {
				timer2 = 5f;
				for (int i = 0; i < 5; i++) {
					mobs.Add ((GameObject)Instantiate (enemy1, new Vector3 (transform.position.x - i*1.5f, transform.position.y, transform.position.z), Quaternion.identity));
				}
				sent = true;
			} else {
				timer2 -= Time.deltaTime;
				if (timer2 <= 0) {
					online = true;
					timer -= Time.deltaTime;
					if (skip == true) {
						wave++;
						online = false;
						sent = false;
						money += (int)(timer * 2.5f);
						timer = 15f;
						timer2 = 5f;
						skip = false;

					}
				}
				if (timer <= 0) {
					wave++;
					online = false;
					sent = false;
					timer = 15f;
					timer2 = 5f;
				}
				
			}

		}
		if (wave == 2) {
			if (sent == false) {
				timer2 = 5f;
				for (int i = 0; i < 3; i++) {
					mobs.Add ((GameObject)Instantiate (enemy1, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
					mobs.Add ((GameObject)Instantiate (enemy2, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
				}
				sent = true;
			} else {
				timer2 -= Time.deltaTime;
				if (timer2 <= 0) {
					Debug.Log ("hello");
					online = true;
					timer -= Time.deltaTime;
					if (skip == true) {
						wave++;
						online = false;
						sent = false;
						money += (int)(timer * 2.5f);
						timer = 15f;
						timer2 = 5f;
						skip = false;
					}
				}
				if (timer <= 0) {
					wave++;
					online = false;
					sent = false;
					timer = 15f;
					timer2 = 5f;
				}

			}

		}
		if (wave == 3) {
			if (sent == false) {
				timer2 = 5f;
				for (int i = 0; i < 3; i++) {
					mobs.Add ((GameObject)Instantiate (enemy1, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
					mobs.Add ((GameObject)Instantiate (enemy2, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
					mobs.Add ((GameObject)Instantiate (enemy3, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
				}
				sent = true;
			} else {
				timer2 -= Time.deltaTime;
				if (timer2 <= 0) {
					Debug.Log ("hello");
					online = true;
					timer -= Time.deltaTime;
					if (skip == true) {
						wave++;
						online = false;
						sent = false;
						money += (int)(timer * 2.5f);
						timer = 15f;
						timer2 = 5f;
						skip = false;
					}
				}
				if (timer <= 0) {
					wave++;
					online = false;
					sent = false;
					timer = 15f;
					timer2 = 5f;
				}

			}

		}
		if (wave == 4) {
			if (sent == false) {
				timer2 = 5f;
				for (int i = 0; i < 5; i++) {
					mobs.Add ((GameObject)Instantiate (enemy1, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
					mobs.Add ((GameObject)Instantiate (enemy2, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
				}
				sent = true;
			} else {
				timer2 -= Time.deltaTime;
				if (timer2 <= 0) {
					Debug.Log ("hello");
					online = true;
					timer -= Time.deltaTime;
					if (skip == true) {
						wave++;
						online = false;
						sent = false;
						money += (int)(timer * 2.5f);
						timer = 15f;
						timer2 = 5f;
						skip = false;
					}
				}
				if (timer <= 0) {
					wave++;
					online = false;
					sent = false;
					timer = 15f;
					timer2 = 5f;
				}

			}

		}
		if (wave == 5) {
			if (sent == false) {
				timer2 = 5f;
				for (int i = 0; i < 10; i++) {
					mobs.Add ((GameObject)Instantiate (enemy3, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));

				}
				sent = true;
			} else {
				timer2 -= Time.deltaTime;
				if (timer2 <= 0) {
					Debug.Log ("hello");
					online = true;
					timer -= Time.deltaTime;
					if (skip == true) {
						wave++;
						online = false;
						sent = false;
						money += (int)(timer * 2.5f);
						timer = 15f;
						timer2 = 5f;
						skip = false;
					}
				}
				if (timer <= 0) {
					wave++;
					online = false;
					sent = false;
					timer = 15f;
					timer2 = 5f;
				}

			}

		}
		if (wave == 6) {
			if (sent == false) {
				timer2 = 5f;
				for (int i = 0; i < 5; i++) {
					mobs.Add ((GameObject)Instantiate (enemy1, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
					mobs.Add ((GameObject)Instantiate (enemy2, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
					mobs.Add ((GameObject)Instantiate (enemy3, new Vector3 (transform.position.x - i , transform.position.y, transform.position.z), Quaternion.identity));
				}
				sent = true;
			} else {
				timer2 -= Time.deltaTime;
				if (timer2 <= 0) {
					Debug.Log ("hello");
					online = true;
					timer -= Time.deltaTime;
					if (skip == true) {
						wave++;
						online = false;
						sent = false;
						money += (int)(timer * 2.5f);
						timer = 15f;
						timer2 = 5f;
						skip = false;
					}
				}
				if (timer <= 0) {
					wave++;
					online = false;
					sent = false;
					timer = 15f;
					timer2 = 5f;
				}

			}

		}
		if (wave == 7) {
			WaveText.text = "YOU WON!";
		}
	}
}
