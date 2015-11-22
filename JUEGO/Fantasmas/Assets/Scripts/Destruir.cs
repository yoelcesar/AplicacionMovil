using UnityEngine;
using System.Collections;

public class Destruir : MonoBehaviour {
	
	public float tiempoDeVida = 2f;//creamos una funcion  para destreuir durante dos segundos los diparosd

	// Use this for initialization
	void Start () {
		Destroy(gameObject, tiempoDeVida);//se destruyen en dos segundos
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
