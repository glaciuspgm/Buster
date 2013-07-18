using UnityEngine; 
using UnityEditor;
using System.Collections;
 
public class ToolsEditor : ScriptableObject
{
    [MenuItem ("Tools/Add Pivot")]
    static void MenuInsertPivot()
    {
        Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);
 
        GameObject newParent = new GameObject("Pivot");
        Transform newParentTransform = newParent.transform;
 
        if(transforms.Length == 1)
        {
            Transform originalParent = transforms[0].parent;
            transforms[0].parent = newParentTransform;
            if(originalParent)
                newParentTransform.parent = originalParent;
        }
        else
        {
            foreach(Transform transform in transforms)
                transform.parent = newParentTransform;
        }
    }
}