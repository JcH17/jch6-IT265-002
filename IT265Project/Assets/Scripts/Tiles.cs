using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum TileType {Start, Regular, Wisdom, Crown, Crisis, Wealth, Tax, Finish};

public class Tiles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TileType tileType;
    public List<Tiles>nextTiles;
}
