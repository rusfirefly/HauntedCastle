using UnityEngine;

public class GhostMove : MonoBehaviour, IRestart
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusAttack;
    [SerializeField] private LayerMask _playerMask;

    private FirstPersonController _player;
    private SoundHandler _soundHandler;

    private bool _isMoving;
    private bool _isPlayerAttack;

    private void Start()
    {
        _player = FindObjectOfType<FirstPersonController>();
        _soundHandler = GetComponent<SoundHandler>();
        _soundHandler.Initialize();
    }

    private void Update()
    {
        if (_isMoving == false) return;
        
        if (_isPlayerAttack == false) {
            if (_player)
            {
                transform.transform.LookAt(_player.transform.position);
            }

            MoveGhost();
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusAttack, _playerMask);
        foreach (Collider collider in colliders)
        {
           FirstPersonController player = collider.gameObject.GetComponent<FirstPersonController>();
           if (player)
           {
                _isPlayerAttack = true;
                _soundHandler.Stop();

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
        _soundHandler.Play();
    }

    private void MoveGhost()
    {
        Vector3 direction = _player.transform.position - transform.position;
        direction.Normalize();
        transform.position += direction * _speed * Time.deltaTime;
    }

    public void Restart()
    {
        _isPlayerAttack = false;
        _isMoving = false;
        _soundHandler.Stop();
    }
}
