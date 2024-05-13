using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class PictureCapturing : MonoBehaviour
{
    [SerializeField] Camera mainCamera; // Reference to the main game camera
    [SerializeField] GameObject cameraViewfinder; // UI element representing the camera viewfinder
    [SerializeField] GameObject cameraMenu; // UI element representing the camera menu
    [SerializeField] TextMeshProUGUI capturedImageCountText; // Use TextMeshProUGUI for Text element
    [SerializeField] int maxImages = 30; // Maximum number of images that can be captured

    private int capturedImageCount = 0; // Number of images captured

    public void Update()
    {
        TakePicture();
    }

    public void TakePicture()
    {
        if (cameraMenu != null && cameraMenu.activeSelf && Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log("Click");
            if (capturedImageCount < maxImages)
            {
                // Capture the current camera view as a screenshot
                Texture2D screenshot = CaptureScreenshot(mainCamera);

                // Save the screenshot as an image file
                SaveImage(screenshot);

                // Increment the captured image count
                capturedImageCount++;

                // Update UI to display the new captured image count
                capturedImageCountText.text = "Captured Images: " + capturedImageCount;
            }
            else
            {
                Debug.Log("Maximum number of images captured.");
            }
        }
    }

    private Texture2D CaptureScreenshot(Camera camera)
    {
        // Capture the current camera view as a screenshot
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera.targetTexture = renderTexture;
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);
        return screenshot;
    }

    private void SaveImage(Texture2D image)
    {
        // Get the directory path
        string folderPath = "D:/GitHub/Neuroplasticity/Assets/Sprites/UI/ScreenShotsOfCamera";

        // Check if the directory exists, create it if not
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Save the image as a PNG file within the specified folder
        byte[] bytes = image.EncodeToPNG();
        string filename = "screenshot_" + capturedImageCount + ".png";
        string filePath = Path.Combine(folderPath, filename);

        // Write the image bytes to the file
        File.WriteAllBytes(filePath, bytes);
        Debug.Log("Image saved as: " + filePath);
    }
}
