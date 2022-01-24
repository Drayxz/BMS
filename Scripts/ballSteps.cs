using UnityEngine;

public class ballSteps : MonoBehaviour
{
    //preexisting game objects to spawn for phase
    [SerializeField] private GameObject action_one;
    [SerializeField] private GameObject action_two;
    [SerializeField] private GameObject action_three;
    [SerializeField] private GameObject action_four;

    private GameObject action_object;

    //tracks the gamephase
    private int game_action_number;

    void Start()
    {
        action_object = Instantiate(action_one) as GameObject;
        action_object.transform.parent = transform;
        game_action_number = 1;
    }

    public void NextPhase()
    {
        Debug.Log("In Next Phase " + game_action_number);
        
        //increments gamephase
        if (game_action_number < 4)
        {
            game_action_number++;
        }
        else
        {
            //game is over needs to go to result lobby
            //to be implemented
        }

        //spawns based on gamephase
        switch (game_action_number)
        {
            case 1:
                action_object = Instantiate(action_one) as GameObject;
                action_object.transform.parent = transform;
                break;
            case 2:
                action_object = Instantiate(action_two) as GameObject;
                action_object.transform.parent = transform;
                break;
            case 3:
                action_object = Instantiate(action_three) as GameObject;
                action_object.transform.parent = transform;
                break;
            case 4:
                action_object = Instantiate(action_four) as GameObject;
                action_object.transform.parent = transform;
                break;
        }
    }
}
