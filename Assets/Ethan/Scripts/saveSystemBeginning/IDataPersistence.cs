using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Compilation;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}
