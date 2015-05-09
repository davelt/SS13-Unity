using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
[@RequireComponent(typeof(BoxCollider2D))]

public class WearClothes : MonoBehaviour {
	public GameObject Human;
	bool pickedUp = false;
	string objectName;
	string i;

	// Use this for initialization
	void Start () {
		objectName = this.gameObject.name;
		string[] digits= Regex.Split(objectName, @"\D+");
		foreach (string value in digits)
		{
			int number;
			if (int.TryParse(value, out number))
			{

				i = value;
			
			}
		}
	}

	

	// Update is called once per frame
	void Update () {
		if (pickedUp){
			Destroy (this.gameObject);
		}
	
	}

	void OnMouseDown()
	{
		pickedUp = true;
		if (this.gameObject.name == "hats_"+i) {
			GameObject childObject = (GameObject)Instantiate (Resources.Load ("head_"+i));
			AttachObject(childObject);
		}
		if (this.gameObject.name == "uniforms_0") {
			GameObject childObject = (GameObject)Instantiate (Resources.Load ("uniform_0"));
			AttachObject(childObject);
		}
		if (this.gameObject.name == "storage_"+i) {
			GameObject childObject = (GameObject)Instantiate (Resources.Load ("back_"+i));
			AttachObject(childObject);
		}


	}
	void AttachObject(GameObject childObject){
		GameObject human = Human;
		childObject.transform.parent = Human.gameObject.transform;
		childObject.transform.localScale += new Vector3(1F, 1F,0);
		childObject.transform.position = new Vector3(Human.transform.position.x, Human.transform.position.y, 0);
	}
}
