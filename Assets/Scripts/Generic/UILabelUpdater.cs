using UnityEngine;
using UnityEngine.UIElements;

public class UILabelUpdater : MonoBehaviour
{
    public UIDocument Document;
    public string Name;
    public string ClassName;

    public void UpdateWithInt(int value) =>
        Document.rootVisualElement.Q<Label>(
            Name == "" ? null : Name,
            ClassName == "" ? null : ClassName
        ).text = $"{value}";
}
