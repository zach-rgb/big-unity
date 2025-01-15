using UnityEngine;
using UnityEngine.InputSystem;

public class IntroCamPos : MonoBehaviour{
    public Instantiating instantiating;
    private bool running = false;

    public void Begin(){

        float xCoords = instantiating.gridSpecs[2];
        float zCoords = instantiating.gridSpecs[3];
        float yCoords = (float)(instantiating.gridSpecs[0] * 1.2);
        transform.position = new Vector3(xCoords, yCoords, zCoords);
        running = true;

    }
    void Update(){

        if(running == true){
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
            transform.Translate(moveDirection * 5 * Time.deltaTime, Space.World);

            if(transform.position[2] > 0){
                transform.position = new Vector3(transform.position.x, transform.position.y,0);
            }
            else if(transform.position[2] < (instantiating.gridSpecs[0] * -1.4928f)){
               transform.position = new Vector3(transform.position.x, transform.position.y,instantiating.gridSpecs[0] * -1.4928f);
            }
            if(transform.position[0] < (-0.429f * instantiating.gridSpecs[0])){
                transform.position = new Vector3((-0.429f * instantiating.gridSpecs[0]), transform.position.y,transform.position.z);
            }
            else if(transform.position[0] > (instantiating.gridSpecs[0]* 1.2857f)){
                transform.position = new Vector3((instantiating.gridSpecs[0]* 1.2857f), transform.position.y,transform.position.z);
            }
        }

    }
}