using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<IEnergyUser>() != null)
        {
            if (GetComponentInParent<AIBeylbladeAttacker>().isAtDistance == true)
            {
                GetComponentInParent<AIBeylbladeAttacker>().hitEnemy = true;
                GetComponentInParent<IEnergyUser>().RemoveEnergy(GetComponentInParent<AIBeylbladeAttacker>().attackEnemyCost);

                Debug.Log("HIT: " + collision.gameObject.name);
            }
        }
    }
}
