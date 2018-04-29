using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card1 : MonoBehaviour {

	public int ID, indice, IDMao;
	public string Nome;
	public Sprite imagem;
	List<GameObject> InUso;
	List<GameObject> pMao;
	public GameObject deck, pontoMao;
	public GameObject targetA,targetB,target;
	public Transform Rastrear, Rastrear1;
	public bool mudouPonto = false;
	public bool juntar = false;
	public bool Ativado = false;
	public bool Desativado = false;

	// Use this for initialization
	void Start () {
	
		pontoMao = GameObject.FindWithTag("Usavel");
		pMao = pontoMao.GetComponent<MaoPlayer>().pontosLivres;
		deck = GameObject.FindWithTag("Deck");
		InUso = deck.GetComponent<CardsDeck>().mao;




	}
	
	// Update is called once per frame
	void Update () {
		Raycasting();
		IDMao = pontoMao.GetComponent<MaoPlayer>().indiceMao;
		target = deck.GetComponent<CardsDeck>().SlotSelect;
		if(mudouPonto == true){
			pontoMao.GetComponent<MaoPlayer>().ocupado = false;
			pontoMao = targetA;
			transform.position = Vector3.Lerp (transform.position, pontoMao.transform.position, 3 * Time.deltaTime);
			pontoMao.GetComponent<MaoPlayer>().ocupado = true;
			mudouPonto = false;
		}
		if(Ativado == false){
			if(juntar == false){
				transform.position = Vector3.Lerp (transform.position, pontoMao.transform.position, 3 * Time.deltaTime);
				pontoMao.GetComponent<MaoPlayer>().ocupado = true;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(-49,180,0), 4 * Time.deltaTime);
			} 
		}
		if(Ativado == true){
			pontoMao.GetComponent<MaoPlayer>().ativar = true;
			StartCoroutine("Reagrupar");
			pontoMao.GetComponent<MaoPlayer>().ocupado = false;
		}
		if(Desativado == true){
			pontoMao.GetComponent<MaoPlayer>().ativar = false;
			StopCoroutine("Reagrupar");
		}
	}
	public IEnumerator Reagrupar(){
		
		if(Ativado == true){

			yield return new WaitForSeconds(1.0f);

			Desativado = true;
		}

	}
	void Raycasting(){
		
		RaycastHit hit;

			if (Physics.Raycast(Rastrear.position, -(transform.right), out hit, 21)){
			Debug.DrawLine(Rastrear.position, hit.point, Color.red);
			if (hit.collider.gameObject.tag == "Usavel"){
				targetA = hit.transform.gameObject;
				mudouPonto = true;
			}


		}
	}
}
