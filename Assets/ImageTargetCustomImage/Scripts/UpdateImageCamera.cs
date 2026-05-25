using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.IO;
using TMPro;

public class UpdateImageCamera : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public Button cameraButton;
    public Button changeTargetButton;
    public Button changeImageButton;
    public TMP_Dropdown dropdown;
    public GameObject albumAndCamera;
    private Texture2D selectedImage;
    public Button camerabutton;

    void Awake()
    {
        camerabutton.gameObject.SetActive(false);
        cameraButton.onClick.AddListener(takephoto);
        changeTargetButton.onClick.AddListener(changeTarget);
        dropdown.gameObject.SetActive(false);
    }

    void changeTarget()
    {
        albumAndCamera.SetActive(false);
        changeImageButton.gameObject.SetActive(false);
        changeTargetButton.gameObject.SetActive(false);
        dropdown.gameObject.SetActive(true);
        //dropdown.ClearOptions();
    }

    void targetchanged()
    {
        changeImageButton.gameObject.SetActive(true);
        changeTargetButton.gameObject.SetActive(true);
        dropdown.gameObject.SetActive(false);
    }

    void takephoto()
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            if (path != null)
            {
                byte[] fileData = File.ReadAllBytes(path);
                selectedImage = new Texture2D(2, 2);
                selectedImage.LoadImage(fileData);

                if (trackedImageManager.referenceLibrary is MutableRuntimeReferenceImageLibrary mutableLibrary)
                {
                    targetchanged();
                    mutableLibrary.ScheduleAddImageWithValidationJob(
                        selectedImage,
                        "my new image",
                        0.5f /* 50 cm */);
                }
            }
        }, -1);
        Debug.Log("Permission result: " + permission);
    }

    private void OnEnable() => trackedImageManager.trackedImagesChanged += OnChanged;

    private void OnDisable() => trackedImageManager.trackedImagesChanged -= OnChanged;

    private void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.added)
        {
            Debug.Log("Added image target with name: " + trackedImage.referenceImage.name);
        }

        foreach (ARTrackedImage trackedImage in args.updated)
        {
            camerabutton.gameObject.SetActive(true);
            Debug.Log("Updated image target with name: " + trackedImage.referenceImage.name);
        }

        foreach (ARTrackedImage trackedImage in args.removed)
        {
            Debug.Log("Removed image target with name: " + trackedImage.referenceImage.name);
        }
    }
}
