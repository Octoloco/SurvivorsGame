using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "ActorManager", menuName = "Global Managers/Actor Manager", order = 320 )]
public class ActorManager : GlobalManagers.Manager
{
    private List<Actor> _Actors = new List<Actor>();
    private List<PlayerFollower> _PlayerFollowers = new List<PlayerFollower>();

    internal override void BeginPlay( )
    {
        base.BeginPlay();
    }

    internal override void EndPlay( )
    {
        base.EndPlay();
        _Actors.Clear();
        _PlayerFollowers.Clear();
    }

    public int GetPlayerFollowersCount( )
    {
        return _PlayerFollowers.Count;
    }

    public IList<PlayerFollower> GetPlayerFollowers( )
    {
        return _PlayerFollowers as IList<PlayerFollower>;
    }

    internal void RegisterActor( Actor actor )
    {
        _Actors.Add( actor );
        if ( actor is PlayerFollower ) _PlayerFollowers.Add( actor as PlayerFollower );
    }

    internal void ReleaseActor( Actor actor ) 
    {
        _Actors.Remove( actor );
        if ( actor is PlayerFollower ) _PlayerFollowers.Remove( actor as PlayerFollower );
    }
}
