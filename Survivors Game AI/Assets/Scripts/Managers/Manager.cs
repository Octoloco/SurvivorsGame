using UnityEngine;

public partial class GlobalManagers : MonoBehaviour
{
    public abstract class Manager : ScriptableObject
    {
        internal virtual void BeginPlay( ) { }

        internal virtual void EndPlay( ) { }
    }
}