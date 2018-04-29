using UnityEngine;
using System.Collections;

public class CaminhoPecaLV4 : MonoBehaviour {

	public bool encaixa, caminhoFeito;
	public GameObject Caminho4;
	//public Vector3 posicao, rotacao;
	public GameObject[] selecMin;
	public GameObject raiz;
	public GameObject selec;
	public GameObject selMin;
	public GameObject elo;
	public Animator animadorPeca;
	public Animator animadorSelemin;

	void Start () {
		encaixa = true;
		Caminho4.SetActive(false);
		animadorPeca.SetBool("EmJogo", true);
		for(int x = 0; x < selecMin.Length; x++){
			Renderer rend = selecMin[x].GetComponent<Renderer>();
			rend.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Return) && encaixa == true)
		{
			if(caminhoFeito == false){
			animadorPeca.SetBool("EmJogo", false);
			animadorPeca.SetBool("LSelec", true);
			Caminho4.SetActive(true);

			Destroy(raiz, 3);
			Destroy(selec, 3);
			Destroy(selMin, 3);
			Destroy(elo.GetComponent<FixedJoint>());
			Destroy(elo.GetComponent<Rigidbody>());
			animadorPeca = null;
		}
		}
		if(animadorPeca == null){
			caminhoFeito = true;
		}

	}
	void OnTriggerStay (Collider Coll)
	{
		if(Coll.gameObject.tag == "Borda")
		{
			for(int x = 0; x < selecMin.Length; x++){
			selecMin[x].SetActive(false);
			encaixa = false;
				Renderer rend = selecMin[x].GetComponent<Renderer>();
				rend.enabled = false;
			}
		}
		if(Coll.gameObject.tag == "Caminhos")
		{
			for(int x = 0; x < selecMin.Length; x++){
			selecMin[x].SetActive(false);
			encaixa = false;
				Renderer rend = selecMin[x].GetComponent<Renderer>();
				rend.enabled = false;
			}
		}
	}
	void OnTriggerExit (Collider Coll){
	
		for(int x = 0; x < selecMin.Length; x++){
			selecMin[x].SetActive(true);
			encaixa = true;
			Renderer rend = selecMin[x].GetComponent<Renderer>();
			rend.enabled = true;
		}
	}
}
