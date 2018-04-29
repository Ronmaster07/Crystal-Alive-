using UnityEngine;
using System.Collections;

public class Tazos1 : MonoBehaviour {

	public GameObject pontSlot;
	public GameObject destino, circuloDeSelecao, Emissor, emitBase;
	public Transform meshPosic, emitePosic;
	public bool destina = false;
	public bool Reservado = false;
	public bool SelecAtiva = false;
	public Sprite image;

	void Start () {
		destina = true;
		pontSlot = GameObject.FindWithTag("FreeSlot");
		destino = pontSlot.GetComponent<PosiSlots>().Slot;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Reservado == false){
			transform.position = Vector3.Lerp (transform.position, pontSlot.transform.position, 7 * Time.deltaTime);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(0.0f,180,0), 7 * Time.deltaTime);
		}
		if(destina == true){
		StartCoroutine("Completar");
		}
		if(destina == false){
			transform.position = destino.transform.position;
			transform.rotation = destino.transform.rotation;
			StopCoroutine("Completar");
		}

		if(SelecAtiva == true){
			circuloDeSelecao.SetActive (true);
		} 
		float x = meshPosic.localPosition.x;
		float y = meshPosic.localPosition.y;
		circuloDeSelecao.transform.position = meshPosic.position;
		emitePosic.localPosition = new Vector3(x,y, 0.02f);
		Emissor.transform.localPosition = emitePosic.localPosition;
	}
	public IEnumerator Completar(){
		
		if(destina == true){
			
			yield return new WaitForSeconds(0.3f);
			destina = false;

		}
		
	}

}
