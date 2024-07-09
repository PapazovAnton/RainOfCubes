using UnityEngine;

public class ColorHelper
{
    private float _minColorValue = 0f;
    private float _maxColorValue = 1f;

    public Color GetRandomColor()
    {
        float red = Random.Range(_minColorValue, _maxColorValue);
        float green = Random.Range(_minColorValue, _maxColorValue);
        float blue = Random.Range(_minColorValue, _maxColorValue);
        return new Color(red, green, blue);
    }
}
