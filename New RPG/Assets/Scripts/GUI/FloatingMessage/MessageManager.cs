using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createNewMessage(GameObject target, string message, Color color){
		GameObject go =(GameObject) GameObject.Instantiate (Resources.Load("Floating Message"), Camera.main.WorldToViewportPoint(target.transform.position),
	                                                    Quaternion.identity);
		FloatingMessage fm = go.GetComponent<FloatingMessage> (); 
		fm.setMessage (message);
		fm.setColor (color);
		fm.setStartingPosition (target.transform);
		fm.setTarget (target);
		fm.startFloating ();
	}


}
