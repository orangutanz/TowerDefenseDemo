using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [Serializable]
    public class Path
    {
        public int Id;
        public List<Transform> Waypoints;
    }

    public List<Path> Paths;

    public Path GetPath(int id)
    {
        return Paths[id];
    }
}
