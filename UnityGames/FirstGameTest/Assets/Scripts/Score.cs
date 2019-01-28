using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;

	// Update is called once per frame
	void Update () {

        // By using ToString(), u are converting wtv variable type to a string type. Plus, the "0"
        // within the ToString is to set the precision to units only (no decimals).
        scoreText.text = player.position.z.ToString("0");
		
	}
}
