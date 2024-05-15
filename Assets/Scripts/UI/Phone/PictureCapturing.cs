using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PictureCapturing : MonoBehaviour
{
    [SerializeField] Camera mainCamera; // Reference to the main game camera
    [SerializeField] GameObject cameraMenu; // UI element representing the camera menu
    [SerializeField] TextMeshProUGUI capturedImageCountText; // Use TextMeshProUGUI for Text element
    [SerializeField] int maxImages = 9; // Maximum number of images that can be captured
    [SerializeField] Transform imageContainer; // Parent transform for UI Image elements

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

                // Display the captured image on UI
                if (capturedImageCount == 1)
                {
                    DisplayImage(screenshot, -78.98f, 72.111f);
                }
                else if (capturedImageCount == 2)
                {
                    DisplayImage(screenshot, 1.7001f, 72.111f);
                }
                else if (capturedImageCount == 3)
                {
                    DisplayImage(screenshot, 78.659f, 72.111f);
                }
                else if (capturedImageCount == 4)
                {
                    DisplayImage(screenshot, -78.98f, 0.00029373f);
                }
                else if (capturedImageCount == 5)
                {
                    DisplayImage(screenshot, 1.7001f, 0.00030518f);
                }
                else if (capturedImageCount == 6)
                {
                    DisplayImage(screenshot, 78.659f, -0.00030518f);
                }
                else if (capturedImageCount == 7)
                {
                    DisplayImage(screenshot, -78.98f, -69.7f);
                }
                else if (capturedImageCount == 8)
                {
                    DisplayImage(screenshot, 1.7001f, -69.7f);
                }
                else if (capturedImageCount == 9)
                {
                    DisplayImage(screenshot, 76.6f, -69.7f);
                }
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

        // Debug log to check the dimensions of the screenshot
        Debug.Log("Screenshot dimensions: " + screenshot.width + "x" + screenshot.height);

        return screenshot;
    }

    private void SaveImage(Texture2D image)
    {
        // Get the directory path
        string folderPath = Application.persistentDataPath + "/ScreenShotsOfCamera";

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

    private void DisplayImage(Texture2D image, float xPosition, float yPosition)
    {
        // Create a new UI RawImage element
        GameObject rawImageGO = new GameObject("CapturedImage" + capturedImageCount);
        rawImageGO.transform.SetParent(imageContainer);

        // Add UI RawImage component to the game object
        RawImage rawImage = rawImageGO.AddComponent<RawImage>();

        // Create a texture from the captured image
        Texture2D texture = new Texture2D(image.width, image.height);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;
        texture.SetPixels(image.GetPixels());
        texture.Apply();

        // Assign the texture to the UI RawImage component
        rawImage.texture = texture;

        // Set the size of the RawImage element to match the size of the captured image
        RectTransform rectTransform = rawImageGO.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(62.617f, 63.102f);

        // Set the position of the RawImage element on the screen
        rectTransform.anchoredPosition = new Vector2(xPosition, yPosition);
    }
}
