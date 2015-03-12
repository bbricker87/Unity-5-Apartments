using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PersistentRaycast : MonoBehaviour {

    internal GameObject currentDoor;

    private GameObject interactButton;
    private RectTransform buttonRect;

    private Ray ray;
    private RaycastHit hit;

    private Vector3 doorScreenPos;
    private int interactableMask = 1 << 8;

	void Start () {
        interactButton = GameObject.Find("OpenButton");
        buttonRect = interactButton.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        Debug.DrawRay(ray.origin, ray.direction * 4.5f, Color.red);

        if (Physics.SphereCast(ray, 0.5f, out hit, 4.5f, interactableMask))
        {
            if (hit.collider.tag == "Door")
            {
                if (!interactButton.activeSelf)
                {
                    interactButton.SetActive(true);
                }
                currentDoor = hit.collider.gameObject;

                UpdateOverlay();
            }
            else if (hit.collider.tag == "ClosetDoor")
            {
                if (!interactButton.activeSelf)
                {
                    interactButton.SetActive(true);
                }
                currentDoor = hit.transform.root.gameObject;

                UpdateOverlay();
            }
            else
            {
                if (interactButton.activeSelf)
                {
                    interactButton.SetActive(false);
                }
                currentDoor = null;
            }
        }
        else
        {
            if (interactButton.activeSelf)
            {
                interactButton.SetActive(false);
            }
            currentDoor = null;
        }
	}

    private void UpdateOverlay()
    {
        currentDoor.GetComponent<DoorBehavior>().UpdateOverlay();

        doorScreenPos = Camera.main.WorldToScreenPoint(currentDoor.transform.position);
        buttonRect.anchoredPosition = new Vector2(doorScreenPos.x, doorScreenPos.y);
    }
}
