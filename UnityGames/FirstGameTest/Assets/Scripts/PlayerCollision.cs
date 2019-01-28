using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    
    // For this method u need to enable rigidBody and box collider for it to work
    void OnCollisionEnter(Collision collisionInfo)
    {
        // collisionInfo.collider gives information on what "this" collided with
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            // u need to use FindObjectOfType cuz u want the GameManager Script to be
            // on the player when he respawns.
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
