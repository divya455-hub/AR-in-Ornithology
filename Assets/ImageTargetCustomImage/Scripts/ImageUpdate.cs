using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using System.IO;
using System;

public class ImageUpdate : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public Button updateButton;
    private Texture2D selectedImage;
    public Button changeImageButton;
    public Button changeTargetButton;
    public GameObject albumAndCamera;

    private void Start()
    {
        albumAndCamera.SetActive(false);
    }

    void Awake()
    {
        updateButton.onClick.AddListener(UpdateTarget);
        changeImageButton.onClick.AddListener(changeImageTarget);
    }

void changeImageTarget()
    {
        albumAndCamera.SetActive(true);
        changeImageButton.gameObject.SetActive(false);
        changeTargetButton.gameObject.SetActive(false);
        Debug.Log("Image update button pressed");
    }

    void afterImageChanged()
    {
        albumAndCamera.SetActive(false);
        changeImageButton.gameObject.SetActive(true);
        changeTargetButton.gameObject.SetActive(true);
    }
    void UpdateTarget()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {

                byte[] fileData = File.ReadAllBytes(path);
                selectedImage = new Texture2D(2, 2);
                selectedImage.LoadImage(fileData);

                if (trackedImageManager.referenceLibrary is MutableRuntimeReferenceImageLibrary mutableLibrary)
                {
                    afterImageChanged();
                    mutableLibrary.ScheduleAddImageWithValidationJob(
                        selectedImage,
                        "my new image",
                        0.5f /* 50 cm */);
                }
            }
        }, "Select a PNG image", "image/png");
        Debug.Log("Permission result: " + permission);
    }

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
            Debug.Log("Added image target with name: " + trackedImage.referenceImage.name);
        }

        foreach (ARTrackedImage trackedImage in args.updated)
        {
            Debug.Log("Updated image target with name: " + trackedImage.referenceImage.name);
        }

        foreach (ARTrackedImage trackedImage in args.removed)
        {
            Debug.Log("Removed image target with name: " + trackedImage.referenceImage.name);
        }
    }
}