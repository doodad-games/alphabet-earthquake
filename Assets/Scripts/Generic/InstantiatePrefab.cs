using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    public GameObject Prefab;
    public Transform InstantiateLocation;

    public void CB_InstantiatePrefab() =>
        Instantiate(Prefab, InstantiateLocation.position, Quaternion.identity);

    public void CB_SetPrefab(GameObject newPrefab) =>
        Prefab = newPrefab;
}
