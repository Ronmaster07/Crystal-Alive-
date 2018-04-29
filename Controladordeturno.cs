using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controladordeturno : MonoBehaviour {

	public GameObject NoTurnoPlayer, SlotsCards, ReservaTazos;
	public Camera kamera;
	//public Sprite Inicio, SeuTurno, Puxar, Escolher, Resgate, Jogar, Ativar, Atacar, Defender, TurnoDoOponente;
	public Button Regatar, EmJogo, Ativando, Ataque, Defende, Fim, EquiparTazo, Materialize;

	public Animator anim;
	public bool estatico , inicie, meuTurn, podePuxar, puxe, Play;
	public GameObject SistemTurn;
	public Text texto;
	public Color corPadrao, corFim;
	public float cronometro1, cronometro2, cronometro3;
	public int Tlimite = 3;
	public bool c1, c2, c3;
	public bool primeiraVez, vezNormal;
	public int controlCard, controlTazo;
	public GameObject cartasPlayer, tazosPlayer, ativaTazo;
	public bool ativar = false;
	public GameObject efeitoTazo, receptorAlvo;
	int emSelecao = 0;
	bool esperAlvo = false;
	bool Camin, Mov, Energ, Atk, Def, Rec;

	// Use this for initialization
	void Start () {

		primeiraVez = true;
		inicie = true;
		if(inicie == true){
			anim.SetTrigger("inicia");
			texto.GetComponent<Text>().text = "Inicio";
			texto.GetComponent<Text>().color = corPadrao;
			anim.SetTrigger("espera");
			c1 = true;

		}
	
	}
	IEnumerator Espera(){
		
		yield return new WaitForSeconds (1.0f);
		inicie = false;

	
	}
	
	// Update is called once per frame
	void Update () {

		if(c1 == true){
			cronometro1 += Time.deltaTime;
			if(cronometro1 > Tlimite){
				c1 = false;
				cronometro1 = 0;
				meuTurn = true;
			}
		}


	
		if(meuTurn == true){
			anim.SetTrigger("seuTurno");
			texto.GetComponent<Text>().text = "Sua Vez";
			texto.GetComponent<Text>().color = corPadrao;
			anim.SetTrigger("espera");
			meuTurn = false;
			c2 = true;
		}

		if(c2 == true){
			cronometro2 += Time.deltaTime;
			if(cronometro2 > Tlimite){
				c2 = false;
				cronometro2 = 0;
				Play = true;
			}
		}
		if(Play == true){
			anim.SetTrigger("Play");
			texto.GetComponent<Text>().text = "Jogue";
			texto.GetComponent<Text>().color = corPadrao;
			anim.SetTrigger("espera");
			Play = false;
			podePuxar = true;

			Regatar.GetComponent<Button>().interactable = true;
			EmJogo.GetComponent<Button>().interactable = true;
			Ativando.GetComponent<Button>().interactable = true;
			Ataque.GetComponent<Button>().interactable = true;
			Defende.GetComponent<Button>().interactable = true;
			Fim.GetComponent<Button>().interactable = true;

		}
				if(primeiraVez == true){
					controlCard = 5;
					controlTazo = 3;
				}
				if(vezNormal == true){
					controlCard = 1;
					controlTazo = 3;
				}
				if(podePuxar == true){
				cartasPlayer.GetComponent<CardsDeck>().CartaSacada = controlCard;
				tazosPlayer.GetComponent<GuardianTazo>().SacandoTazo = controlTazo;
				podePuxar = false;
				}

		//ativarSelecao
		if(ativar == true){
			if(Input.GetMouseButtonDown (0)){
				RaycastHit hit;
				
					if(Physics.Raycast(kamera.ScreenPointToRay(Input.mousePosition),out hit)) {
					if(hit.collider.gameObject.tag == "Tazos" && Input.GetMouseButtonDown (0) && emSelecao == 0 && esperAlvo == false){
							ativaTazo = hit.transform.gameObject;
							ativaTazo.GetComponent<Tazos1>().circuloDeSelecao.SetActive (true);
							//ativaTazo.GetComponent<Tazos1>().Emissor.SetActive (true);
							efeitoTazo = ativaTazo.GetComponent<Tazos1>().emitBase;
							efeitoTazo.GetComponent<EfeitoEmissores>().reinstancia = true;
							Debug.Log("AtivaTazo");
							emSelecao = emSelecao+2;
							Debug.Log(emSelecao);
							esperAlvo = true;

							Camin = efeitoTazo.GetComponent<EfeitoEmissores>().Caminho;
						}//se for tipo caminho
						if(Input.GetMouseButtonDown (0) && hit.collider.gameObject.tag == "Degrau"){
							receptorAlvo = hit.transform.gameObject;
							if(Camin == true){
							//emSelecao = emSelecao -1;				
							receptorAlvo.GetComponent<ReceptarEmissor>().acao = true;
							Debug.Log( "Degrau");
							// faz var do receptor ficar true
						}}
					if(Input.GetMouseButtonDown (0) && hit.collider.gameObject.tag == "Tazos"  && esperAlvo == true){
						int x = emSelecao;
						Debug.Log("Desativa Seleçao");
						Debug.Log(x);
						emSelecao = emSelecao -1;
						
						
				
					}
						if(emSelecao == 0){
							ativaTazo.GetComponent<Tazos1>().circuloDeSelecao.SetActive (false);
							//ativaTazo.GetComponent<Tazos1>().Emissor.SetActive (false);
							efeitoTazo = ativaTazo.GetComponent<Tazos1>().emitBase;
							efeitoTazo.GetComponent<EfeitoEmissores>().consome = true;
							esperAlvo = false;
						}
				}
			}
		}
	}
	public void PrepararReservar(){

		SlotsCards.SetActive (true);
		ReservaTazos.SetActive (true);

	}
	public void FinalTurno (){
		
		anim.SetTrigger("finaliza");
		texto.GetComponent<Text>().color = corFim;
		texto.GetComponent<Text>().text = "Vez do Oponente";
		anim.SetTrigger("espera");
		meuTurn = false;
		vezNormal = true;
		SlotsCards.SetActive (false);
		ReservaTazos.SetActive (false);

		Regatar.GetComponent<Button>().interactable = false;
		EmJogo.GetComponent<Button>().interactable = false;
		Ativando.GetComponent<Button>().interactable = false;
		Ataque.GetComponent<Button>().interactable = false;
		Defende.GetComponent<Button>().interactable = false;
		Fim.GetComponent<Button>().interactable = false;
	}
	public void Ativacoes(){

		ativar = true;

	}
	public void EquiparEsteTazo(){


	}
}
