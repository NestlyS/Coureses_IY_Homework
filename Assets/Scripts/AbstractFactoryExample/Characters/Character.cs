using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterData _character;

    public void Init(CharacterData character)
    {
        _character = character;
        _character.TryUseSpecial();
    }
}