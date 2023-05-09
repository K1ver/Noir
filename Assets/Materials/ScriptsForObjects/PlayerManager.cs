using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static int usedObjects;

    public static int UsedObjects{
        get { return usedObjects;}
        set { usedObjects += value;}
    }
}
