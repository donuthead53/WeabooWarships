using UnityEngine;
using System.Collections;

public class mapSize : MonoBehaviour {
	float w;
	float h;
	float worldScreenHeight;
	float worldScreenWidth;
	SpriteRenderer s;
	// Use this for initialization
	void Start () {
		s = GetComponent<SpriteRenderer>();

		transform.localScale = new Vector3 (1, 1, 1);

		 w = s.sprite.bounds.size.x;
		 h = s.sprite.bounds.size.y;

		worldScreenHeight= Camera.main.orthographicSize*2;
		worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		Debug.Log (worldScreenWidth / w+ " / "+ worldScreenHeight / h);
		transform.localScale = new Vector3 ((worldScreenWidth / w), (worldScreenHeight / h), 1);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
