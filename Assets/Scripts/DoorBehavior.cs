using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorBehavior : MonoBehaviour {

    internal Animator animator;
    private Text buttonText;

    internal bool opened = false;

	void Start () {
	    animator = this.GetComponent<Animator>();

        buttonText = GameObject.Find("OpenButton").transform.GetChild(0).GetComponent<Text>();
	}

    internal void SwitchState()
    {
        opened = !opened;

        animator.SetBool("opened", opened);
    }

    internal void UpdateOverlay()
    {
        if (!opened)
        {
            if (!buttonText.text.Equals("OPEN"))
            {
                buttonText.text = "OPEN";
            }
        } 
        else if (opened)
        {
            if (!buttonText.text.Equals("CLOSE"))
            {
                buttonText.text = "CLOSE";
            }
        }
    }
}
