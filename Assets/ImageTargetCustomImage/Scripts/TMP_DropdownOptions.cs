using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TMP_DropdownOptions : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public TMP_Dropdown dropdown;
    public GameObject[] options;
    public GameObject newPrefab;
    public UpdateImageCamera script;


    private void Start()
    {
        dropdown.ClearOptions();

        foreach (GameObject option in options)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(option.name);
            dropdown.options.Add(optionData);

        }
    }

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void SwitchTrackedImagePrefab()
    {
        if (trackedImageManager != null && newPrefab != null)
        {
            Destroy(trackedImageManager.trackedImagePrefab);
            trackedImageManager.trackedImagePrefab = newPrefab;
        }
    }

    public void OnDropdownValueChanged(int index)
    {
        Debug.Log("Dropdown value changed to: " + index);
    }
}
