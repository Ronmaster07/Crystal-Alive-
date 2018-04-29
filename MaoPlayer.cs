using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaoPlayer : MonoBehaviour {

	public int indiceMao;
	public List<GameObject> pontosLivres = new List<GameObject>();
	public bool ocupado, mudou, ativar;


	// Use this for initialization
	void Start () {
	
		ocupado = false;
		mudou = false;
		ativar = false;
	}
	
	// Update is called once per frame
	void Update () {



		if(ocupado == true){
			transform.gameObject.tag = "Ocupado";
		}

		if(ativar == true){
			ocupado = false;
			transform.gameObject.tag = "NaoUsado";

		}
		if(ocupado == false){
			transform.gameObject.tag = "Usavel";
			ativar = false;
		}

	}

	void OnTriggerEnter(Collider Coll)
	{
		if(Coll.gameObject.tag == "Cartas")
		{
			ocupado = true;
			transform.gameObject.tag = "Ocupado";
			Debug.Log(gameObject.tag);
		}
	}
	void OnTriggerExit(Collider Coll)
	{
		if(Coll.gameObject.tag == "Cartas")
		{Debug.Log(gameObject.tag);
			ocupado = false;
			transform.gameObject.tag = "Usavel";
		}
	}
}
