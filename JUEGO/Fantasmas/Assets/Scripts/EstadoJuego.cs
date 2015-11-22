using UnityEngine;
using System.Collections;

public class EstadoJuego : MonoBehaviour {
	
	public GUITexture guiVidas;
	public Texture[] vidasImagenes;
	
	public int vidasActuales = 0;// declaramos vidas actuales
	public int vidasIniciales = 3;// declaramos vidas dadas
	
	public GUIText guiPuntuacion;
	
	public int puntuacion = 0;
	
	internal bool gameOver = false;
	internal int highscore = 0;

	// Use this for initialization
	void Start () {
		highscore = PlayerPrefs.GetInt("highscore", 0);
		
		vidasActuales = vidasIniciales;
		guiVidas.guiTexture.texture = vidasImagenes[vidasActuales];
		
		puntuacion = 0;
		ActualizarPuntuacion();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//  funcion para perder una vida
	public void PerderUnaVida()
	{
		if(vidasActuales>0)
		{
			vidasActuales--; // vidasActuales = vidasActuales -1; // vidasActuales -= 1;
		}
		
		if(vidasActuales < vidasImagenes.Length)
		{
			guiVidas.guiTexture.texture = vidasImagenes[vidasActuales];
		}
		
		if(vidasActuales <= 0)
		{
			SendMessage("PartidaTerminada",SendMessageOptions.DontRequireReceiver);
		}
	}
	
	public void IncrementarPuntuacion(int valorAIncrementar)
	{
		puntuacion += valorAIncrementar;
		ActualizarPuntuacion();
	}
	
	public void ActualizarPuntuacion()
	{
		guiPuntuacion.guiText.text = puntuacion.ToString("D5");
	}
}
