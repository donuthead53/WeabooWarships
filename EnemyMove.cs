using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	float barDisplay = 0;
	Vector2 pos = new Vector2(20,40);
	Vector2 size = new Vector2(30,8);
	GUIStyle progressBarEmpty;
	GUIStyle progressBarFull;

	public float speed;
	public Transform target;
	int nodeNumber;
	string currentNode;
	GameObject go;
	public int hp;

	Vector3 diff;
	float rot_z;
	Vector3 screenPos;
	// Use this for initialization
	void Start () {
		
		progressBarEmpty = new GUIStyle ();
		progressBarFull = new GUIStyle ();
		nodeNumber = 0;
		currentNode = "Node #" + nodeNumber;
	}
	
	// Update is called once per frame
	void Update () {
		
		screenPos = Camera.main.WorldToScreenPoint(transform.position);
		screenPos.y = Screen.height - screenPos.y;
		//Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		currentNode = "Node #" + nodeNumber;
		go = GameObject.Find(currentNode);
		target = go.transform;
		diff = target.position - transform.position;
		diff.Normalize ();

		rot_z = Mathf.Atan2 (diff.y, diff.x)* Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, rot_z - 90));

		transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

		if (hp <= 0) {
			GameControl.money += 10;
			GameControl.mobs.Remove (gameObject);
			Destroy (gameObject);
		}
		barDisplay = hp * 0.1f;
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "bullet") {
			hp--;
			Destroy (col.gameObject);
		}
		else if (col.gameObject.tag == "node") {
			Debug.Log ("Hi");
			nodeNumber++;
		}
		else if (col.gameObject.tag == "endNode") {
			GameControl.mobs.Remove (gameObject);
			Destroy (gameObject);
			GameControl.lives--;
		}
	}
	Texture2D MakeTex(int width, int height, Color col){
		Color[] pix = new Color[width * height];
		for(int i = 0; i < pix.Length;++i){
			pix [i] = col;
		}
		Texture2D result = new Texture2D (width, height);
		result.SetPixels (pix);
		result.Apply ();
		return result;
	}
	void OnGUI(){
		
		progressBarEmpty.normal.background = MakeTex ((int)size.x, (int)size.y, Color.red);
		progressBarFull.normal.background = MakeTex ((int)size.x, (int)size.y, Color.green);
		GUI.color = Color.red;
	
		GUI.BeginGroup(new Rect(screenPos.x-10,screenPos.y-20,size.x,size.y));

		GUI.Box (new Rect (0, 0, size.x, size.y),"",progressBarEmpty);
		GUI.color = Color.green;
		GUI.BeginGroup (new Rect (0,0, size.x * barDisplay, size.y));

		GUI.Box(new Rect(0,0,size.x,size.y),"",progressBarFull);

		GUI.EndGroup ();

		GUI.EndGroup ();
	}


}
