using UnityEngine;

public class TextureOffsetAnimator : MonoBehaviour {

    public Vector2 uvAnimationRate = new Vector2(1, 1);

    Renderer renderer;
    // Use this for initialization
    void Start () {
        renderer = GetComponent<Renderer>();
	}

    Vector2 uvOffset = Vector2.zero;
    void LateUpdate()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (renderer.enabled)
        {
            renderer.material.mainTextureOffset = uvOffset;
        }
    }
}
