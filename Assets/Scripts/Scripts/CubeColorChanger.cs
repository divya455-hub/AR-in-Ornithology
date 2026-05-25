using UnityEngine;
using UnityEngine.UI;

public class CubeColorChanger : MonoBehaviour
{
    [SerializeField] private Button red;
    [SerializeField] private Button yellow;
    [SerializeField] private Button blue;
    [SerializeField] private Button green;
    public Material materialToChange;

    void Start()
    {
       
        red.onClick.AddListener(Changered);
        yellow.onClick.AddListener(Changeyellow);
        blue.onClick.AddListener(Changeblue);
        green.onClick.AddListener(Changegreen);
    }

    void Changered()
    {
        materialToChange.color = Color.red;
    }
    void Changeyellow()
    {
        materialToChange.color = Color.yellow;
    }
    void Changeblue()
    {
        materialToChange.color = Color.blue;
    }
    void Changegreen()
    {
        materialToChange.color = Color.green;
    }
    public void Changewhite()
    {
        materialToChange.color = Color.white;
    }
}
