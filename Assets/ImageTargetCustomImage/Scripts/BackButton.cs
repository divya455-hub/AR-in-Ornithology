using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackButton : MonoBehaviour
{
    public Button Image;
    public Button Target;
    public Button album;
    public Button shot;
    public Button back;
    public TMP_Dropdown TMP_Dropdown;

    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(maketrue);
    }

    public void maketrue()
    {
        Image.gameObject.SetActive(true);
        Target.gameObject.SetActive(true);
        TMP_Dropdown.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Input.backButtonLeavesApp = true;

    }
}
