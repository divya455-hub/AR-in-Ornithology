using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ImageTracker : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToPlace;
    public Button camerabutton;

    public void Start()
    {
        camerabutton.gameObject.SetActive(false);
    }
    private Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>();

    
    private ARTrackedImageManager trackedImageManager;

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.added)
        {
            SpawnObject(trackedImage);
            Debug.Log("Added image target with name: " + trackedImage.referenceImage.name);
        }

        foreach (ARTrackedImage trackedImage in args.updated)
        {
            UpdateObject(trackedImage);
            Debug.Log("Updated image target with name: " + trackedImage.referenceImage.name);
        }

        foreach (ARTrackedImage trackedImage in args.removed)
        {
            RemoveObject(trackedImage);
            Debug.Log("Removed image target with name: " + trackedImage.referenceImage.name);
        }
    }

    private void SpawnObject(ARTrackedImage trackedImage)
    {
        foreach (var obj in objectsToPlace)
        {
            if (obj.name == trackedImage.referenceImage.name)
            {
                var spawnedObject = Instantiate(obj, trackedImage.transform.position, trackedImage.transform.rotation);
                spawnedObjects.Add(trackedImage.referenceImage.name, spawnedObject);
                camerabutton.gameObject.SetActive(true);
                break;
            }
        }
    }

    private void UpdateObject(ARTrackedImage trackedImage)
    {
        if (spawnedObjects.ContainsKey(trackedImage.referenceImage.name))
        {
            GameObject spawnedObject = spawnedObjects[trackedImage.referenceImage.name];
            if (trackedImage.trackingState == TrackingState.None || trackedImage.trackingState == TrackingState.Limited)
            {
                spawnedObject.SetActive(false);
            }
            else
            {
                spawnedObject.SetActive(true);
                spawnedObject.transform.position = trackedImage.transform.position;
                spawnedObject.transform.rotation = trackedImage.transform.rotation;
            }
        }
    }

    private void RemoveObject(ARTrackedImage trackedImage)
    {
        if (spawnedObjects.ContainsKey(trackedImage.referenceImage.name))
        {
            GameObject spawnedObject = spawnedObjects[trackedImage.referenceImage.name];
            spawnedObjects.Remove(trackedImage.referenceImage.name);
            Destroy(spawnedObject);
        }
    }
}
