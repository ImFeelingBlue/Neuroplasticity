using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveYardRaycast : MonoBehaviour
{
    [SerializeField] GameObject cameraMenu; // UI element representing the camera menu
    [SerializeField] private float raycastDistance = 15f; // Distance of the raycast
    [SerializeField] private LayerMask targetLayer; // LayerMask to filter targets
    private const string targetTag = "VisableWithLight2D"; // Tag to filter targets

    [SerializeField] GameObject Symbol1;
    [SerializeField] GameObject symbol2;
    [SerializeField] GameObject symbol3;
    [SerializeField] GameObject eyeBalls;
    private bool lockingThisForever = false;

    public SymbolPhotoTrigger SymbolPhotoTrigger;
    public PictureCapturing pictureCapturing;
    public EyeBallsTrigger EyeBallsTrigger;
    public bool eyeBallsAreActive = false;
    private bool symbolPictureTaken = false;

    [SerializeField] private bool works = false;
    

    private void Start()
    {
        eyeBalls.SetActive(false);
        Symbol1.SetActive(true);
        symbol2.SetActive(false);
        symbol3.SetActive(false);
    }

    void Update()
    {
        // Perform the raycast
        Vector2 rayDirection = transform.forward; // Use the same direction as the green raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, raycastDistance, targetLayer);
        if (hit.collider != null && hit.collider.CompareTag(targetTag) && SymbolPhotoTrigger.playerBootEnabled && cameraMenu != null && cameraMenu.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            symbol2.SetActive(true);
            symbol3.SetActive(true);
            symbolPictureTaken = true;
        }
        else if (hit.collider != null && hit.collider.CompareTag(targetTag) && EyeBallsTrigger.inTheEyeBallBox && !lockingThisForever && symbolPictureTaken)
        {
            eyeBalls.SetActive(true);
            eyeBallsAreActive = true;
            lockingThisForever = true;
        }
    }

    void OnDrawGizmos()
    {
        // Draw the raycast in the Scene view for visualization
        Gizmos.color = Color.red; // Set the color to red
        Vector3 endPosition = transform.position + (Vector3)transform.forward * raycastDistance;
        Gizmos.DrawLine(transform.position, endPosition);

        // Optionally, you can draw a sphere at the end of the ray
        Gizmos.DrawSphere(endPosition, 0.1f);
    }
}
