using UnityEngine;
using System.Collections;

public class PosiSlots : MonoBehaviour {

	public Transform PosiTazo;
	public GameObject Slot;
	public bool activo = false;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Raycastear();

	}
	void Raycastear(){
		
		RaycastHit hit;
		
		if (Physics.Raycast(PosiTazo.position, -(transform.up), out hit, 7)){
			Debug.DrawLine(PosiTazo.position, hit.point, Color.yellow);
			if (hit.collider.gameObject.tag == "Tazos"){
				PosiTazo.tag = "Ocupado";
				activo = true;
			}
			else{
				PosiTazo.tag = "FreeSlot";
				activo = false;
			}
		}
	}
}
