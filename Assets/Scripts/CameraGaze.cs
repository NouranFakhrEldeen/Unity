using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraGaze : MonoBehaviour
{
    Camera cam;

    [Header("Gaze")]
    public float gazeMaxTime = 2f;
    public float rayLength;
    public LayerMask mask;
    private float timer;

    public float cooldownOfGaze = 2.5f;
    private float cooldownTimer;
    private bool cooldownActive;

    [Header("Events")]
    public GameEvent pauseRotation;
    //public GameEvent resumeRotation;

    [Header("UI")]
    public Image gazeCounter;

    [Header("Gazed Object")]
    public PlanetHolder currentSelectedPlanet;
    public Transform BackButtonPosition;
    //public Transform UIFloatingPosition;

    private void Start()
    {
        cam = GetComponent<Camera>();
        timer = 0;
        cooldownTimer = 0;
        cooldownActive = false;
    }

    private void OnDisable()
    {
        currentSelectedPlanet.CurrentSelectedPlanet = null;
    }

    private void FixedUpdate()
    {
        if (!cooldownActive)
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, mask))
            {
                var gazeObject = hit.collider.gameObject.GetComponent<IGazeInput>();
                if (gazeObject != null)
                {
                    timer += Time.deltaTime;
                    gazeCounter.fillAmount = timer / gazeMaxTime;

                    if (timer >= gazeMaxTime)
                    {
                        timer = 0;
                        pauseRotation.Raise();

                        if(currentSelectedPlanet.CurrentSelectedPlanet != null)
                        {
                            currentSelectedPlanet.CurrentSelectedPlanet.GetComponent<Planet>().ResetObject();
                        }
                        if(hit.collider.gameObject.GetComponent<PhysicalBackButton>())
                        {
                            currentSelectedPlanet.CurrentSelectedPlanet = null;
                        }
                        else
                        {
                            currentSelectedPlanet.CurrentSelectedPlanet = hit.collider.gameObject;
                        }


                        cooldownActive = true;
                        gazeCounter.fillAmount = 0;

                        // call gaze
                        gazeObject.OnGaze();
                    }

                }
            }
            else
            {
                timer = 0;
                gazeCounter.fillAmount = timer / gazeMaxTime;
            }
        }
        else
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldownOfGaze)
            {
                cooldownTimer = 0;
                cooldownActive = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(BackButtonPosition.position, .3f);

        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(UIFloatingPosition.position, .3f);
    }
}
