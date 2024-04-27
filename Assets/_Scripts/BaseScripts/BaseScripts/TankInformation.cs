using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInformation : MonoBehaviour
{
    private CharacterSO tankInfor;
    public CharacterSO TankInfor { get { return tankInfor; } }
    public void SetTankInformation(CharacterSO character)
    {
         tankInfor = character;
    }
}
