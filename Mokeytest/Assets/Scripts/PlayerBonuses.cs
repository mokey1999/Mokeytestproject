using UnityEngine;

public class PlayerBonuses : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    public void UsePoison()
    {
        if (playerHealth != null)
        {
            playerHealth.Heal(30f);
        }
    }

    public void UsePowerUP()
    {
    }
}
