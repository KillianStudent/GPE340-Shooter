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
    public void DropItem()
    {
        Pickup dorppedObject = Instantiate(RandomPickupFromList(), gameObject.transform.position, gameObject.transform.rotation) as Pickup;
    }

    public Pickup RandomPickupFromList()
    {
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

        for (int i = 0; i < CDFArray.Count; i++)
        {
            if (randomNumber <= CDFArray[i])
            {
                return itemToDrop[i].pickup;
            }
        }
        return null;
    }

}
