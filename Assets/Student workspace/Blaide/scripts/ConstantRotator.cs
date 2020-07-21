using UnityEngine;

namespace Student_workspace.Blaide.scripts
{
    public class ConstantRotator : MonoBehaviour
    {
        public Vector3 rotation;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(rotation * Time.deltaTime);
        }
    }
}
