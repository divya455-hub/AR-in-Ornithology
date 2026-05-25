using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

public class PlaneScanner : MonoBehaviour
{
    public ARRaycastManager ARRaycastManager;
    public ARPlaneManager arPlaneManager;
    public GameObject ObjecToPlace;
    public Pose poseStore;
    public ARSessionOrigin arSessionOrigin;
    private bool isPlacementValid = false;
    private bool isObjectPlaced = false;
    private bool hasScannedPlane = false;
    public Button buttonreset;
    public Button camerabutton;
    public TMP_Text scannerText;
    public PlacementIndicator script;
    public ARSession arSession;
    private GameObject game;
    private bool isobjectplaced;
    //[SerializeField] private GameObject anim;

    void Start()
    {
        isobjectplaced = false;
        ARRaycastManager = FindObjectOfType<ARRaycastManager>();
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        scannerText.enabled = true;
        buttonreset.gameObject.SetActive(false);
        camerabutton.gameObject.SetActive(false);
        //anim.gameObject.SetActive(false);
        game.SetActive(false);
    }
    void Update()
    {
        if (!hasScannedPlane && arPlaneManager.trackables.count > 0)
        {
            hasScannedPlane = true;
            scannerText.enabled = false;
        }
        if (isObjectPlaced)
        {
            return;
        }
        planeScanner();
        if (isPlacementValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }
    public void planeScanner()
    {
        var centerScreen = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hit = new List<ARRaycastHit>();
        ARRaycastManager.Raycast(centerScreen, hit, TrackableType.Planes);
        isPlacementValid = hit.Count > 0;
        if (isPlacementValid)
        {
            poseStore = hit[0].pose;
        }
        var camPos = Camera.current.transform.forward;
        var cameraForward = Camera.current.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        poseStore.rotation = Quaternion.LookRotation(cameraBearing);
        if (isPlacementValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            game = Instantiate(ObjecToPlace, poseStore.position, poseStore.rotation);
        }
    }
    private void PlaceObject()
    {
        game.SetActive(true);
        script.gameObject.SetActive(false);
        buttonreset.gameObject.SetActive(true);
        camerabutton.gameObject.SetActive(true);
        //anim.gameObject.SetActive(true);
        isObjectPlaced = true;
        ObjecToPlace.SetActive(true);
        Debug.Log("object placed scuccessfully");
    }
    public void PlacenewObject()
    {
        //game.SetActive(false);
        Debug.Log("button pressed");
        script.gameObject.SetActive(true);
        buttonreset.gameObject.SetActive(false);
        camerabutton.gameObject.SetActive(false);
        isObjectPlaced = false;
        //anim.gameObject.SetActive(false);
        Debug.Log("reset function finished scuccessfully");
    }
}