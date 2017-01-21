using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour {

    public float useMaxDistance = 5;
    public string useKeyBinding = "e";
    private Vector3 posFrom, posTo;
    private bool canUse;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        canUse = true;
	}

    void Update() {
        // Player 'Use' input
        if (Input.GetKeyDown(useKeyBinding) && canUse)
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            //Ray playerForward = new Ray(this.transform.position, this.transform.forward);
            Ray playerForward = new Ray(this.transform.position, fwd);
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
        }
    }
	
	public void setCanUse(bool canUse) {
        this.canUse = canUse;
    }

    public bool getCanUse() {
        return this.canUse;
    }
}
