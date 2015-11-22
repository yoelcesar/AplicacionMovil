using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour {
	
	public Transform disparoPrefab;//creamos un ogjeto
	public float tiempoEntreDisparos = 0.5f;//tiempo entre disparos
	
	private float siguienteDisparo = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Input.GetButtonDown ("Fire1") || Input.touchCount > 0) && Time.time > siguienteDisparo) { //para disparar cada vez  que se toque la pantalla
			siguienteDisparo = Time.time + tiempoEntreDisparos;//siguientes disparos
			Instantiate (disparoPrefab, transform.position, transform.rotation);
		}
	}
}
