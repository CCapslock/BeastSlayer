using UnityEngine;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private float _step;
        [SerializeField] private GameObject _target;
        
        public void Update()
        {
            if (Input.GetKey(KeyCode.D)) transform.RotateAround(_target.transform.position, Vector3.up, -_step); 
            if (Input.GetKey(KeyCode.A)) transform.RotateAround(_target.transform.position, Vector3.up, _step);
            else transform.RotateAround(_target.transform.position, Vector3.up, 0);

            if (Input.GetKeyDown(KeyCode.Space)) Debug.Log("I Attack");
        }
    }
}