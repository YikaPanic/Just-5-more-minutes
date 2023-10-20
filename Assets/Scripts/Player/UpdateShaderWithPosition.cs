using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class UpdateTreesBehindPlayer : MonoBehaviour
{
    private Transform playerTransform;
    private const float TRANSPARENT_VALUE = 0.5f;

    void Start()
    {
        playerTransform = this.transform;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Tree")
        {
            AdjustTreeTransparency(collider.transform.parent.gameObject, TRANSPARENT_VALUE); // Use parent gameObject here
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Tree")
        {
            AdjustTreeTransparency(collider.transform.parent.gameObject, 1); // Reset transparency to 1 (fully opaque) and use parent gameObject
        }
    }

    void AdjustTreeTransparency(GameObject tree, float transparencyValue)
    {
        Material treeMaterial = tree.GetComponent<SpriteRenderer>().material;
        treeMaterial.SetFloat("_Transparency", transparencyValue);
    }
}
