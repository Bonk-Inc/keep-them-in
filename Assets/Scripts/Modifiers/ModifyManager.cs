using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyManager : MonoBehaviour
{

    [SerializeField]
    private Modifier[] modifiers;
    
    public void ChooseRandomModifiers()
    {
        foreach (var modifier in modifiers)
        {
            float randonNum = Random.Range(0.0f, 1.0f);
            print(randonNum);
            if (randonNum < 1f / modifiers.Length)
                modifier.Modify();
        }
    }

}
