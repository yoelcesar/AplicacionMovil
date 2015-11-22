using UnityEngine;
using System.Collections;

public class GeneradorDeFantasmas : MonoBehaviour {// creamos una clase para generar fantasmas
	
	public Transform fantasmaPrefab;
	public Transform objetoEnElQueGirar;
	public Transform padreDeNuestrosFantasmas;//para k no se desaparescan los fantasmas
	
	public float esperaAlPrimerFantasma = 3f;
	public float tiempoEntreFantasmas = 8f;//cada 8 segundos se generara un fantamasma nuevo
	
	private float horaDelSiguienteFantasma;
	
	public float tiempoCumplido = 300f; // 5 minutos (300s)
	public float velocidadRotacionInicial = 75f; // 0 a los segundos
	public float velocidadRotacionTiempoCumplido = 200; // a los 300s
	public float incrementoRadioInicial = 0.5f; // a los 0 segundos
	public float incrementoRadioTiempoCumplido = 0.75f; // a los 300s
	
	private float diferenciaVelocidadRotacion, diferenciaIncrementoRadio;

	// Use this for initialization
	void Start () {
		horaDelSiguienteFantasma = Time.time + esperaAlPrimerFantasma;
		
		diferenciaVelocidadRotacion = velocidadRotacionTiempoCumplido - velocidadRotacionInicial;
		diferenciaIncrementoRadio = incrementoRadioTiempoCumplido - incrementoRadioInicial;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.time >= horaDelSiguienteFantasma){     
			horaDelSiguienteFantasma = Time.time + tiempoEntreFantasmas;
			CrearFantasma(padreDeNuestrosFantasmas, objetoEnElQueGirar);
		}
	}
	
	void CrearFantasma(Transform padre, Transform centro){
		Transform fantasmasTransform = Instantiate(fantasmaPrefab, centro.transform.position, centro.transform.rotation) as Transform;
		fantasmasTransform.parent = padre;
		Rotar rotar = fantasmasTransform.GetComponent<Rotar>();
		rotar.objetoCentroDeRotacion = centro;
		
		float valorVelocidadRotacion = ((diferenciaVelocidadRotacion * Time.timeSinceLevelLoad) / tiempoCumplido) + velocidadRotacionInicial;
		float valorIncrementoRadio = ((diferenciaIncrementoRadio * Time.timeSinceLevelLoad) / tiempoCumplido) + incrementoRadioInicial;
		rotar.rotacionPorSegundo = valorVelocidadRotacion;
		rotar.incrementoRadioPorSegundo = valorIncrementoRadio;
		
		Animation animation = fantasmasTransform.GetComponentInChildren<Animation>();
		animation["Aparecer"].layer = 1;
		animation.Play("Aparecer");
	}
}
