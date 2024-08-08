using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceSystem : SingletonPersistent<ResourceSystem>
{
    public List<ScriptableRoad> Roads { get; private set; }
    private Dictionary<RoadType, ScriptableRoad> _RoadDict;
    protected override void Awake()
    {
        base.Awake();
        AssemblyResources();
    }

    private void AssemblyResources()
    {
        Roads = Resources.LoadAll<ScriptableRoad>("Roads").ToList();
        _RoadDict = Roads.ToDictionary(r => r.RoadType, r => r);
    }
    public ScriptableRoad GetRoad(RoadType t) => _RoadDict[t];
}

