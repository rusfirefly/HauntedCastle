using UnityEngine;

public class DieZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out FirstPersonController player))
        {
            player.Death();
        }
    }
}
