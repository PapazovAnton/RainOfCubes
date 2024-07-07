using System.Collections.Generic;
using UnityEngine;

public class CubePull : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private List<Cube> _pool = new List<Cube>();

    public Cube GetFree()
    {
        return (TryGetCube(out Cube cube)) ? cube : Create();
    }

    private bool TryGetCube(out Cube cube)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                cube = item;
                cube.gameObject.SetActive(true);
                return true;
            }
        }

        cube = null;
        return false;
    }

    private Cube Create()
    {
        Cube cube = Instantiate(_prefab);
        _pool.Add(cube);
        return cube;
    }
}
