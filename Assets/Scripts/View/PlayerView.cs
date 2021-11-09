using UnityEngine;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private float _step;
        [SerializeField] private GameObject _target;
        
        public void Update()
        {
            var distance = Vector3.Distance(transform.position, _target.transform.position);
            if (Input.GetKeyDown(KeyCode.D)) transform.RotateAround(_target.transform.position, Vector3.up, _step);
            if (Input.GetKeyDown(KeyCode.A)) transform.RotateAround(_target.transform.position, Vector3.up, _step);
            else transform.RotateAround(_target.transform.position, Vector3.up, 0);

            if (Input.GetKeyDown(KeyCode.Space)) Debug.Log($"I Attack {distance}");
        }
    }
}