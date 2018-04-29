using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emissores : MonoBehaviour {

	public bool preparado;
	public GameObject alvoDispon, tazoativado;
	public bool Tipos, Caminho, Mover;
	public float proxim = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		bool used = false;

//		if(alvoDispon == null){
//			Debug.Log("Alvo Indisponivel");
//
//		}
		if(preparado == true){
			this.transform.position = Vector3.Lerp (this.transform.position, alvoDispon.transform.position, 3 * Time.deltaTime);
			used = true;
			tazoativado.GetComponent<Tazos1>().Reservado = true;
		}

		//		if(used == true){
//			transform.position = alvoDispon.transform.position;
//		}
		if(Tipos == true){
			if(Caminho == true){
				alvoDispon = GameObject.FindGameObjectWithTag("Degrau");
			}

		}
//		if(used == true){
//		float dist = (float) Vector3.Distance (transform.position,alvoDispon.transform.position);
//		if(dist <= proxim){
//			transform.position = alvoDispon.transform.position;
//		}	
//		}
	}
//void OnTriggerEnter (Collider coll){
//	if(coll.gameObject.tag == "Degrau")
//	{
//		transform.position = alvoDispon.transform.position;
//	}
//}
}
