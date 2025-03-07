using UnityEngine;

public class PickUP : MonoBehaviour
{
    public Inventory playerInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Poison"))
            {
                playerInventory.AddItem("Poison");
            }
            else if (gameObject.CompareTag("PowerUP"))
            {
                playerInventory.AddItem("PowerUP");
            }

            Destroy(gameObject);
        }
    }
}
