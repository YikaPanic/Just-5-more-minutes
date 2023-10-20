using UnityEngine;

public class BackgroundCameraBlur : MonoBehaviour
{
    public static BackgroundCameraBlur Instance;

    public Shader motionBlurShader;
    private Material motionBlurMaterial;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        motionBlurMaterial = new Material(motionBlurShader);
    }

    public void EnableBlur(Vector2 blurDirection)
    {
        motionBlurMaterial.SetFloat("_BlurAmount", 2.5f); 
        motionBlurMaterial.SetVector("_BlurDirection", new Vector4(blurDirection.x, blurDirection.y, 0, 0));
    }

    public void DisableBlur()
    {
        motionBlurMaterial.SetFloat("_BlurAmount", 0f);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, motionBlurMaterial);
    }
}
