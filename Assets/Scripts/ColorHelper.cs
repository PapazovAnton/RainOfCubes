using UnityEngine;

public class ColorHelper : MonoBehaviour
{
    private float _minColorValue = 0f;
    private float _maxColorValue = 1f;

    public Color GetRandomColor()
    {
        float r = Random.Range(_minColorValue, _maxColorValue);
        float g = Random.Range(_minColorValue, _maxColorValue);
        float b = Random.Range(_minColorValue, _maxColorValue);
        return new Color(r, g, b);
    }
}
