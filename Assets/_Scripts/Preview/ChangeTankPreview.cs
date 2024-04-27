using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTankPreview : MonoBehaviour
{
    [SerializeField] private List<CharacterSO> tanks;
    [SerializeField] private TankPreview tankPreview;
    private int currentIndex;

    private void Awake()
    {
        ChangedTankObject(0);
        tankPreview = GetComponent<TankPreview>();
    }

    public void ChangedTankObject(int changeIndex)
    {
        currentIndex += changeIndex;
        if(currentIndex < 0)
        {
            currentIndex = tanks.Count - 1;
        }
        else if(currentIndex > tanks.Count -1)
        {
            currentIndex = 0;
        }
        if(tankPreview != null)
        {
            tankPreview.DisplayTank(tanks[currentIndex]);
        }
    }
}
