using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Scriptable Object/Dialog")]
public class DialogLines : ScriptableObject
{
    public List<string> lines;
}
