using UnityEngine;

public class PortalScript : MonoBehaviour
{
    string firstSong = "1stSong";

    private void OnCollisionEnter(Collision collision)
    {
        SceneController.instance.LoadNewScene(firstSong);
        Debug.Log("Collided with" + collision.ToString());
    }
}
