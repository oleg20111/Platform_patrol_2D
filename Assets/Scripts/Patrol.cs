using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _groundDetection;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    private bool _moovingRight = true;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetection.position, Vector2.down, _distance);
        if(groundInfo.collider == false)
        {
            if(_moovingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _moovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _moovingRight = true;
            }
        }
    }
}
