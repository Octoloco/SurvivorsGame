using System.Collections;
using UnityEngine;

public partial class GlobalManagers : MonoBehaviour
{
    private ActorManager _ActorManager = default;

    private static bool _IsPlaying = false;

    private static GlobalManagers _Instance;
    private static bool _bInstance = false;

#if UNITY_EDITOR
    private static ActorManager s_ActorManager = default;

    public static ActorManager actorManager => (Application.isPlaying && _bInstance) ? _Instance._ActorManager : s_ActorManager == null ? s_ActorManager = FindManager<ActorManager>() : s_ActorManager;
#else
        public static ActorManager actorManager => m_Instance._ActorManager;
#endif

    public static bool isPlaying => _IsPlaying;

    public static System.Action onBeginPlay;
    public static System.Action onEarlyUpdate;
    public static System.Action onLateUpdate;
    public static System.Action onEndPlay;

    public static GlobalManagers instance
    {
        get
        {
            if ( _Instance == null )
            {
                _Instance = Object.FindObjectOfType<GlobalManagers>();
                if ( _Instance == null )
                    GlobalManagers.CreateInstance();
            }

            return _Instance;
        }
    }

    public static Type FindManager<Type>( ) where Type : Manager
    {
        Object[] systems = Resources.FindObjectsOfTypeAll<Type>();
        if ( systems.Length == 0 )
            systems = Resources.LoadAll( "Managers", typeof( Type ) );

        if ( systems.Length == 0 )
            Debug.LogError( $"Can't find, or is not loaded '{typeof( Type )}' in Resources" );
        else
            return ( Type )systems[ 0 ];
        return null;
    }

    public Coroutine DoCoroutine( IEnumerator enumerator )
    {
        return StartCoroutine( enumerator );
    }

#if UNITY_EDITOR
    static GlobalManagers( )
    {
        // UnityEditor.EditorApplication.update += OnEditorUpdate;
    }

    internal static ManagerT GetManager<ManagerT>( ) where ManagerT : Manager
    {
        string[] managerPaths = UnityEditor.AssetDatabase.FindAssets($"t:{typeof( ManagerT )}");
        if ( managerPaths.Length != 0 )
        {
            ManagerT managerAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<ManagerT>( UnityEditor.AssetDatabase.GUIDToAssetPath( managerPaths[0] ) );
            return managerAsset;
        }
        else
        {
            Debug.LogError( $"Create a {nameof( ManagerT )} first!" );
        }
        return null;
    }
#endif

    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.SubsystemRegistration )]
    private static void CreateInstance( )
    {
        if ( _bInstance = _Instance != null ) return;
        GameObject holder = new GameObject( "[Global Systems]" );
        if ( Application.isPlaying )
            DontDestroyOnLoad( holder );
        holder.AddComponent<GlobalManagers>();

        UnityUtils.SetHideFlagsRecursive( holder, HideFlags.DontSaveInEditor );
    }

    private void OnApplicationQuit( )
    {
        if ( _Instance )
            GameObject.DestroyImmediate( _Instance.gameObject );
    }

    private void Awake( )
    {
        _Instance = this;
        _ActorManager = FindManager<ActorManager>();

        _ActorManager?.BeginPlay();
        _IsPlaying = true;
        onBeginPlay?.Invoke();
    }

    // private void OnEnable()
    // {
    //     onLoaded?.Invoke();
    // }

    private void Update( )
    {
        // _ActorManager?.Update();
        onEarlyUpdate?.Invoke();
    }

    private void LateUpdate( )
    {
        onLateUpdate?.Invoke();
    }

    private void OnDestroy( )
    {
        _IsPlaying = false;
        onEndPlay?.Invoke();
        _ActorManager?.EndPlay();
        _Instance = null;
    }
}