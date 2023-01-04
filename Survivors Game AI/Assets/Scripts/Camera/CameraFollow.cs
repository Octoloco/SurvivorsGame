using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Camera ) )]
public class CameraFollow : MonoBehaviour
{
    public float minOrthoSize = 7F;

    private Camera _Camera;
    private Vector3 _TargetPosition;
    private float _TargetDistance;

    private void Awake( )
    {
        _Camera = GetComponent<Camera>();
    }

    private void Update( )
    {
        var playerFollowers = GlobalManagers.actorManager.GetPlayerFollowers();
        if ( playerFollowers.Count > 0 )
        {
            float maxDistance = minOrthoSize;
            _TargetPosition = playerFollowers[ 0 ].transform.position;
            for ( int i = 1; i < playerFollowers.Count; i++ )
            {
                maxDistance = Mathf.Max( maxDistance, Vector2.Distance( playerFollowers[ i - 1 ].transform.position, playerFollowers[ i ].transform.position ) );
                _TargetPosition = Vector3.Lerp( _TargetPosition, playerFollowers[ i ].transform.position, 0.5F );
            }
            _TargetDistance = maxDistance;
        }

        _TargetPosition.z = -10F;
        _Camera.orthographicSize = _TargetDistance;
        transform.position = _TargetPosition;
    }
}
