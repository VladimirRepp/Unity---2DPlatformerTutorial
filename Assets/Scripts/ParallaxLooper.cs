using UnityEngine;

public class ParallaxLooper : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [Range(0f, 1.2f)][SerializeField] private float parallaxMultiplier = 0.5f;

    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    private void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        lastCameraPosition = cameraTransform.position;

        // Получаем реальную ширину спрайта с учетом pixels per unit
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;

        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        // Параллакс-движение
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxMultiplier, 0, 0);

        lastCameraPosition = cameraTransform.position;

        // Бесконечный повтор (looping)
        float distance = cameraTransform.position.x - transform.position.x;

        if (Mathf.Abs(distance) >= textureUnitSizeX)
        {
            float offset = distance % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x - offset, transform.position.y, transform.position.z);
        }
    }
}
