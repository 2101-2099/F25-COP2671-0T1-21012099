using UnityEngine;

//Harvestable script
public class Harvestable : MonoBehaviour
{
    public ItemData data;
    private Inventory _inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Add to inventory");
        if (collision.CompareTag("Player"))
        {
            _inventory = collision.GetComponentInParent<Inventory>();
            if (_inventory != null)
            {
                _inventory.AddItem(data);
            }
            Destroy(gameObject);
        }
    }

}
