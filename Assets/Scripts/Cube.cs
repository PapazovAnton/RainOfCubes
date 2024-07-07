using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private Color _dafaultColor = Color.black;

    private ColorHelper _colorHelper = new ColorHelper();
    private Renderer _objectRenderer;
    private bool _isChangeColor = false;
    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;

    private void Awake()
    {
        _objectRenderer = GetComponent<Renderer>();
        _objectRenderer.material.color = _dafaultColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.AddComponent<Platform>() && _isChangeColor == false)
        {
            ChangeColor();
            StartCoroutine(DestroyWithDelay());
        }
    }

    private void ChangeColor()
    {
        Color color = _colorHelper.GetRandomColor();
        _objectRenderer.material.color = color;
        _isChangeColor = true;
    }

    private void ResetParams()
    {
        _isChangeColor = false;
        _objectRenderer.material.color = _dafaultColor;
    }

    IEnumerator DestroyWithDelay()
    {
        float delay = Random.Range(_minLifeTime, _maxLifeTime);
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        ResetParams();
    }
}
