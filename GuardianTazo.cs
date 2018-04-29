using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuardianTazo : MonoBehaviour {

	public List<GameObject> deckTazos = new List<GameObject>();
	
	public List<GameObject> tazos = new List<GameObject>();
	public List<GameObject> lancados = new List<GameObject>();
	private int tazosSacado = 0;
	private bool showReset = false;
	public GameObject TazoSelecionado;
	public GameObject ReservaSelect;
	public Camera kamera;
	public GameObject Ps1, Ps2, Ps3;
	public bool U1, U2, U3, SaqueTazo;

	public float relogio;
	public float tempoLimite = 0.7f;
	public int SacandoTazo = 0;
	public bool podeSacarT, TurnoPlayer1;

	void Start () {
	
		ResetTazos();
		U1 = false;
		U2 = false;
		U3 = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(SacandoTazo > 0){
			relogio += Time.deltaTime;
			
			if(relogio >= tempoLimite){
				podeSacarT = true;
			}
			
		}

		SelectTazo ();
		SlotReserva ();
		U1 = Ps1.GetComponent<PosiSlots>().activo;
		U2 = Ps2.GetComponent<PosiSlots>().activo;
		U3 = Ps3.GetComponent<PosiSlots>().activo;
		if(U1== false && U2== false && U3== false || U1== true && U2== true && U3== false 
		   || U1== true && U2== false && U3== false || U1== false && U2== true && U3== true 
		   || U1== false && U2== false && U3== true || U1== false && U2== true && U3== false
		   || U1== true && U2== false && U3== true){
			SaqueTazo = true;
		}
		if(U1== true && U2== true && U3== true){
			SaqueTazo = false;
		}

		if(SaqueTazo == true){

		if (!showReset) {
			
			if(Input.GetKeyDown(KeyCode.T) || podeSacarT == true)  
			{
				MoveOrdenaTazo();
				SacandoTazo = SacandoTazo - 1;
				podeSacarT = false;
				relogio = 0;
			}
		  }
		}
		else {
			// Reset button
			if(Input.GetKeyDown(KeyCode.R))  
			{
				ResetTazos();
			}
		}
	}
	public void SelectTazo ()
	{
		if(Input.GetMouseButtonDown (1)){
			
			RaycastHit hit;
			if(Physics.Raycast(kamera.ScreenPointToRay(Input.mousePosition),out hit))
			{	
				if (hit.collider.gameObject.tag == "Tazos" && Input.GetMouseButtonDown (1)) {
					
					TazoSelecionado = hit.transform.gameObject;
					lancados.Remove(TazoSelecionado);
					Debug.Log(TazoSelecionado);
				}
			}
		}
	}
	public void SlotReserva () 
	{
		if(Input.GetMouseButtonDown (0)){
			RaycastHit hit;
			if(Physics.Raycast(kamera.ScreenPointToRay(Input.mousePosition),out hit)) {
				if (TazoSelecionado == null && Input.GetMouseButtonDown (0) && hit.collider.gameObject.tag == "Reservar1"){
					
					Debug.Log("Selecione Tazo");
				}
				else if (hit.collider.gameObject.tag == "Reservar1" && Input.GetMouseButtonDown (0)) {
					ReservaSelect =  hit.transform.gameObject;
					TazoSelecionado.GetComponent<Tazos1>().Reservado = true;
					TazoSelecionado.transform.position = ReservaSelect.transform.position;
					TazoSelecionado.transform.rotation = ReservaSelect.transform.rotation;
					Debug.Log(ReservaSelect);
				}
			}
		}
	}
	GameObject SacaTazo (){
		
		if(tazos.Count == 0)
		{
			showReset = true;
			return null;
		}
		
		int tazo = Random.Range(0, tazos.Count - 1);
		GameObject go = GameObject.Instantiate(tazos[tazo]) as GameObject;
		tazos.RemoveAt(tazo);
		
		if(tazos.Count == 0) {
			showReset = true;
		}
		
		return go;
	}
	void MoveOrdenaTazo()
	{
		GameObject newTazo = SacaTazo();
		// check card is null or not
		if (newTazo == null) {
			Debug.Log("Out of Tazo");
			showReset = true;
			return;
		} 
		// place card 1/4 up on all axis from last
		lancados.Add(newTazo); // add card to hand
		tazosSacado ++;
		
	}
	void ResetTazos()
	{
		tazosSacado = 0;
		for (int i = 0; i < lancados.Count; i++) {
			Destroy(lancados[i]);
		}
		
		lancados.Clear();
		tazos.Clear();
		tazos.AddRange(deckTazos);
		showReset = false;
	}

}
