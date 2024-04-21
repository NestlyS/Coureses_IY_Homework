using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "Color")]
public class ColorsToMaterialMap : ScriptableObject
{
    [Serializable]
    private class ColorMaterialPair
    {
        [SerializeField] private Material _material;
        public Material Material { get { return _material; }}
        [SerializeField] private BallColors _color;

        public bool CheckIsSameColor (BallColors color) {
            return color == _color;
        }
    }

    [SerializeField] private List<ColorMaterialPair> _pairs;
    private static List<ColorMaterialPair> Pairs;

    public void Init()
    {
        Pairs = new List<ColorMaterialPair>(_pairs);
    }

    public static Material GetMaterialByColor(BallColors color)
    {
        return Pairs.Find(pair => pair.CheckIsSameColor(color)).Material;
    }
}
