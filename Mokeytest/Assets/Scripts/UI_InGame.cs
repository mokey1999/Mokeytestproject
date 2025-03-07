using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    [Header("UI Slots")]
    [SerializeField] private Image poisonSlot;
    [SerializeField] private Image powerUpSlot;
    [SerializeField] private Text poisonCountText;
    [SerializeField] private Text powerUpCountText;

    [Header("Inventory UI")]
    [SerializeField] private GameObject inventoryPanel;

    private bool isInventoryOpen = false;

    public void UpdateHealthUI(float currentHealth, float maxHealth)
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    public void UpdatePoisonUI(int count)
    {
        if (poisonSlot != null && poisonCountText != null)
        {
            poisonSlot.color = count > 0 ? Color.red : Color.white;
            poisonCountText.text = "Эликсир" + count.ToString();
        }
    }

    public void UpdatePowerUpUI(int count)
    {
        if (powerUpSlot != null && powerUpCountText != null)
        {
            powerUpSlot.color = count > 0 ? Color.blue : Color.white;
            powerUpCountText.text = "PowerUP" + count.ToString();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);
    }
}
