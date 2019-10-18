using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    public int Count;
    public GameObject[] Prefabs;
    public float SpawnDelay;

    public Transform ExplosionPosition;
    public float ExplosionForce;

    public bool ApplyDrag;

    private Transform _Trans;
    private BoxCollider _SpawnArea;
    private List<GameObject> _Debris = new List<GameObject>();
    private float _NextSpawnTime;

    void Start()
    {
        _Trans = transform;
        _SpawnArea = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (Time.time > _NextSpawnTime && _Debris.Count < Count)
        {
            _NextSpawnTime = Time.time + SpawnDelay;
            SpawnDebris();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _Debris.Count; i++)
                _Debris[i].GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce, ExplosionPosition.position, 10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = _Debris.Count - 1; i >= 0; i--)
                Destroy(_Debris[i].gameObject);

            _Debris.Clear();
        }
    }

    private void SpawnDebris()
    {
        var index = Random.Range(0, Prefabs.Length);
        var postion = GetRandomPosition();
        var rotation = Random.rotationUniform;
        var instance = Instantiate(Prefabs[index], postion, rotation);

        var drag = instance.GetComponentInChildren<DragApplier>();
        if (drag != null)
            drag.enabled = ApplyDrag;

        _Debris.Add(instance);
    }

    Vector3 GetRandomPosition()
    {
        var min = _Trans.position - (_SpawnArea.size / 2);
        var max = _Trans.position + (_SpawnArea.size / 2);
        return new Vector3()
        {
            x = Random.Range(min.x, max.x),
            y = Random.Range(min.y, max.y),
            z = Random.Range(min.z, max.z),
        };
    }
}
