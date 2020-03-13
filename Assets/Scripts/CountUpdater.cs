using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountUpdater : MonoBehaviour
{
    public static CountUpdater instance;
    public Text itemCount;
    public int currentAmount = 0;

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
        itemCount.text = currentAmount.ToString();
    }

    void UpdatePickupAmount()
    {
        if (currentAmount < inventory.maxAmount)
            currentAmount += 1;
    }
}
