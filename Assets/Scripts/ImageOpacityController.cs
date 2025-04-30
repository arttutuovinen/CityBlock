using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageOpacityController : MonoBehaviour
{
   public Image imageToFade;         // Assign the Image via Inspector
    public float fadeDelay = 1f;      // Delay before fade starts
    public float fadeDuration = 5f;   // Duration of fade

    private float timer = 0f;
    private bool fading = false;

    void Start()
    {
        if (imageToFade == null)
        {
            Debug.LogError("No image assigned to FadeOutImage script.");
            enabled = false;
            return;
        }

        // Ensure starting color is fully opaque (alpha = 255)
        Color c = imageToFade.color;
        c.a = 1f;
        imageToFade.color = c;

        // Start the fade after a delay
        Invoke(nameof(BeginFade), fadeDelay);
    }

    void BeginFade()
    {
        fading = true;
        timer = 0f;
    }

    void Update()
    {
        if (!fading) return;

        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

        Color c = imageToFade.color;
        c.a = alpha;
        imageToFade.color = c;

        if (timer >= fadeDuration)
        {
            fading = false;
        }
    }  
    
}
