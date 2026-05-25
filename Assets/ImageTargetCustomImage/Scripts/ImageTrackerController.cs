using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using TMPro;

public class ImageTrackerController : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager m_ImageManager;
    [SerializeField] private TMP_Dropdown m_PrefabDropdown;
    [SerializeField] private List<GameObject> m_Prefabs;
    private GameObject selectedPrefab;

    private void Start()
    {
        m_PrefabDropdown.ClearOptions();
        List<string> prefabNames = new List<string>();
        foreach (GameObject prefab in m_Prefabs)
        {
            prefabNames.Add(prefab.name);
        }
        m_PrefabDropdown.AddOptions(prefabNames);

        m_ImageManager.trackedImagePrefab = m_Prefabs[0];
    }

    void OnEnable()
    {
        m_PrefabDropdown.onValueChanged.AddListener(OnPrefabSelected);
        m_ImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_PrefabDropdown.onValueChanged.RemoveListener(OnPrefabSelected);
        m_ImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnPrefabSelected(int index)
    {
        selectedPrefab = m_Prefabs[index];
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            GameObject prefabInstance = Instantiate(selectedPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
            prefabInstance.transform.SetParent(trackedImage.transform);
            Debug.Log("instantiated");
        }
    }
}