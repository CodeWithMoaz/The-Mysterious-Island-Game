using UnityEngine;
using UnityEngine.UI;

public class BombAlert : MonoBehaviour
{
    public float fadeSpeed = 0.5f; // Adjust the speed of the fading
    public Color semiTransparentColor; // Semi-transparent color
    public Color fullyTransparentColor; // Fully transparent color

    private Image alertImage;
    private bool isFadingToTransparent = true; // Flag to track fading direction

    void Start()
    {
        alertImage = GetComponent<Image>();
        alertImage.color = semiTransparentColor; // Set initial color to semi-transparent
        InvokeRepeating("ToggleFadeDirection", 0f, 1f); // Start toggling fade direction every 2 seconds
    }

    void Update()
    {
        if (isFadingToTransparent)
        {
            // Fade towards semi-transparent
            alertImage.color = Color.Lerp(alertImage.color, semiTransparentColor, fadeSpeed * Time.deltaTime);
        }
        else
        {
            // Fade towards fully transparent
            alertImage.color = Color.Lerp(alertImage.color, fullyTransparentColor, fadeSpeed * Time.deltaTime);
        }
    }

    void ToggleFadeDirection()
    {
        isFadingToTransparent = !isFadingToTransparent; // Toggle fade direction
    }
}
