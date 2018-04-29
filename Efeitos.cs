using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efeitos : MonoBehaviour {

public GameObject tazoo, emitte, emissive, contorn, casca;
public GameObject alvoSelecionado;
public float margem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		alvoSelecionado = GameObject.FindGameObjectWithTag("Ativadores");
		margem = Vector3.Distance(transform.position,alvoSelecionado.transform.position);

		if(margem <= 1.0f){
			Destroy(tazoo,1.0f);
			Destroy(emitte,1.0f);
			Destroy(emissive,1.0f);
			Destroy(contorn,1.0f);
			Destroy(casca,1.0f);
		}
	}
	 void OnTriggerEnter(Collider colidiu)
    {
		if(colidiu.gameObject.tag == "Ativadores")
		{
			Destroy(tazoo,1.0f);
			Destroy(emitte,1.0f);
			Destroy(emissive,1.0f);
			Destroy(contorn,1.0f);
			Destroy(casca,1.0f);
			Debug.Log("ativou");
		}
	}
}
