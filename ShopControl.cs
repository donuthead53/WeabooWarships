using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ShopControl : MonoBehaviour {
	public  GameObject selected;
	public  GameObject currentButton;

	public GameObject ship1;
	public GameObject ship2;
	public GameObject speedButton;
	public GameObject Turret2;
	public GameObject Turret3;
	public GameObject buy;
	public GameObject done;
	public GameObject temp;

	public Sprite buyUp;
	public Sprite doneUp;
	public Sprite buyPressed;
	public Sprite donePressed;
	// Use this for initialization
	void Start () {
		
		ship1 = GameObject.FindGameObjectWithTag ("kongou");
		ship2 = GameObject.FindGameObjectWithTag ("shimakaze");
		speedButton = GameObject.FindGameObjectWithTag ("speed");
		Turret2 = GameObject.FindGameObjectWithTag ("turret2");
		Turret3 = GameObject.FindGameObjectWithTag ("turret3");
		buy = GameObject.FindGameObjectWithTag ("buy");
		done = GameObject.FindGameObjectWithTag ("done");
		currentButton =  GameObject.FindGameObjectWithTag ("bullet");;
		selected = ship1;
 	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (selected);
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
			if (Input.GetMouseButtonDown (0)) {
				if (hit != null & hit.collider != false) {
					
					if (hit.collider.name == "kongou") {
						selected = hit.collider.gameObject;
						ship1.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
						ship2.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.2f);
					} 
					else if (hit.collider.name == "shimakaze") {
						
						selected = hit.collider.gameObject;
					
					}
					else if(hit.collider.name == "buy"){
						currentButton = hit.collider.gameObject;
						hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = buyPressed;
					}
					else if(hit.collider.name == "done"){
						currentButton = hit.collider.gameObject;
						hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = donePressed;
					}
				}

			}

		}
		if (Input.GetMouseButtonUp (0)) {
			if (currentButton.name == "buy") {
				currentButton.GetComponent<SpriteRenderer> ().sprite = buyUp;
			}
			else if (currentButton.name ==  "done") {
				DontDestroyOnLoad (currentButton);

				SceneManager.LoadScene ("game");
				currentButton.GetComponent<SpriteRenderer> ().sprite = doneUp;
			}
		}
	
		if (selected == ship1) {
			ship1.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
			ship2.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.2f);
		}
		if (selected == ship2) {
			ship2.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
			ship1.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.2f);
		}
			
	}
}
