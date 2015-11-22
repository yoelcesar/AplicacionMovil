/*==============================================================================
            Copyright (c) 2010-2012 QUALCOMM Austria Research Center GmbH.
            All Rights Reserved.
            Qualcomm Confidential and Proprietary
==============================================================================*/
using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES
 
	private TrackableBehaviour mTrackableBehaviour;
	private EventosMarcador eventosMarcador;
    
    #endregion // PRIVATE_MEMBER_VARIABLES



    #region UNTIY_MONOBEHAVIOUR_METHODS
    
	void Start ()
	{
		eventosMarcador = ControladorDelJuego.ObtenerComponente<EventosMarcador>("ControladorDelJuego");
		
		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}

		OnTrackingLost ();
	}

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS

	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged (
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED) {
			OnTrackingFound ();
			eventosMarcador.MarcadorEncontrado ();
		} else {
			OnTrackingLost ();
			eventosMarcador.MarcadorPerdido ();
		}
	}

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS


	private void OnTrackingFound ()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer> ();
		Collider[] colliderComponents = GetComponentsInChildren<Collider> ();

		// Enable rendering:
		foreach (Renderer component in rendererComponents) {
			component.enabled = true;
		}

		// Enable colliders:
		foreach (Collider component in colliderComponents) {
			component.enabled = true;
		}

		Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " found");
	}

	private void OnTrackingLost ()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer> ();
		Collider[] colliderComponents = GetComponentsInChildren<Collider> ();

		// Disable rendering:
		foreach (Renderer component in rendererComponents) {
			component.enabled = false;
		}

		// Disable colliders:
		foreach (Collider component in colliderComponents) {
			component.enabled = false;
		}

		Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " lost");
	}

    #endregion // PRIVATE_METHODS
}
