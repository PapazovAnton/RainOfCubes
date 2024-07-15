using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CubePull))]

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private float _heightOffset = 7f;
    [SerializeField] private float _delay = 2f;

    private CubePull _pool;
    private Bounds _spawnBounds;

    private void Awake()
    {
        _pool = GetComponent<CubePull>();
    }

    private void Start()
    {
        CalculateZone();
        StartCoroutine(GenerateRainCoroutine());
    }

    private void CalculateZone()
    {
        int divisor = 2;

        Renderer renderer = _platform.GetComponent<Renderer>();

        Vector3 size = renderer.bounds.size;
        Vector3 center = renderer.bounds.center + Vector3.up * (size.y / divisor + _heightOffset);

        _spawnBounds = new Bounds(center, size);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        float x = Random.Range(_spawnBounds.min.x, _spawnBounds.max.x);
        float y = _spawnBounds.max.y;
        float z = Random.Range(_spawnBounds.min.z, _spawnBounds.max.z);
        return new Vector3(x, y, z);
    }

    private IEnumerator GenerateRainCoroutine()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            GenerateCube();
            yield return wait;
        }
    }

    private void GenerateCube()
    {
        Cube cube = _pool.GetFree();
        cube.transform.position = GetRandomSpawnPoint();
    }
}
