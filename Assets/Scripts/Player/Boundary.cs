using UnityEngine;

public class Boundary : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 lowerLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 upperRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));

        float playerX = Mathf.Clamp(transform.position.x, lowerLeft.x, upperRight.x);
        float playerY = Mathf.Clamp(transform.position.y, lowerLeft.y, upperRight.y);

        transform.position = new Vector3(playerX, playerY, transform.position.z);
    }
}