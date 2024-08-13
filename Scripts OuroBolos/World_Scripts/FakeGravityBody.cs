using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FakeGravityBody : MonoBehaviour
{
    [SerializeField, Tooltip("Attractor object to be drawn to, if left blank first available world will be used")]
    private FakeGravity attractor;
    [SerializeField, Tooltip("Set object solid once settled")]
    private bool setSolid = false;

    private Transform objTransform;
    private Rigidbody objRigidbody;

    // Property to access attractor
    public FakeGravity Attractor { get { return attractor; } set { attractor = value; } }

    // Initialization
    private void Start()
    {
        objRigidbody = GetComponent<Rigidbody>();
        objRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        objRigidbody.useGravity = false;
        objTransform = transform;

        // Get attractor if not provided
        if (attractor == null)
        {
            attractor = GameObject.FindGameObjectWithTag("World").GetComponent<FakeGravity>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Return if kinematic
        if (objRigidbody.isKinematic)
        {
            return;
        }

        // Check if object is resting
        if (setSolid)
        {
            ObjectResting();
        }

        // Apply gravity to object
        if (attractor != null)
        {
            attractor.Attract(objTransform);
        }
    }

    // Check if rigidbody is sleeping
    private void ObjectResting()
    {
        if (objRigidbody.IsSleeping())
        {
            objRigidbody.isKinematic = true;
        }
    }
}
