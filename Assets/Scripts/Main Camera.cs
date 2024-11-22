using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float offsetY = 2.0f; // Vertical offset from the player
    public float smoothSpeed = 0.125f; // Speed of camera smoothing
    public float defaultZoom = 7f; // Default camera zoom level
    public float zoomSpeed = 1f; // Speed of zoom adjustment

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = defaultZoom; // Set default zoom level
    }

    void LateUpdate()
    {
        // Get player's position
        Vector3 playerPos = player.position;

        // Calculate the desired camera position
        Vector3 desiredPosition = new Vector3(playerPos.x, playerPos.y + offsetY, transform.position.z);

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Adjust camera zoom smoothly if needed (e.g., dynamic zoom based on conditions)
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, defaultZoom, zoomSpeed * Time.deltaTime);
    }
}