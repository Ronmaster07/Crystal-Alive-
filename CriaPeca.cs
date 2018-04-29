using UnityEngine;
using System.Collections;

public class CriaPeca : MonoBehaviour {

	public Vector3 posicao, rotacao;
	public GameObject PecaPrefab;


	void Start () {



	}
	
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)){
			GameObject Peca = (GameObject)Instantiate(PecaPrefab, posicao, Quaternion.Euler (rotacao));
			GameObject Alvo = GameObject.FindWithTag("Respawn");
			Peca.GetComponent<FixedJoint>().connectedBody = Alvo.GetComponent<Rigidbody>();
			Alvo.GetComponent<AlcaP1>().PodeMexer = true;
		}

	}
}
