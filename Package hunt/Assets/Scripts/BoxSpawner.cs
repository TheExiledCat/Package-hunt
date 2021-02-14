using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    
    
    [SerializeField]
    GameObject boxPrefab;
    
    public BoxObject SpawnBox(Box _b,BoxRoller _br)
    {
        GameObject g = Instantiate(boxPrefab, _br.GetStart(), Quaternion.identity);
        BoxObject bo = g.AddComponent<BoxObject>();
        bo.SetBox(_b);
        _br.AddProductToLine(bo);
        return bo;
    }
    public void DespawnBox(Box _b,BoxRoller _br)
    {
        _br.RemoveFromProductLine(_b);
    }
}
