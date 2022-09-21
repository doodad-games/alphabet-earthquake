using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    public GameObject Prefab;
    public Transform InstantiateLocation;

    public void CB_Execute() =>
        Instantiate(Prefab, InstantiateLocation.position, Quaternion.identity);

    public void CB_SetPrefab(GameObject newPrefab) =>
        Prefab = newPrefab;
}
