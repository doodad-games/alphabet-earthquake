using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class Test_AssetValidation
{
    [Test]
    public void PhoneticObjects()
    {
        var configGUIDs = AssetDatabase.FindAssets("t:PhoneticObject");
        foreach (var configGUID in configGUIDs)
        {
            var configPath = AssetDatabase.GUIDToAssetPath(configGUID);
            var config = AssetDatabase.LoadAssetAtPath<PhoneticObject>(configPath);

            Assert.IsNotNull(config);
            Assert.IsNotNull(Sound.Get(config.SoundName));

            var prefab = Resources.Load<GameObject>(config.PrefabName);
            Assert.IsNotNull(prefab, config.PrefabName);
            Assert.IsNotNull(prefab.GetComponent<Rigidbody>());
            Assert.IsNotNull(prefab.GetComponentInChildren<Collider>());
        }
    }
}
