using UnityEngine;

public class FBDManager : MonoBehaviour
{
    // References
    [SerializeField] private Camera FBDCamera;
    [SerializeField] private GameObject FBDPreviewTarget;

    // Parameters
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float zoomSpeed;

    private void Update()
    {
        // Rotate x
        if (Input.GetKey(KeyCode.Z))
        {
            FBDPreviewTarget.transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime);
        }
        // Rotate y
        if (Input.GetKey(KeyCode.X))
        {
            FBDPreviewTarget.transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        // Rotate z
        if (Input.GetKey(KeyCode.C))
        {
            FBDPreviewTarget.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
        // Zoom in
        if (Input.GetKey(KeyCode.V))
        {
            FBDCamera.transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
        }
        // Zoom out
        if (Input.GetKey(KeyCode.B))
        {
            FBDCamera.transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
        }
    }
}
