using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField] GameObject point;
    private float _size; 

    private void Start()
    {
        _size = transform.localScale.x - 4;

        SpawnPoint();
    }

    public void SpawnPoint() 
    {
        float boundsX = Random.Range(-_size/2, _size/2);
        float boundsY = Random.Range(-_size/2, _size/2);
        Vector3 pointPosition = new Vector3(boundsX, boundsY, 0);
        Instantiate(point, pointPosition, Quaternion.identity);
    }
}
