using System.IO;
using UnityEditor;
using UnityEngine;

/**
 * ## Notes
 *
 * The prefab at DestinationPrefabPath is expected to already contain a child game object
 * whose name exactly matches DestinationGameObjectName.
 * That child game object will be automatically managed, so don't make any manual changes to it or its children.
 */

public static class SoundAutoHookup
{
    const string SourcePath = "Assets/Audio/Sounds/Auto Hookup";
    const string DestinationPrefabPath = "Assets/Prefabs/Resources/Default Sounds.prefab";
    const string DestinationGameObjectName = "Auto Hookup";
    const string AudioSourcePrefabResourceName = "Auto Hookup Audio Source Prefab";

    [MenuItem("Game/Run Sound Auto Hookup")]
    public static void GoGoGo()
    {
        Debug.Log("Run Sound Auto Hookup: Starting");

        var prefab = PrefabUtility.LoadPrefabContents(DestinationPrefabPath);
        var tfm = prefab.transform.Find(DestinationGameObjectName);

        ClearExistingSounds();
        CreateNewSounds();

        PrefabUtility.SaveAsPrefabAsset(prefab, DestinationPrefabPath);

        Debug.Log("Run Sound Auto Hookup: Done");
        return;


        void ClearExistingSounds()
        {
            for (var i = tfm.childCount - 1; i != -1; --i)
                Object.DestroyImmediate(tfm.GetChild(i).gameObject);
        }

        void CreateNewSounds()
        {
            var clipGUIDS = AssetDatabase.FindAssets("t:AudioClip", new string[] { SourcePath });
            foreach (var guid in clipGUIDS)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var clipName = Path.GetFileNameWithoutExtension(path);
                var clip = AssetDatabase.LoadAssetAtPath<AudioClip>(path);

                // var audioSource = CreatePlainAudioSource(clipName);
                var audioSource = LoadFromResource(clipName);

                audioSource.clip = clip;
            }
        }

        AudioSource LoadFromResource(string clipName)
        {
            var prefab = Resources.Load<GameObject>(AudioSourcePrefabResourceName);
            var gameObject = Object.Instantiate(prefab, tfm);
            gameObject.name = clipName;
            return gameObject.GetComponent<AudioSource>();
        }

        /*
        AudioSource CreatePlainAudioSource(string clipName)
        {
            var gameObject = new GameObject(clipName);
            gameObject.transform.SetParent(tfm);
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;

            return audioSource;
        }
        */
    }
}
