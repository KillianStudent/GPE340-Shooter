using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public List<WeightedDrop> itemToDrop;
    public List<int> CDFArray = new List<int>();
    public int randomNumber;

    [System.Serializable]
    public class WeightedDrop
    {
        public Pickup pickup;
        public int weight;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropItem()
    {
        //RandomPickupFromList();
        Pickup dorppedObject = Instantiate(RandomPickupFromList(), gameObject.transform.position, gameObject.transform.rotation) as Pickup;
        Debug.Log(RandomPickupFromList());
    }

    public Pickup RandomPickupFromList()
    {
        // create an array equal in size to to the weighted drops
        CDFArray.Clear();

        int density = 0;
        // go through weited drop list and track cumulative density
        for (int i= 0; i < itemToDrop.Count; i++)
        {
            density += itemToDrop[i].weight;
            CDFArray.Add(density);
        }

        // choose a random number between 0 and the maximum density
        int randomNumber = Random.Range(0, density);

        int selectedIndex = System.Array.BinarySearch(CDFArray.ToArray(), randomNumber);
        if (selectedIndex < 0)
        {
            selectedIndex = -selectedIndex;
        }
        return itemToDrop[selectedIndex].pickup;
    }

}
