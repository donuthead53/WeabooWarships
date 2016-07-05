using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public GameObject Circle;
	private GameObject c;
	float radius;
	bool growing;
	float scale;
	// Use this for initialization
	void Start () {
		
		growing = true;
		radius = 0.5f;
		c = (GameObject)Instantiate (Circle, new Vector3(transform.position.x,transform.position.y,90),Quaternion.identity);
		c.transform.localScale = new Vector3 (radius, radius, 0);
	}

	// Update is called once per frame
	void Update () {
		if (GameControl.online == true) {
			

			if (Input.GetMouseButtonDown(0)) {
				c.transform.position = new Vector3 (transform.position.x, transform.position.y, -9);
				Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector2 v = new Vector2 (mouse.x, mouse.y);
				if (c.GetComponent<Collider2D> () == Physics2D.OverlapPoint (v)) {
					GameControl.skip = true;
				}
			}
			else{
				c.transform.position = new Vector3 (transform.position.x, transform.position.y, 90);
			}
			c.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
			if (growing == true) {
				scale += 0.2f * Time.deltaTime;
				if (scale >= 0.1) {
					growing = false;
				}
			} else {
				scale -= 0.2f * Time.deltaTime;
				if (scale <= 0) {
					growing = true;
				}
			}
			c.transform.localScale = new Vector3 (radius + scale, radius + scale, 0);
		}
		else{
			c.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0f);
		}
	}

}
