using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private PersistentRaycast raycaster;

	void Start () {
        raycaster = this.GetComponent<PersistentRaycast>();
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (raycaster.currentDoor != null)
            {
                raycaster.currentDoor.GetComponent<DoorBehavior>().SwitchState();
            }
        }
	}
}
