using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlesP1 : MonoBehaviour {

	public GameObject deckP1, DecktP1;
	public GameObject CartaSelecionada,tazoSelecionado;
	public GameObject CartaUI;
	public GameObject botaoVerCards;
	public GameObject botaoFecharCards;
	public bool botaoAcionado = false;
	public Sprite imagemCarta;

	public GameObject TazoUI;
	public GameObject botaoVerTazo;
	public GameObject botaoFecharTazo;
	public bool botaoAcionado1 = false;
	public Sprite imagemTazo;


	void Start () {
	
		botaoVerCards.SetActive (true);
		botaoFecharCards.SetActive (false);
		CartaUI.SetActive (false);
		TazoUI.SetActive (false);
		botaoVerTazo.SetActive (true);
		botaoFecharTazo.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		CartaSelecionada = deckP1.GetComponent<CardsDeck>().ObjetoSelecionado;
		tazoSelecionado = DecktP1.GetComponent<GuardianTazo>().TazoSelecionado;

		if(CartaSelecionada == null){ 
			botaoVerCards.GetComponent<Button>().interactable = false;
			}
		else{botaoVerCards.GetComponent<Button>().interactable = true;}


		if(botaoAcionado == true){ 
			CartaSelecionada = deckP1.GetComponent<CardsDeck>().ObjetoSelecionado;
			imagemCarta = CartaSelecionada.GetComponent<Card1>().imagem;
			CartaUI.GetComponent<Image>().sprite = imagemCarta;

		}
		//tazo
		if(tazoSelecionado == null){
			botaoVerTazo.GetComponent<Button>().interactable = false;
		}
		else{botaoVerTazo.GetComponent<Button>().interactable = true;}
		

		if(botaoAcionado1 == true){ 
			tazoSelecionado = DecktP1.GetComponent<GuardianTazo>().TazoSelecionado;
			imagemTazo = tazoSelecionado.GetComponent<Tazos1>().image;
			TazoUI.GetComponent<Image>().sprite = imagemTazo;
			
		}
	}
	public void Visualizar(){

		if(botaoAcionado == false && botaoVerCards){
			botaoAcionado = true;
			botaoVerCards.SetActive (true);
			botaoFecharCards.SetActive (false);
		}
		if(botaoAcionado == true){
			CartaUI.SetActive (true);
			botaoFecharCards.SetActive (true);
			botaoVerCards.SetActive (false);
		}
	}
	public void VisualizarTazo(){
		if(botaoAcionado1 == false && botaoVerTazo){
			botaoAcionado1 = true;
			botaoVerTazo.SetActive (true);
			botaoFecharTazo.SetActive (false);
		}
		if(botaoAcionado1 == true){
			TazoUI.SetActive (true);
			botaoFecharTazo.SetActive (true);
			botaoVerTazo.SetActive (false);
		}

	}
	public void NaoVisualizar(){

		if(botaoFecharCards && botaoAcionado == true){
			botaoAcionado = false;
			botaoFecharCards.SetActive (false);
			botaoVerCards.SetActive (true);
		}
		if(botaoAcionado == false){
			CartaUI.SetActive (false);
			botaoFecharCards.SetActive (false);
			botaoVerCards.SetActive (true);
		}
	}
	public void NaoVisualizarTazo(){
		if(botaoFecharTazo && botaoAcionado1 == true){
			botaoAcionado1 = false;
			botaoFecharTazo.SetActive (false);
			botaoVerTazo.SetActive (true);
		}
		if(botaoAcionado1 == false){
			TazoUI.SetActive (false);
			botaoFecharTazo.SetActive (false);
			botaoVerTazo.SetActive (true);
		}
	}
}
