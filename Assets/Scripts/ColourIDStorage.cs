using Mirror;
using System.Collections.Generic;
using UnityEngine;



public class ColourIDStorage : NetworkBehaviour
{
    public static ColourIDStorage Instance;

    public Dictionary<int, Color> ColourIDs;

    [SerializeField]
    private Color[] _colours;



    void Awake()
    {
        Instance = this;
        ColourIDs = new Dictionary<int, Color>();
        for (int i = 0; i < _colours.Length; i++)
        {
            ColourIDs.Add(i, _colours[i]);
        }
    }
}
