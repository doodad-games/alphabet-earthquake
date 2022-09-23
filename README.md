# Alphabet Earthquake

- Read about and play the game at [itch.io](https://bilalakil.itch.io/alphabet-earthquake)
- Made with Unity (see version in [ProjectVersion.txt](https://github.com/doodad-games/alphabet-earthquake/blob/main/ProjectSettings/ProjectVersion.txt))

## Some Technical Info

- Models are made inside Unity using Probuilder. They are coloured only with vertex colours. Meshes haven't been exported from Probuilder 😅 
- Audio has been prepared for some models which don't yet exist. You can see the list of pending models in [Assets/Scriptable Objects/Phonetic Objects/Pending Visuals](https://github.com/doodad-games/alphabet-earthquake/tree/main/Assets/Scriptable%20Objects/Phonetic%20Objects/Pending%20Visuals)
- Experimental game logic implementation is driven by generic MonoBehaviours, ["scriptable variables"](https://unity.com/how-to/architect-game-code-scriptable-objects#architect-variables) and ["scriptable events"](https://unity.com/how-to/architect-game-code-scriptable-objects#architect-events)
    - See the "Scene Logic" game object in the "Main" scene
