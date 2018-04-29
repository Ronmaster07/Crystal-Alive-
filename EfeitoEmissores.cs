using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoEmissores : MonoBehaviour {

	public GameObject prefabEfeito, selecaoAlvo;
	public Transform esperaSelecao;
	public bool selecaoFeita, alvoCaminho, reinstancia, consome;
	GameObject efeitoEmit;
	public bool Caminho, Mover, Energia, Ataque, Defesa, Recurso;

	// Use this for initialization
	void Start () {

//		efeitoEmit = (GameObject)Instantiate(prefabEfeito,transform.position, Quaternion.identity);
//		efeitoEmit.SetActive (true);


	}
	
	// Update is called once per frame
	void Update () {
			//mudanca de tag para caminho nao necessaria por enquanto
		if(alvoCaminho == true){
			selecaoAlvo = GameObject.FindGameObjectWithTag("Ativadores");
			selecaoFeita = true;
		}
		if(selecaoFeita == true){
			efeitoEmit.transform.position = Vector3.Lerp (efeitoEmit.transform.position, selecaoAlvo.transform.position, 3 * Time.deltaTime);
		}
		if(reinstancia == true){
			ReInstanciando ();
			efeitoEmit.SetActive (true);
			reinstancia = false;
		}
		if(consome == true){
			DestroyObject(efeitoEmit);
			consome = false;
		}

	}
	GameObject ReInstanciando (){
		efeitoEmit = (GameObject)Instantiate(prefabEfeito,transform.position, Quaternion.identity);
		return efeitoEmit;
	}
}
