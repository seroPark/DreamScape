using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour
{
    public Texture[] videoFrames;  // Assign your video frames in the inspector
    public RawImage rawImage;

    private float frameRate = 30.0f;  // Adjust this to match your video's frame rate
    private int currentFrame = 0;

    private void Start()
    {
        // Set the initial frame
        rawImage.texture = videoFrames[currentFrame];
    }

    private void Update()
    {
        // Switch to the next frame based on frame rate
        float frameTime = 1.0f / frameRate;
        if (Time.time >= frameTime * (currentFrame + 1))
        {
            currentFrame++;
            if (currentFrame >= videoFrames.Length)
                currentFrame = 0;
            rawImage.texture = videoFrames[currentFrame];
        }
        
        // Other behaviors that need to be executed in the Update method
    }
}
