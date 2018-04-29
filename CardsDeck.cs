using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardsDeck : MonoBehaviour {

	public List<GameObject> deck = new List<GameObject>();

	public List<GameObject> cards = new List<GameObject>();
	public List<GameObject> mao = new List<GameObject>();
	private int cardsSacado = 0;
	private bool showReset = false;

	public GameObject SlotSelect;
	public GameObject ObjetoSelecionado;
	public bool selecionar = false;
	public bool turnoPlay = false;
	public Camera kamera;

	public float relogio;
	public float tempoLimite = 0.8f;
	public int CartaSacada = 0;
	public bool podeSacar, espera;

	void ResetDeck()
	{
		cardsSacado = 0;
		for (int i = 0; i < mao.Count; i++) {
			Destroy(mao[i]);
		}

		mao.Clear();
		cards.Clear();
		cards.AddRange(deck);
		showReset = false;
	}

	GameObject SacaCard (){

		if(cards.Count == 0)
		{
			showReset = true;
			return null;
		}

		int card = Random.Range(0, cards.Count - 1);
		GameObject go = GameObject.Instantiate(cards[card]) as GameObject;
		cards.RemoveAt(card);

		if(cards.Count == 0) {
			showReset = true;
		}
		
		return go;
	}

	void Start () {
	
		ResetDeck();
	}

	// Update is called once per frame
	void Update () {

		SlotPlayer ();
		SelectCarta ();
	
		if(CartaSacada > 0){
			relogio += Time.deltaTime;

			if(relogio >= tempoLimite){
				podeSacar = true;
			}
		
		}
		if (!showReset) {

			if(Input.GetKeyDown(KeyCode.PageUp) || podeSacar == true)  
			{
				MoveOrdenaCard();
				CartaSacada = CartaSacada - 1;
				podeSacar = false;
				relogio = 0;
			}
		}
		else {
			// Reset button
			if(Input.GetKeyDown(KeyCode.Home))  
			{
				ResetDeck();
			}
		}
		// GameOver button
		if(Input.GetKeyDown(KeyCode.PageDown))  
		{
			GameOver();
		}
	}

	void GameOver()
	{
		cardsSacado = 0;
		for (int m = 0; m < mao.Count; m++) {
			Destroy(mao[m]);

		}

		mao.Clear();
		cards.Clear();
		cards.AddRange(deck);

	}

	public void SelectCarta ()
	{
		if(Input.GetMouseButtonDown (1)){

		RaycastHit hit;
		if(Physics.Raycast(kamera.ScreenPointToRay(Input.mousePosition),out hit, LayerMask.GetMask("Carta")))
		{	
				if (hit.collider.gameObject.tag == "Cartas" && Input.GetMouseButtonDown (1)) {
				
					ObjetoSelecionado = hit.transform.gameObject;
					mao.Remove(ObjetoSelecionado);

					Debug.Log(ObjetoSelecionado);
					selecionar = true;
					}
			}
			if(selecionar == true && Input.GetMouseButtonDown (0)){
				selecionar = false;
				return;
			}
		}
	}
	public void SlotPlayer () 
	{
		if(Input.GetMouseButtonDown (0)){
			RaycastHit hit;
			if(Physics.Raycast(kamera.ScreenPointToRay(Input.mousePosition),out hit)) {
				if (hit.collider.gameObject.tag == "Slots" && Input.GetMouseButtonDown (0) && selecionar == true) {
					SlotSelect =  hit.transform.gameObject;
					SlotSelect.GetComponent<SlotsP1>().SlotSelecionado = true;
					selecionar = false;
					ObjetoSelecionado.GetComponent<Card1>().Ativado = true;
					ObjetoSelecionado.transform.position = SlotSelect.transform.position;
					ObjetoSelecionado.transform.rotation = SlotSelect.transform.rotation;
				}
			}
		}
	}

	void MoveOrdenaCard()
	{
		GameObject newCard = SacaCard();
		// check card is null or not
		if (newCard == null) {
			Debug.Log("Out of Cards");
			showReset = true;
			return;
		} 
		// place card 1/4 up on all axis from last
		mao.Add(newCard); // add card to hand
		cardsSacado ++;

	}

}
