using UnityEngine;
using System.Collections;

public class FloatingMessage : MonoBehaviour {


	public float speed = 10f;
	public float duration = 3;
	public float alpha;
	float x;
	float y;
	float z;
	public bool shouldStart = false;
	public GameObject target;

	void Start () {
		
	}

	public void setMessage(string message){
		GetComponent<GUIText>().text = message;
	}

	public void setColor(Color color){
		GetComponent<GUIText> ().color = new Color(color.r,color.g,color.b,255);

	}

	public void startFloating(){
		shouldStart = true;
		GetComponent<GUIText> ().anchor = TextAnchor.MiddleCenter;
	}

	public void setStartingPosition(Transform transform){
		x = transform.position.x;
		z = transform.position.z;
	}


	public void setTarget(GameObject go){
		this.target = go;
		y = target.transform.position.y + .2f;
	}

	void Update () {
		alpha = GetComponent<GUIText> ().color.a;
		if(shouldStart){
			if (alpha>0){
				y = y + Time.deltaTime * speed;
				if(target != null){
					x = target.transform.position.x;
					z = target.transform.position.z;
				}
				transform.position =  Camera.main.WorldToViewportPoint(new Vector3(x, y, z)); 
				alpha -= Time.deltaTime/duration;
				GUIText text = GetComponent<GUIText>();
				text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

			} else {
				Destroy(gameObject); // text vanished - destroy itself
				Destroy(this);
			}
		}
	}
}
