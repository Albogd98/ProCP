using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    private float _timer = 1;
    public GameObject _car;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0) 
        {
            Instantiate(_car, transform.position, transform.rotation);
            _timer = 5;
        }
    }
}
