using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScreen : MonoBehaviour
{
    [SerializeField] Camera cameraToDisplay; // Reference to the camera whose view will be displayed
    [SerializeField] RawImage screenImage; // Reference to the RawImage component representing the camera screen

    private RenderTexture renderTexture; // Render texture to display the camera's view

    private void Start()
    {
        // Create a render texture with the same dimensions as the screen image
        renderTexture = new RenderTexture((int)screenImage.rectTransform.rect.width, (int)screenImage.rectTransform.rect.height, 24);
        renderTexture.Create();

        // Assign the render texture to the camera's target texture
        cameraToDisplay.targetTexture = renderTexture;

        // Assign the render texture to the RawImage component
        screenImage.texture = renderTexture;
    }

    private void OnDestroy()
    {
        // Release the render texture when the object is destroyed
        renderTexture.Release();
    }
}
