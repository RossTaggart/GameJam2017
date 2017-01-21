using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour {

    public float useMaxDistance = 5;
    public string useKeyBinding = "e";
    private Vector3 posFrom, posTo;
    private bool isolatedView;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        isolatedView = false;
	}

    void Update() {
        // Player 'Use' input
        if (Input.GetKeyDown(useKeyBinding) && !isolatedView)
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
            Ray playerForward = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(playerForward, out hit, useMaxDistance))
            {
                foreach (Component component in hit.collider.gameObject.GetComponents(typeof(Component)))
                {
                    if (component is Useable)
                    {
                        (component as Useable).use();
                    }
                }
            }
        } else if(Input.GetMouseButtonDown(0) && isIsolatedView()) {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, useMaxDistance)) {
                foreach (Component component in hit.collider.gameObject.GetComponents(typeof(Component)))
                {
                    if (component is Useable)
                    {
                        (component as Useable).use();
                    }
                }
            }
        }
    }

    public void setIsolatedView(bool canUse) {
        this.isolatedView = canUse;
    }

    public bool isIsolatedView() {
        return this.isolatedView;
    }
}
