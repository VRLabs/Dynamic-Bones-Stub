using UnityEngine;
using System.Collections.Generic;
using System.Threading;

[AddComponentMenu("Dynamic Bone/Dynamic Bone")]
public class DynamicBone : MonoBehaviour
{
    public Transform m_Root = null;
    public List<Transform> m_Roots = null;
    public float m_UpdateRate = 60.0f;

    public enum UpdateMode
    {
        Normal,
        AnimatePhysics,
        UnscaledTime,
        Default
    }
    public UpdateMode m_UpdateMode = UpdateMode.Default;

    [Range(0, 1)]
    public float m_Damping = 0.1f;
    public AnimationCurve m_DampingDistrib = null;

    [Range(0, 1)]
    public float m_Elasticity = 0.1f;
    public AnimationCurve m_ElasticityDistrib = null;

    [Range(0, 1)]
    public float m_Stiffness = 0.1f;
    public AnimationCurve m_StiffnessDistrib = null;

    [Range(0, 1)]
    public float m_Inert = 0;
    public AnimationCurve m_InertDistrib = null;

    public float m_Friction = 0;
    public AnimationCurve m_FrictionDistrib = null;

    public float m_Radius = 0;
    public AnimationCurve m_RadiusDistrib = null;

    public float m_EndLength = 0;

    public Vector3 m_EndOffset = Vector3.zero;

    public Vector3 m_Gravity = Vector3.zero;

    public Vector3 m_Force = Vector3.zero;

    [Range(0, 1)]
    public float m_BlendWeight = 1.0f;

    public List<DynamicBoneColliderBase> m_Colliders = null;

    public List<Transform> m_Exclusions = null;

    public enum FreezeAxis
    {
        None, X, Y, Z
    }
    public FreezeAxis m_FreezeAxis = FreezeAxis.None;

    public bool m_DistantDisable = false;
    public Transform m_ReferenceObject = null;
    public float m_DistanceToObject = 20;

    [HideInInspector]
    public bool m_Multithread = true;
}
