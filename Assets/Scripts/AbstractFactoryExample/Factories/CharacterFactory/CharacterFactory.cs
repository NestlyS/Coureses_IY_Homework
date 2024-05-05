using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterFactory: ScriptableObject
{
    [SerializeField] protected List<CharacterConfig> _characterConfigs;
    public abstract Character Get(ClassTypes type);

    protected Character GetByType(ClassTypes type)
    {
        CharacterConfig config = _characterConfigs.Find(charConfig => charConfig.CharacterType == type);

        if (config == null) throw new ArgumentException($"Не найден тип {type}");

        return config.Prefab;
    }


    [Serializable]
    protected class CharacterConfig
    {
        [field: SerializeField] public ClassTypes CharacterType { get; private set; }
        [field: SerializeField] public Character Prefab { get; private set; }
    }
}
