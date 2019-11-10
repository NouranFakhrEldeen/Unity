using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    public PlanetHolder selectedPlanet;
    public Camera cam;
    Vector3 OriginalCameraPosition;

    [Header("Camera Distance")]
    public float CameraDistanceFromPlanet = 20f;

    Vector3 lookDirection;

    [Header("Back Button")]
    public GameObject BackButtonObject;
    private CameraGaze camGaze;

    private void Start()
    {
        if (cam == null)
            cam = Camera.main;

        camGaze = cam.GetComponent<CameraGaze>();
        BackButtonObject.SetActive(false);
        OriginalCameraPosition = cam.transform.position;
    }

    public void MoveCamera()
    {
        if (selectedPlanet.CurrentSelectedPlanet == null)
        {
            //camera is doesn't select anything so we move it to old position
            cam.transform.position = OriginalCameraPosition;
            BackButtonObject.SetActive(false);
        }
        else
        {
            //camera has a planet selected so we move it to new position
            Vector3 newPosition = selectedPlanet.CurrentSelectedPlanet.transform.position;
            newPosition.z -= CameraDistanceFromPlanet;
            cam.transform.localPosition = newPosition;

            lookDirection = (selectedPlanet.CurrentSelectedPlanet.transform.position - cam.transform.position).normalized;
            cam.transform.forward = lookDirection;

            //making the back button
            BackButtonObject.SetActive(true);
            BackButtonObject.transform.position = camGaze.BackButtonPosition.position;
            BackButtonObject.transform.rotation = camGaze.BackButtonPosition.rotation;
        }
    }

}
