using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftGrabRay;
    public GameObject rightGrabRay;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor leftDirectGrab;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor rightDirectGrab;

    // Update is called once per frame
    void Update()
    {
        leftGrabRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0);
        rightGrabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
    }
}
