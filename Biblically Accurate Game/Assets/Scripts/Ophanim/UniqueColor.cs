using UnityEngine;

[ExecuteInEditMode] // This makes the script run in edit mode
public class UniqueColor : MonoBehaviour
{
    public Color color = Color.white; // Set default color to white

    // This is called when the script is loaded or a value is changed in the Inspector
    void OnValidate()
    {
        SetColor(color);
    }

    // Start is only called in play mode, but we keep it if you need initialization there
    void Start()
    {
        SetColor(color);
    }

    public void SetColor(Color newColor)
    {
        Renderer renderer = GetComponent<Renderer>();
        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(propBlock);
        propBlock.SetColor("_Color", newColor);
        renderer.SetPropertyBlock(propBlock);
    }

    public void ChangeColorRuntime(Color runtimeColor)
    {
        SetColor(runtimeColor);
    }
}
