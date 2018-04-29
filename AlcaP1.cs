using UnityEngine;
using System.Collections;

public class AlcaP1 : MonoBehaviour {

	public GameObject PosicaoInicial;
	public bool PodeMexer = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if(PodeMexer == false){

			transform.position = PosicaoInicial.transform.position;
		}

		if(Input.GetKeyDown(KeyCode.Return)){
			PodeMexer = false;
		}


	}
}
