using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public GameObject camara;
	public GUIText mensajePuntos;
	private EstadoJuego estadoJuego;
	
	public float tiempoEsperaPantallaGameOver = 3f;
	private float tiempoParaVolverAlMenu;
	
	public string nombreEscenaPortada;

	// Use this for initialization
	void Start () {
		estadoJuego = GetComponent<EstadoJuego>();
	}
	
	// Update is called once per frame
	void Update () {
		if(estadoJuego.gameOver
			&& (Input.GetButtonDown("Fire1") || Input.touchCount>0)
			&& Time.realtimeSinceStartup > tiempoParaVolverAlMenu)
		{
			Time.timeScale = 1f;
			Application.LoadLevel(nombreEscenaPortada);
		}
	}
	
	public void PartidaTerminada()
	{
		tiempoParaVolverAlMenu = Time.realtimeSinceStartup + tiempoEsperaPantallaGameOver;
		estadoJuego.gameOver = true;
		Time.timeScale = 0f;
		
		camara.SetActiveRecursively(true);
		
		if(estadoJuego.puntuacion > estadoJuego.highscore){
			// Record superado!
			estadoJuego.highscore = estadoJuego.puntuacion;
			// Guardamos
			PlayerPrefs.SetInt("highscore", estadoJuego.puntuacion);
			mensajePuntos.guiText.text = "Nuevo Record! " + estadoJuego.puntuacion.ToString("D5");
		}else{
			// Record NO superado. :(
			mensajePuntos.guiText.text = estadoJuego.puntuacion.ToString("D5");
		}
	}
}
