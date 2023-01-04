using UnityEngine;

public static class UnityUtils
{
    public static void SetHideFlagsRecursive( GameObject gameObject, HideFlags hideFlags )
    {
        gameObject.hideFlags = hideFlags;
        SetChildrenHideFlagsRecursive( gameObject, hideFlags );
    }

    public static void SetChildrenHideFlagsRecursive( GameObject gameObject, HideFlags hideFlags )
    {
        int childCount = gameObject.transform.childCount;
        for ( int i = 0; i < childCount; i++ )
        {
            SetHideFlagsRecursive( gameObject.transform.GetChild( i ).gameObject, hideFlags );
        }
    }
}