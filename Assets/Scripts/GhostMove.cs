using UnityEngine;

public class GhostMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusAttack;
    [SerializeField] private LayerMask _playerMask;

    private FirstPersonController _player;
    private bool _isMoving;

    private void Start()
    {
        _player = FindObjectOfType<FirstPersonController>();
    }

    private void Update()
    {
        if (_isMoving == false) return;

        transform.transform.LookAt(_player.transform.position);
        
        MoveGhost();
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusAttack, _playerMask);
        foreach (Collider collider in colliders)
        {
           FirstPersonController player = collider.gameObject.GetComponent<FirstPersonController>();
           if (player)
           {
                player.Death();
                return;
           }
        }
    }

    private void OnDrawGizmos()
    {
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, _radiusAttack); 
    }

    public void Move()
    {
        _isMoving = true;
    }

    private void MoveGhost()
    {
        Vector3 direction = _player.transform.position - transform.position;
        direction.Normalize();
        transform.position += direction * _speed * Time.deltaTime;
    }
}
