using System;
using UnityEngine;

public class RandomClassCharacterFactoryAdapter : IFactory
{
    private CharacterFactory _initialFactory;

    public RandomClassCharacterFactoryAdapter(CharacterFactory initialFactory)
    {
        _initialFactory = initialFactory;
    }

    public MonoBehaviour Get() => GetCharacterWithRandomType();

    public string GetName() => _initialFactory.GetType().ToString();

    private MonoBehaviour GetCharacterWithRandomType()
    {
        ClassTypes type = (ClassTypes)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ClassTypes)).Length);
        return _initialFactory.Get(type);
    }
}
