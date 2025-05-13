using Mono.Cecil.Cil;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // starting position for the parallax game object
    Vector2 startingPosition;

    //start z value of the parallax game object
    float startingZ;

    // distance camera has moved from the camera's starting position
    Vector2 canMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float zDistancefromTarget => transform.position.z - followTarget.transform.position.z;

    //if object is in front of target, use nearClipPlane, if behind, use farClipPlane

    float clippingPlane => (cam.transform.position.z + (zDistancefromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parallaxFactor => Mathf.Abs(zDistancefromTarget) / clippingPlane;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        startingPosition = transform.position;
        startingZ = transform.position.z;
            }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPostition = startingPosition = canMoveSinceStart * parallaxFactor;

        transform.position = new Vector3(newPostition.x, newPostition.y, startingZ);
    }
}
