using System.Collections;
using UnityEngine;

public class CarFollow : MonoBehaviour
{

    [SerializeField] private Transform[] routes;
    private int _routeToGo;
    private float _tParam;
    private Vector3 _carPosition;
    private float _speedModifier;
    private bool _coroutineAllowed;

    // Start is called before the first frame update
    void Start()
    {
        _routeToGo = 0;
        _tParam = 0f;
        _coroutineAllowed = true;
        _speedModifier = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_coroutineAllowed)
            StartCoroutine(GoByTheRoute(_routeToGo));
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        _coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        float startingAngle = transform.localEulerAngles.y;
        startingAngle = (startingAngle > 180) ? startingAngle - 360 : startingAngle;

        while (_tParam < 1)
        {
            _tParam += Time.deltaTime * _speedModifier;

            _carPosition = Mathf.Pow(1 - _tParam, 3) * p0 +
                           3 * Mathf.Pow(1 - _tParam, 2) * _tParam * p1 +
                           3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * p2 +
                           Mathf.Pow(_tParam, 3) * p3;
            transform.position = _carPosition;

            float angle = transform.localEulerAngles.y;
            angle = (angle > 180) ? angle - 360 : angle;

            if (angle - startingAngle <= 90f)
            transform.Rotate(0, 1f, 0);

            yield return new WaitForEndOfFrame();
        }

        _tParam = 0f;

        //_routeToGo += 1;

        // if (_routeToGo > routes.Length - 1)
        //    _routeToGo = 0;

        _coroutineAllowed = true;
    }
}
