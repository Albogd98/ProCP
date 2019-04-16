using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform[] routes;
    private int _routeToGo;
    private float _tParam;
    private Vector3 _carPosition;
    
    private bool _coroutineAllowed;

    private float _speedModifier;
    private float _speed = 2;
    private float _acceleration = 1;
    private float _counter = 0;
    private bool _collided;
    private int _cuberNumber;

    public void Accelerate()
    {
        if (_speed < 5)
        {
            _speed += _acceleration;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _speedModifier = 0.5f;
        _routeToGo = 0;
        _tParam = 0f;
        _coroutineAllowed = true;
        _collided = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckFront())
        {
            if (_collided)
            {
                _routeToGo = Random.Range(0, 3);
                if (_coroutineAllowed)
                    StartCoroutine(GoByTheRoute(_routeToGo));
            }
            else
            {
                MoveForward();
            }
        }
        

    }


    private bool CheckFront()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.distance > 2f)
            {                
                return false;
            }
            return true;

        }
        else
        {
            return false;
        }
    }


    void MoveForward()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    void Invoke()
    {
        GameObject newCar = Instantiate(gameObject);
        newCar.transform.position = new Vector3(0,0,1.64f);
    }

    private IEnumerator GoByTheRoute(int _routeNumber)
    {
        _coroutineAllowed = false;

        Vector3 p0 = routes[_routeNumber].GetChild(0).position;
        Vector3 p1 = routes[_routeNumber].GetChild(1).position;
        Vector3 p2 = routes[_routeNumber].GetChild(2).position;
        Vector3 p3 = routes[_routeNumber].GetChild(3).position;

        float _startingAngle = transform.localEulerAngles.y;
        _startingAngle = (_startingAngle > 180) ? _startingAngle - 360 : _startingAngle;


        while (_tParam < 1)
        {
            _tParam += Time.deltaTime * _speedModifier;
            
            _carPosition = Mathf.Pow(1 - _tParam, 3) * p0 +
                           3 * Mathf.Pow(1 - _tParam, 2) * _tParam * p1 +
                           3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * p2 +
                           Mathf.Pow(_tParam, 3) * p3;
            transform.position = _carPosition;
            transform.Translate(0, 0, _speed * Time.deltaTime);

            float angle = transform.localEulerAngles.y;
            angle = (angle > 180) ? angle - 360 : angle;

            if (_routeNumber == 0)
            {
                if (angle - _startingAngle <= 90f)
                    transform.Rotate(0, 1f, 0);
            }
            else if (_routeNumber == 1)
            {
                if (_startingAngle - angle <= 90f)
                    transform.Rotate(0, -1f, 0);
            }



            yield return new WaitForEndOfFrame();
        }

        _tParam = 0f;


        /*if (_routeNumber == 0)
        {
            transform.Rotate(0, 90, 0);
        }
        else if (_routeNumber == 1)
        {
            transform.Rotate(0, -90, 0);
        }*/
        

   

        _coroutineAllowed = true;
        _collided = false;
    }

    void OnCollisionEnter(Collision col)
    {
        _speed = 3;
        _collided = true;

        if  (col.gameObject.name == "Cube1")
        {
            GameObject myObject = GameObject.Find("Cube1");
            routes[0] = GameObject.Find("TurnRight1").transform;
            routes[1] = GameObject.Find("TurnLeft1").transform;
            routes[2] = GameObject.Find("GoStraight1").transform;
        }
        else if (col.gameObject.name == "Cube2")
        {
            routes[0] = GameObject.Find("TurnRight2").transform;
            routes[1] = GameObject.Find("TurnLeft2").transform;
        }
        else if (col.gameObject.name == "Cube3")
        {
            routes[0] = GameObject.Find("TurnRight3").transform;
            routes[1] = GameObject.Find("TurnLeft3").transform;
        }
        else if (col.gameObject.name == "Cube4")
        {
            routes[0] = GameObject.Find("TurnRight4").transform;
            routes[1] = GameObject.Find("TurnLeft4").transform;
        }
        else if (col.gameObject.name == "Cube1")
        {
            print("collision");
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "Cube")
        {
            print("collision detected");
            Destroy(gameObject);
        }



    }
    

}
