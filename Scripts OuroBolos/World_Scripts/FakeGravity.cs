using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGravity : MonoBehaviour
{
    [SerializeField, Tooltip("Amount of gravity to be applied to objects")]
    private float gravity = -20;
    [SerializeField, Tooltip("Planet Radius")]

    private float objRotSpeed = 50;
    private float gravityBoost = 0;

    // Generates false gravity for world objects
    public void Attract(Transform objBody)
    {
        // Set planet gravity direction for the object body
        Vector3 gravityDir = (objBody.position - transform.position).normalized;
        Vector3 bodyUp = objBody.up;

        // Apply gravity to object's rigidbody
        objBody.GetComponent<Rigidbody>().AddForce(gravityDir * (gravity + gravityBoost));

        // Update the object's rotation in relation to the planet
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityDir) * objBody.rotation;

        // Smooth rotation
        objBody.rotation = Quaternion.Slerp(objBody.rotation, targetRotation, objRotSpeed * Time.deltaTime);
    }

    // Returns the surface normal at a given position
    public Vector3 GetSurfaceNormal(Vector3 position)
    {
        return (position - transform.position).normalized;
    }

    public void GravityCancell(int validacao)
    {
        if (validacao == 1)
        {
            gravity = gravity * 0;
            Debug.Log(gravity);

        }
        if (validacao == 2)
        {
            gravity = gravity - 20;
            Debug.Log(gravity);
        }
    }
}
