using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed=0f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameObject ObjectToSpawn;
    [SerializeField] private GameObject ObjectParent;
    
    public cost_checker cost_checker;

    private void createBox()
    {
        //if (cost_checker.cost_check(ObjectToSpawn.GetComponent<"cost">().CostOfObject){ 
        GameObject newObject = Instantiate(ObjectToSpawn, transform.position, transform.rotation, ObjectParent.transform);
    //}
    }
    private void Update()
    {
        Vector2 inputvector=new Vector2(0,0);
        if (Input.GetKey(KeyCode.W))
        {
            inputvector.y = +1;
        }


        if (Input.GetKey(KeyCode.S))
        {
            inputvector.y = -1;
        }


        if (Input.GetKey(KeyCode.D))
        {
            inputvector.x = +1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputvector.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            createBox();
        }
        inputvector = inputvector.normalized;
        Vector3 moveDir = new Vector3(inputvector.x, 0f, inputvector.y);
        transform.position += moveDir* moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward,moveDir, rotateSpeed*Time.deltaTime);
        
    }
}
