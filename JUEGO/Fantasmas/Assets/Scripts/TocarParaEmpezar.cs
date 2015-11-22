using UnityEngine;
using System.Collections;

public class TocarParaEmpezar : MonoBehaviour {
	
	public TextMesh tocaParaEmpezar;
	public string nombreEscenaACargar;
	public int segundosDeEspera = 3;
	
	private float momentoParaAceptarToquePantalla;
	
	void Start(){
		momentoParaAceptarToquePantalla = Time.time + segundosDeEspera;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > momentoParaAceptarToquePantalla)
		{
			tocaParaEmpezar.renderer.enabled = true;
		}
		if (Time.time > momentoParaAceptarToquePantalla && (Input.GetButtonDown ("Fire1") || Input.touchCount > 0))
		{
			Application.LoadLevel(nombreEscenaACargar);
		}
	}
}
