using UnityEngine;
using System.Collections;

public class Referencial : MonoBehaviour {
	
	public GameObject AlcaPeca;
	public bool MexerAlca;
	public Vector3 posicao, rotacao;
	public int indiceInicial = 0;
	public Transform[] Referentes;

	
	int indiceAtual;
	
	void Start () {

		indiceAtual = indiceInicial;
		indiceAtual = Mathf.Clamp (indiceAtual, 8, Referentes.Length-1);
		AlcaPeca.transform.position = Referentes [indiceAtual].position;
	}
	
	void Update () {

		MexerAlca = AlcaPeca.GetComponent<AlcaP1>().PodeMexer;

		if(MexerAlca == true){

		if(Input.GetKeyDown (KeyCode.RightArrow)){

			indiceAtual++;
			indiceAtual = Mathf.Clamp (indiceAtual, 0, Referentes.Length-1);
			AlcaPeca.transform.position = Referentes [indiceAtual].position;
			print (Referentes [indiceAtual]);
		}

		if(Input.GetKeyDown (KeyCode.LeftArrow)){

			indiceAtual--;
			indiceAtual = Mathf.Clamp (indiceAtual, 0, Referentes.Length-1);
			AlcaPeca.transform.position = Referentes [indiceAtual].position;
			print (Referentes [indiceAtual]);
		}
		if(Input.GetKeyDown (KeyCode.UpArrow)){
			
			indiceAtual = indiceAtual + 14;
			indiceAtual = Mathf.Clamp (indiceAtual, 0, Referentes.Length-1);
			AlcaPeca.transform.position = Referentes [indiceAtual].position;
			print (Referentes [indiceAtual]);
		}
		if(Input.GetKeyDown (KeyCode.DownArrow)){
			
			indiceAtual = indiceAtual - 14;
			indiceAtual = Mathf.Clamp (indiceAtual, 0, Referentes.Length-1);
			AlcaPeca.transform.position = Referentes [indiceAtual].position;
			print (Referentes [indiceAtual]);
		}
	  }
	}
}