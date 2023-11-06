using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text textBox; // Add a public variable for the UI Text component
    private float currentTime = 0f;
    private float changeTime = 20f;
    private int sceneNumber = 1;

    void Start()
    {
        textBox.text = "Scene " + sceneNumber;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= changeTime)
        {
            sceneNumber++;

            if (sceneNumber == 2)
            {
                textBox.text = "Scene 3";
            }
            else if (sceneNumber == 3)
            {
                textBox.text = "Scene 4";
            }
            else if (sceneNumber == 4)
            {
                textBox.text = "Remove headset";
            }
            else if (sceneNumber > 4)
            {
                // If you want to stop changing text after "Remove headset," you can add additional logic here.
            }

            currentTime = 0f;
        }
    }
}
