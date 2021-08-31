using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int row = 3;
    public int col = 4;

    public float gapRow = 1.5f;     // f pour declarer un float 
    public float gapCol = 1.5f;

    public GameObject itemPrefab;

    public ItemBehavior[] items;        // tableau 

    // Start is called before the first frame update
    void Start()
    {
        items = new ItemBehavior[row * col];    // creation tableau et grandeur 
        int index = 0;

        for (int x = 0; x < col; x++)           // il faut tenir en compte le gap plustard
        {
            for (int z = 0; z < row; z++)
            {
                Vector3 position = new Vector3(x * gapCol, 0, z * gapRow);       // etablir la position ( Vector3(x, y, z) )
                GameObject item = Instantiate(itemPrefab, position, Quaternion.identity);

                items[index] = item.GetComponent<ItemBehavior>();       // avoir ItemBehavior sur le prefab sinon null reference 

                items[index].id = index;            // .id = atteindre l'id de l'object

                index++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
