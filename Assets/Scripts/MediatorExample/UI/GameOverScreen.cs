using System;
using UnityEngine;

namespace Assets.Scripts.MediatorExample
{
    public class GameOverScreen: MonoBehaviour
    {
        public event Action Restart;

        public void OnRestart() => Restart?.Invoke();
    }
}