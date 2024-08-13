using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // inspector variables
    [SerializeField, Tooltip("Player transform for camera to follow")]
    private Transform playerTransform;
    [SerializeField, Tooltip("Camera offset from player (x not used)")]
    private Vector3 offsetPosition = new Vector3(0, 5, 5);
    [SerializeField]
    private bool lookAt = true;

    // privates
    private Transform mainCam;

    // Update is called once per frame
    private void LateUpdate()
    {
        UpdateCamera();
    }

    /// <summary>
    /// Update camera position and rotation
    /// </summary>
    private void UpdateCamera()
    {
        if (playerTransform == null)
        {
            return;
        }
        // camera rig position
        transform.position = playerTransform.position - (playerTransform.forward * offsetPosition.z) + (playerTransform.up * offsetPosition.y);
        // point camera at player
        if (lookAt)
        {
            // point camera at player using players up direction
            mainCam.LookAt(playerTransform, playerTransform.up);
        }
        else
        {
            mainCam.LookAt(playerTransform);
        }
    }

    private void Awake()
    {
        // Include GameObject to mainCam
        mainCam = this.transform;
    }
}