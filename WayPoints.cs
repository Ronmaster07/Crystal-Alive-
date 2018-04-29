using UnityEngine;
using System.Collections;

public class WayPoints : MonoBehaviour {

	public GameObject[] Vizinhos;
	public Transform[] AoVizinho; 


	void Start () {

		Renderer rend = GetComponent<Renderer>();
		rend.enabled = false;
	}
	

	void Update () {
	
	}
}
