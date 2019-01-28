using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

	// Update is called once per frame
	void Update ()
    {
        // When u write "transform" without a capital letter, it refers to the "transform" of the current 
        // objet or "this" (in this case the script is applied to the camera, "this" is the camera)
        // IMPORTANT: If u don't put the offset its like a first-person game!
        transform.position = player.position + offset;	
	}
}
