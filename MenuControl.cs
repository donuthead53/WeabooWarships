using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour {
	public GameObject currentButton;
	public GameObject startButton;

	public float timer;
	public Sprite startUp;
	public Sprite startPressed;
	// Use this for initialization
	void Start () {
		timer = 0.1f;
		currentButton =  GameObject.FindGameObjectWithTag ("bullet");
		startButton = GameObject.FindGameObjectWithTag ("start");
	
 	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
			if (Input.GetMouseButtonDown (0)) {
				if (hit != null & hit.collider != false) {

					if(hit.collider.name == "start"){
						currentButton = hit.collider.gameObject;
						hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = startPressed;
					}

				}

			}

		}
		if (Input.GetMouseButtonUp (0)) {
			if (currentButton.name == "start") {
				currentButton.GetComponent<SpriteRenderer> ().sprite = startUp;
			}

		}
	
		if (currentButton.name == "start") {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				SceneManager.LoadScene ("game");
			}
		}

	}
}
