using System.Collections.Generic;
using UnityEngine;

public static class CollectionExtensions
{
    public static T PickRandom<T>(this IReadOnlyList<T> list) =>
        list[Random.Range(0, list.Count)];
}
