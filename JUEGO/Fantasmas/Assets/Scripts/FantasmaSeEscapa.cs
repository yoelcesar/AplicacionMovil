using UnityEngine;
using System.Collections;

public class FantasmaSeEscapa : MonoBehaviour {
	
	public float radioAlcanzadoParaEscaparse = 12f;
	
	public AudioClip risa;
	
	private Rotar rotar;
	private EstadoJuego estadoJuego;
	
	private bool seHaEscapado = false;

	// Use this for initialization
	void Start () {
		rotar = GetComponent<Rotar>();
		estadoJuego = ControladorDelJuego.ObtenerComponente<EstadoJuego>("ControladorDelJuego");
	}
	
	// Update is called once per frame
	void Update () {
		if(seHaEscapado) return;
		if(rotar.radioActual >= radioAlcanzadoParaEscaparse)
		{
			FantasmaSeAcabaDeEscapar();
			seHaEscapado = true;
			
			SphereCollider collider = GetComponentInChildren<SphereCollider>();
			collider.enabled = false;
		}
	}
	
	private void FantasmaSeAcabaDeEscapar()
	{
		//Destroy(gameObject);
		estadoJuego.PerderUnaVida();
		// Iniciar animación de desaparecer
		
		Animation animation = GetComponentInChildren<Animation>();
		animation["Desaparecer"].layer = 1;
		animation.Play("Desaparecer");

		AudioSource.PlayClipAtPoint(risa, transform.position);
	}
}
