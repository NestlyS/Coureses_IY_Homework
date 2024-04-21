using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectSwapper
{
    private List<Transform> _swappableObjects;
    private List<Transform> _swapPoints;

    public ObjectSwapper(List<Transform> swappableObjects, List<Transform> swapPoints)
    {
        if (swapPoints.Count < swappableObjects.Count) throw new ArgumentException();
        _swappableObjects = swappableObjects.ToList();
        _swapPoints = swapPoints.ToList();
        MoveObjectsToPoints();
    }

    public void Left()
    {
        Transform temp = _swapPoints[0];
        _swapPoints.RemoveAt(0);
        _swapPoints.Add(temp);
        Debug.Log(_swapPoints.Count);
        MoveObjectsToPoints();
    }

    public void Right()
    {
        Transform temp = _swapPoints[_swapPoints.Count - 1];
        _swapPoints.RemoveAt(_swapPoints.Count - 1);
        _swapPoints.Insert(0, temp);
        MoveObjectsToPoints();
    }

    private void MoveObjectsToPoints()
    {
        int index = 0;
        _swapPoints.ForEach(point =>
        {

            if (_swappableObjects.Count - 1 < index) return;

            _swappableObjects.ElementAt(index).position = point.position;

            index++;
        });
    }
}
