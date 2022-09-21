using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UnityEventFloat : UnityEvent<float> { }

[Serializable]
public class UnityEventInt : UnityEvent<int> { }

[Serializable]
public class UnityEventChar : UnityEvent<char> { }

[Serializable]
public class UnityEventString : UnityEvent<string> { }

[Serializable]
public class UnityEventGameObject : UnityEvent<GameObject> { }
