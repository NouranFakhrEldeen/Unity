using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour, IGazeInput
{
    //public string planetName;
    //[TextArea] public string description;

    public Collider myCollider;
    //public Rigidbody myBody;

    public PlanetData data;

    [Header("Data")]
    public GameObject DataDisplay;
    public Text Title;
    public Text Description;

    private void Start()
    {
        myCollider = GetComponent<Collider>();
        //myBody = GetComponent<Rigidbody>();
        DataDisplay.SetActive(false);
    }

    public void OnGaze()
    {
        Debug.Log("looking at " + data.name + ":\n" + data.description);

        DataDisplay.SetActive(true);
        Title.text = data.name;
        Description.text = data.description;

        myCollider.enabled = false;
    }

    public void ResetObject()
    {
        myCollider.enabled = true;
        DataDisplay.SetActive(false);
    }
}
