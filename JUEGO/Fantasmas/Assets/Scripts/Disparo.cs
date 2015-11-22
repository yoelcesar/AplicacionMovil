using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(transform.forward * 1000);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)//creamos un metodo para colisionar o chocar con objetos
	{
		if (other.name == "Suelo") {//si colisionamos con el suelo
			EliminarDisparo ();// desaparecen
		} else if (other.tag == "Enemigo") {//  en caso sontrario si colisionamos  con otra cosa 
			EliminarDisparo ();
			other.SendMessage("Muere", SendMessageOptions.DontRequireReceiver);//buscar el metodo muere
		}
		
	}
	
	void EliminarDisparo()// metodo para eliminar un disparo
	{
		Destroy (gameObject, 1);
		GetComponentInChildren<ParticleSystem> ().enableEmission = false;
	}
}
