using UnityEngine;
using System.Collections;

public class EventosMarcador : MonoBehaviour {
	
	public GUIText notificacion;
	
	private bool detener;
	
	private EstadoJuego estadoJuego;
	
	// Use this for initialization
	void Start () {
		estadoJuego = GetComponent<EstadoJuego>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Hack para corregir el problema con timeScale en Android (Unity 3.5)
		if (detener && Time.frameCount >= 2) {
			Time.timeScale = 0f;
		}
		
		if (Input.GetKeyDown (KeyCode.Q)) { 
			MarcadorPerdido ();
		} else if (Input.GetKeyDown (KeyCode.W)) {
			MarcadorEncontrado ();	
		}
	}
	
	public void MarcadorEncontrado ()// cuando encuentra una objeto
	{
		if(estadoJuego.gameOver) return;
		if (notificacion != null) {
			notificacion.enabled = false;
		}
		// Reanudar juego
		Time.timeScale = 1f;
		detener = false;
		//Debug.Log("ENCONTRADO");
	}
	
	public void MarcadorPerdido ()
	{
		if(estadoJuego.gameOver) return;
		if (notificacion != null) {
			notificacion.enabled = true;
		}
		// Pausar Juego
		detener = true;
		//Debug.Log ("PERDIDO");
	}
	
}
