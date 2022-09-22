using UnityEngine;

public class EmitParticleSystem : MonoBehaviour
{
    public ParticleSystem System;
    [field: SerializeField] public Vector3 Position { get; set; }
    [field: SerializeField] public int Count { get; set; }

    ParticleSystem.EmitParams _emitParams;

    public void CB_EmitParticleSystem()
    {
        _emitParams.applyShapeToPosition = true;
        _emitParams.position = Position;
        System.Emit(_emitParams, Count);
    }
}
