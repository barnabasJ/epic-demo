using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountUpdater : MonoBehaviour
{
    public static CountUpdater instance;
    public Text itemCount;
    
    public Inventory inventory;
    // Call this event by using CountUpdater.instance.pickupEvent.Invoke()
    public UnityEvent pickupEvent;

    private void Awake()
    {
        instance = this;
        pickupEvent = new UnityEvent();
    }

    void Start()
    {
        pickupEvent.AddListener(UpdatePickupAmount);
    }

    void Update()
    {
        itemCount.text = inventory.currentAmount.ToString();
    }

    void UpdatePickupAmount()
    {
        if (inventory.currentAmount < inventory.maxAmount)
            inventory.currentAmount += 1;
    }
}
