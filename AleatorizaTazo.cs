using UnityEngine;
using System.Collections;

public class AleatorizaTazo : MonoBehaviour {

	private Animator aleator;
	public Animator TazoR;
	public Animator TazoC;
	public Animator TazoL;
	public int saque = 3;
	private bool aberto = false;
	public GameObject decktazo;
	public bool SacaTazo = false;

	void Start () {
	
		aleator = GetComponent<Animator> ();

	}
	
	// Ao iniciar o turno automaticamente ativa a condicao e o aleator
	void Update () {
		TurnoTazo ();
		SacaTazo = decktazo.GetComponent<GuardianTazo>().SaqueTazo;

		if(Input.GetKeyDown ("1"))
		{
			aleator.SetInteger("Condicao", 1);
			aberto = true;
		}
		if(Input.GetKeyDown ("2"))
		{
			aleator.SetInteger("Condicao", 2);
			aberto = false;
		}
		if(Input.GetKeyDown ("3"))
		{
			aleator.SetInteger("Condicao", 3);
		}
		if(Input.GetKeyDown ("4"))
		{
			aleator.SetInteger("Condicao", 4);
		}




	}

	void TurnoTazo (){

		if(saque == 3 && Input.GetKeyDown(KeyCode.Space) && aberto == true)
		{

				TazoL.SetInteger("L", 3);

				TazoC.SetInteger("C", 2);

				TazoR.SetInteger("R", 1);

		}
		if(saque == 2 && Input.GetKeyDown(KeyCode.Space) && aberto == true)
		{

				TazoC.SetInteger("C", 2);

				TazoR.SetInteger("R", 1);

		}
		if(saque == 1 && Input.GetKeyDown(KeyCode.Space) && aberto == true)
		{

				TazoR.SetInteger("R", 1);

		}

	}

}
