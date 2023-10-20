using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MotionBlurEffect : MonoBehaviour
{
    public Shader blurShader;
    private Material blurMaterial;
    private Camera cam;

    [Range(0, 5)]
    public float blurAmount = 0;

    public Vector2 blurDirection;

    void Start()
    {
        cam = GetComponent<Camera>();
        blurMaterial = new Material(blurShader);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (blurMaterial)
        {   
            // Create a low resolution temporary RenderTexture to render effects
            RenderTexture tempRT = RenderTexture.GetTemporary(src.width / 2, src.height / 2);
            Graphics.Blit(src, tempRT);

            blurMaterial.SetTexture("_MainTex", tempRT);
            blurMaterial.SetFloat("_BlurAmount", blurAmount);
            blurMaterial.SetVector("_BlurDirection", blurDirection);
            Graphics.Blit(src, dest, blurMaterial);

            // Release the temporary RenderTexture
            RenderTexture.ReleaseTemporary(tempRT);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
