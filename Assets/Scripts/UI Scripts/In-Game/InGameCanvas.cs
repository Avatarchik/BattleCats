using UnityEngine;
using System.Collections;

/*
 *  Unity UI button-friendly functions to toggle UI states
 */

public class InGameCanvas : MonoBehaviour {
    private Animator anim;

    bool slideBar = false;
    bool storePage = false;
    bool backPanel = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetSlideBar(bool value)
    {
        slideBar = value;
        anim.SetBool("SlideBar", slideBar);
        UpdateBackPanel();
    }

    public void SetStorePage(bool value)
    {
        storePage = value;
        anim.SetBool("StorePage", storePage);
        UpdateBackPanel();
    }

    void UpdateBackPanel()
    {
        backPanel = slideBar || storePage;
        anim.SetBool("BackPanel", backPanel);
    }
}
