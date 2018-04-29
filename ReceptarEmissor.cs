using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptarEmissor : MonoBehaviour {

	public GameObject controlTurn,controlEmit;  // recebe o objeto emit do tazo ativado atraves do objeto canvas
	public bool acao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(acao == true){
			controlEmit = controlTurn.GetComponent<Controladordeturno>().efeitoTazo;
			controlEmit.GetComponent<EfeitoEmissores>().alvoCaminho = true;
			acao = false;
		}
	}
}
