using UnityEngine;
using System.Collections;

public class InteractiveMainMenu : MonoBehaviour
{

    // Use this for initialization
    public void PlayZoomTransition()
    {
        GameObject.Find("Logo").GetComponent<Animator>().SetTrigger("Zoom");
        GameObject.Find("FadeObjects").GetComponent<Animator>().SetTrigger("FadeOut");
    }
    public void LoadRoomsLevel()
    {
        GameObject.Find("[Mgr]LoadingSceneManager").GetComponent<LoadingSceneManager>().LoadScene("Prototype 2.0");
    }




}
