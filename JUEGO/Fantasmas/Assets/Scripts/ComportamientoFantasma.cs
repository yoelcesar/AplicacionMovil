using UnityEngine;
using System.Collections;

public class ComportamientoFantasma : MonoBehaviour {
	
	public Transform explosionPrefab;
	
	private EstadoJuego estadoJuego;

	// Use this for initialization
	void Start () {
		estadoJuego = ControladorDelJuego.ObtenerComponente<EstadoJuego>("ControladorDelJuego");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void Muere ()
	{
		Rotar rotar = transform.parent.GetComponent<Rotar>();
		FantasmaSeEscapa fantasmaSeEscapa = transform.parent.GetComponent<FantasmaSeEscapa>();
		int puntuacion = (int)((100 * rotar.radioActual) / fantasmaSeEscapa.radioAlcanzadoParaEscaparse);
		estadoJuego.IncrementarPuntuacion(puntuacion);
		
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy (gameObject.transform.parent.gameObject);//desaparace el fantasma
	}
	
	public void FantasmaDesaparecido()
	{
		Destroy(gameObject.transform.parent.gameObject);
	}
	
}
