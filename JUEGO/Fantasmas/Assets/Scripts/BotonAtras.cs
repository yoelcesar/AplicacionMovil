using UnityEngine;
using System.Collections;

public class BotonAtras : MonoBehaviour {
	
	public enum Acciones { Salir, CargarEscena }
	
	public Acciones accion;
	public string nombreEscena;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			switch(accion){
			case Acciones.Salir:
				Debug.Log("Saliendo...");
				Application.Quit();
				break;
			case Acciones.CargarEscena:
				Debug.Log("Cargando escena: "+nombreEscena);
				Application.LoadLevel(nombreEscena);
				break;
			}
		}
	}
}
