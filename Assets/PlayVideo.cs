using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayVideo : MonoBehaviour
{
    public string framesFolder;  // Assign the folder containing your video frames in the inspector
    public RawImage rawImage;

    private float frameRate = 30.0f;  // Adjust this to match your video's frame rate
    private int currentFrame = 0;
    private Texture[] videoFrames;

    private void Start()
    {
        // Load video frames from the specified folder
        LoadVideoFrames();

        // Set the initial frame
        rawImage.texture = videoFrames[currentFrame];
    }

    private void Update()
    {
        if (videoFrames != null && videoFrames.Length > 0)
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
        }
        
        // Other behaviors that need to be executed in the Update method
    }

    private void LoadVideoFrames()
    {
        string[] framePaths = Directory.GetFiles(framesFolder);
        List<Texture> frameList = new List<Texture>();

        foreach (string framePath in framePaths)
        {
            if (framePath.EndsWith(".png") || framePath.EndsWith(".jpg"))
            {
                byte[] bytes = File.ReadAllBytes(framePath);
                Texture2D frameTexture = new Texture2D(2, 2);
                frameTexture.LoadImage(bytes);
                frameList.Add(frameTexture);
            }
        }

        videoFrames = frameList.ToArray();
    }
}
