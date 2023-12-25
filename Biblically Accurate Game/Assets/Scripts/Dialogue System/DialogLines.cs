using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogLine
{
    public string name;
    public string line;
    public Sprite avatar;
}

[CreateAssetMenu(fileName = "New Dialog", menuName = "Scriptable Object/Dialog")]
public class DialogLines : ScriptableObject
{
    public List<DialogLine> levelOneIntroLines;
    public List<DialogLine> levelOneVictoryLines;

   
}
