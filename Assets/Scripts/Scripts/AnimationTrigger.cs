using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator;
    public string animation1Name = "Animation1";
    public string animation2Name = "Animation2";
    public Button animbutton;
    public Button closembutton;
    [SerializeField] private GameObject buttons;


    private bool animation1Played = false;

    public void OnButtonClick()
    {
        animator.Play(animation1Name);
        animation1Played = true;
        animbutton.gameObject.SetActive(false);
        buttons.SetActive(false);
    }
    public void close()
    {
        animator.Play(animation2Name);
        animation1Played = false;
        animbutton.gameObject.SetActive(true);
        buttons.SetActive(true);
    }

}
