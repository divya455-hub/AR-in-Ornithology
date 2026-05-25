using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    List<InfoBehaviour> infos = new List<InfoBehaviour>();

    private void Start()
    {
        infos = FindObjectsOfType<InfoBehaviour>().ToList();
    }
    private void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasInfo"))
            {
                openInfo(go.GetComponent<InfoBehaviour>());
            }
            else
            {
                closeAll();
            }
        }
    }
    void openInfo(InfoBehaviour desiredInfo)
    {
        foreach(InfoBehaviour info in infos)
        {
            if(info == desiredInfo)
            {
                info.OpenInfo();
            }
            else
            {
                info.CloseInfo();
            }
        }
    }
    void closeAll()
    {
        foreach(InfoBehaviour info in infos)
        {
            info.CloseInfo();
        }
    }

}
