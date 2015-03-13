using UnityEngine;
using System.Collections;

public class UpdateReflection : MonoBehaviour {

    public ReflectionProbe probe;

    private bool updatedOpen, updatedClose;
    private int renderID;
    private DoorBehavior doorBehavior;
	void Start () {
        doorBehavior = this.GetComponent<DoorBehavior>();

        renderID = probe.RenderProbe();

        updatedOpen = updatedClose = false;
	}
	
	void Update () {
        if (doorBehavior.animator.GetCurrentAnimatorStateInfo(0).IsName("OpenDoor") &&
            doorBehavior.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
        {
            if (!updatedOpen)
            {
                if (probe.IsFinishedRendering(renderID))
                {
                    renderID = probe.RenderProbe();
                }
                updatedOpen = true;
                updatedClose = false;
            }
        }
        if (doorBehavior.animator.GetCurrentAnimatorStateInfo(0).IsName("CloseDoor") &&
            doorBehavior.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
        {
            if (!updatedClose)
            {
                if (probe.IsFinishedRendering(renderID))
                {
                    renderID = probe.RenderProbe();
                }
                updatedOpen = false;
                updatedClose = true;
            }
        }
	}
}
