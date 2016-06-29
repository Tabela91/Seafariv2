using UnityEngine;
using System.Collections;
using System.Collections.Generic;//used to create List
using System.Linq; //method to ToList the questions
using UnityEngine.UI;// to use Text 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Arrays

    public Question[] nurseHoundQuestions;
    public Question[] parrotFishQuestions;
    public Question[] blueRunnerQuestions;
    public Question[] atlanticMackeralQuestions;
    public Question[] derbioQuestions;

    private static List<Question> unansweredNurseHoundQuestions;
    private static List<Question> unansweredParrotFishQuestions;
    private static List<Question> unansweredBlueRunnerQuestions;
    private static List<Question> unansweredAtlanticMackeralQuestions;
    private static List<Question> unansweredDerbioQuestions;

    private Question currentQuestion;

    /*
    public Question[] questions;
    //This list will persist between scenes and will contain all questions we have not yet answered.
    private static List<Question> unansweredQuestions;
    private Question currentQuestion; //stores the current question value

    */

    [SerializeField]//to make it appear in the inspector
    private Text questionText; //text object for the UI
    [SerializeField]
    private Text answer1Text;
    [SerializeField]
    private Text answer2Text;
    [SerializeField]
    private Text answer3Text;
    [SerializeField]
    private Text answer4Text;
    [SerializeField]
    private float timeBetweenQuestions = 1f; //sets delay before next question;

    //Variables 

        //UI Text placeholders
    public Text scoreUIText; // assign it from inspector
    public Text globalUIText;

        //Game Objects

    public GameObject timeUpWarning;//time up text

        //Used for code functionalities
    public float timeLimit;//assigned from inspector. The time limit to answer a question in.
	public float globalScore; //where the end game score is going to be saved. 
	private bool runTimer = false;//boolean to control Timer activation
    private bool buttonsActive = true;//activates buttons 
    private bool lastQuestionAnswered = false; //checks if last question is answered

	/*
	public Button ans1;//place where to place botton
	public Button ans2;//place where to place botton
	public Button ans3;//place where to place botton
	public Button ans4;//place where to place botton

	public Sprite rightAnswer;//place to store sprite
	public Sprite wrongAnswer;//place to store sprite

	GameObject ans1Answer;////////////////////////////////
	GameObject ans2Answer;////////////////////////////////
	GameObject ans3Answer;////////////////////////////////
	GameObject ans4Answer;////////////////////////////////
	*/

    IEnumerator StartTimer()
    {
		DisableButtons();////////////////////////////////

		//waits for a few seconds and then sets the timer to true (active)
        yield return new WaitForSeconds(2f);
        runTimer = true; 

		ans1.interactable = true; //Enables button ////////////////////////////////
		ans2.interactable = true; //Enables button ////////////////////////////////
		ans3.interactable = true; //Enables button ////////////////////////////////
		ans4.interactable = true; //Enables button////////////////////////////////

    }

    void Start()
    {
        StartCoroutine(StartTimer());//activates the Timer
        //created an array of questions filled in the inspector. When running the game for the first time we will
        // load those questions into a list of unanswered questions.
        if (unansweredNurseHoundQuestions == null || unansweredNurseHoundQuestions.Count == 0)
        {
            unansweredNurseHoundQuestions = nurseHoundQuestions.ToList<Question>();
        }
        if (unansweredParrotFishQuestions == null || unansweredParrotFishQuestions.Count == 0)
        {
            unansweredParrotFishQuestions = parrotFishQuestions.ToList<Question>();
        }
        if (unansweredBlueRunnerQuestions == null || unansweredBlueRunnerQuestions.Count == 0)
        {
            unansweredBlueRunnerQuestions = blueRunnerQuestions.ToList<Question>();
        }
        if (unansweredAtlanticMackeralQuestions == null || unansweredAtlanticMackeralQuestions.Count == 0)
        {
            unansweredAtlanticMackeralQuestions = atlanticMackeralQuestions.ToList<Question>();
        }
        if (unansweredDerbioQuestions == null || unansweredDerbioQuestions.Count == 0)
        {
            unansweredDerbioQuestions = derbioQuestions.ToList<Question>();
        }

        

        if (unansweredNurseHoundQuestions.Count == unansweredDerbioQuestions.Count)
        {
            SetNurseHoundQuestion();
        }
        else if (unansweredParrotFishQuestions.Count == unansweredDerbioQuestions.Count)
        {
            SetParrotFishQuestion();
        }
        else if (unansweredBlueRunnerQuestions.Count == unansweredDerbioQuestions.Count)
        {
            SetBlueRunnerQuestion();
        }
        else if (unansweredAtlanticMackeralQuestions.Count == unansweredDerbioQuestions.Count)
        {
            SetAtlanticMackeralQuestion();
        }
        else if (unansweredAtlanticMackeralQuestions.Count != unansweredDerbioQuestions.Count)
        {
            SetDerbioQuestion();
            lastQuestionAnswered = true;
        }

        
        /*
         SetNurseHoundQuestion();
        SetParrotFishQuestion();
        SetBlueRunnerQuestion();
        SetAtlanticMackeralQuestion();
        SetDerbioQuestion();
        */




        timeUpWarning = GameObject.Find("TimeUp");
        timeUpWarning.SetActive(false);
        
    }

    void SetNurseHoundQuestion()
    {
        //generates a random int as an index from the list. It will then load the question which matches this 
        //random index.
        int randomQuestionIndex = Random.Range(0, unansweredNurseHoundQuestions.Count);
        currentQuestion = unansweredNurseHoundQuestions[randomQuestionIndex];

        //sets UI Text to the Question text stored in the array list 
        questionText.text = unansweredNurseHoundQuestions[randomQuestionIndex].questionText;
        answer1Text.text = unansweredNurseHoundQuestions[randomQuestionIndex].A1Text;
        answer2Text.text = unansweredNurseHoundQuestions[randomQuestionIndex].A2Text;
        answer3Text.text = unansweredNurseHoundQuestions[randomQuestionIndex].A3Text;
        answer4Text.text = unansweredNurseHoundQuestions[randomQuestionIndex].A4Text;
    }

    void SetParrotFishQuestion()
    {
        //generates a random int as an index from the list. It will then load the question which matches this 
        //random index.
        int randomQuestionIndex = Random.Range(0, unansweredParrotFishQuestions.Count);
        currentQuestion = unansweredParrotFishQuestions[randomQuestionIndex];

        //sets UI Text to the Question text stored in the array list 
        questionText.text = unansweredParrotFishQuestions[randomQuestionIndex].questionText;
        answer1Text.text = unansweredParrotFishQuestions[randomQuestionIndex].A1Text;
        answer2Text.text = unansweredParrotFishQuestions[randomQuestionIndex].A2Text;
        answer3Text.text = unansweredParrotFishQuestions[randomQuestionIndex].A3Text;
        answer4Text.text = unansweredParrotFishQuestions[randomQuestionIndex].A4Text;
    }

    void SetBlueRunnerQuestion()
    {
        //generates a random int as an index from the list. It will then load the question which matches this 
        //random index.
        int randomQuestionIndex = Random.Range(0, unansweredBlueRunnerQuestions.Count);
        currentQuestion = unansweredBlueRunnerQuestions[randomQuestionIndex];

        //sets UI Text to the Question text stored in the array list 
        questionText.text = unansweredBlueRunnerQuestions[randomQuestionIndex].questionText;
        answer1Text.text = unansweredBlueRunnerQuestions[randomQuestionIndex].A1Text;
        answer2Text.text = unansweredBlueRunnerQuestions[randomQuestionIndex].A2Text;
        answer3Text.text = unansweredBlueRunnerQuestions[randomQuestionIndex].A3Text;
        answer4Text.text = unansweredBlueRunnerQuestions[randomQuestionIndex].A4Text;
    }

    void SetAtlanticMackeralQuestion()
    {
        //generates a random int as an index from the list. It will then load the question which matches this 
        //random index.
        int randomQuestionIndex = Random.Range(0, unansweredAtlanticMackeralQuestions.Count);
        currentQuestion = unansweredAtlanticMackeralQuestions[randomQuestionIndex];

        //sets UI Text to the Question text stored in the array list 
        questionText.text = unansweredAtlanticMackeralQuestions[randomQuestionIndex].questionText;
        answer1Text.text = unansweredAtlanticMackeralQuestions[randomQuestionIndex].A1Text;
        answer2Text.text = unansweredAtlanticMackeralQuestions[randomQuestionIndex].A2Text;
        answer3Text.text = unansweredAtlanticMackeralQuestions[randomQuestionIndex].A3Text;
        answer4Text.text = unansweredAtlanticMackeralQuestions[randomQuestionIndex].A4Text;
    }

    void SetDerbioQuestion()
    {
        //generates a random int as an index from the list. It will then load the question which matches this 
        //random index.
        int randomQuestionIndex = Random.Range(0, unansweredDerbioQuestions.Count);
        currentQuestion = unansweredDerbioQuestions[randomQuestionIndex];

        //sets UI Text to the Question text stored in the array list 
        questionText.text = unansweredDerbioQuestions[randomQuestionIndex].questionText;
        answer1Text.text = unansweredDerbioQuestions[randomQuestionIndex].A1Text;
        answer2Text.text = unansweredDerbioQuestions[randomQuestionIndex].A2Text;
        answer3Text.text = unansweredDerbioQuestions[randomQuestionIndex].A3Text;
        answer4Text.text = unansweredDerbioQuestions[randomQuestionIndex].A4Text;
    }
    /*
    void SetCurrentQuestion()
    {
        //generates a random int as an index from the list. It will then load the question which matches this 
        //random index.
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        //sets UI Text to the Question text stored in the array list 
        questionText.text = currentQuestion.questionText;
        answer1Text.text = currentQuestion.A1Text;
        answer2Text.text = currentQuestion.A2Text;
        answer3Text.text = currentQuestion.A3Text;
        answer4Text.text = currentQuestion.A4Text;
    }
    */

    IEnumerator TransitionToNextQuestion()
    {
        //this will then remove the selected question from the index so that once it is answered, 
        //it cannot be selected randomly again.
        unansweredNurseHoundQuestions.Remove(currentQuestion);
        unansweredParrotFishQuestions.Remove(currentQuestion);
        unansweredBlueRunnerQuestions.Remove(currentQuestion);
        unansweredAtlanticMackeralQuestions.Remove(currentQuestion);
        unansweredDerbioQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);
        //this will reload the scene with the next question
        if (lastQuestionAnswered)
        {
            SceneManager.LoadScene(4);
        }
        else
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (runTimer)//if timer is active
        {
            TimerCountdown();//begin timer countdown method
        }
        
    }

    void TimerCountdown()
    {
        //creates a 'time remaining' variable which is equal to the time limit minus Time.deltatime
        float remaining = timeLimit -= Time.deltaTime;
        globalUIText.text = remaining.ToString("#0");//assigns the current value of 'remaining' to the Text UI
        if (timeLimit <= 0)//if the timer reaches zero
        {
            timeLimit = 0;//timer is set to zero
            runTimer = false;//timer is deactivated
            buttonsActive = false;//deactivates buttons
            timeUpWarning.SetActive(true);//brings up the Time Up warning

            StartCoroutine(TransitionToNextQuestion());//begins transition to next scene
        }

    }

    

    public void UserSelectA1()//if user selects A1 button
    {
        if (buttonsActive)
        {
            runTimer = false;//timer is deactivated
            if (currentQuestion.A1correct == true)//checks if A1 is the correct answer
            {
                Debug.Log("CORRECT!");//if yes, outputs CORRECT
				SetGlobalScore (); //////////////////////////////// FUNCTION CREATED AT THE END
				ans1Answer = GameObject.Find("ans1"); //target button //////////////////////////////// THE SAME FOR EACH ANSWER
				ans1Answer.GetComponent<Image> ().sprite = rightAnswer;//change button ////////////////////////////////

            }
            else
            {
                Debug.Log("WRONG!");//otherwise outputs WRONG
				ans1Answer = GameObject.Find("ans1"); //target button////////////////////////////////THE SAME FOR EACH ANSWER
				ans1Answer.GetComponent<Image> ().sprite = wrongAnswer;//change button////////////////////////////////
				DisableButtons();
            }
            StartCoroutine(TransitionToNextQuestion());//begin transition to next scene
        }
    }

    public void UserSelectA2()
    {
        if (buttonsActive)
        {
            runTimer = false;//timer is deactivated
            if (currentQuestion.A2correct == true)
            {
                Debug.Log("CORRECT!");
				SetGlobalScore ();
				ans2Answer = GameObject.Find("ans2"); //target button
				ans2Answer.GetComponent<Image> ().sprite = rightAnswer;//change button

            }
            else
            {
                Debug.Log("WRONG!");
				ans2Answer = GameObject.Find("ans2"); //target button
				ans2Answer.GetComponent<Image> ().sprite = wrongAnswer;//change button
				DisableButtons();
            }
            StartCoroutine(TransitionToNextQuestion());
        }
    }
    public void UserSelectA3()
    {
        if (buttonsActive)
        {
            runTimer = false;//timer is deactivated
            if (currentQuestion.A3correct == true)
            {
                Debug.Log("CORRECT!");
				SetGlobalScore ();
				ans3Answer = GameObject.Find("ans3"); //target button
				ans3Answer.GetComponent<Image> ().sprite = rightAnswer;//change button

            }
            else
            {
                Debug.Log("WRONG!");
				ans3Answer = GameObject.Find("ans3"); //target button
				ans3Answer.GetComponent<Image> ().sprite = wrongAnswer;//change button
				DisableButtons();
            }
            StartCoroutine(TransitionToNextQuestion());
        }
    }

    public void UserSelectA4()
    {
        if (buttonsActive)
        {
            runTimer = false;//timer is deactivated
            if (currentQuestion.A4correct == true)
            {
                Debug.Log("CORRECT!");
				SetGlobalScore ();
				ans4Answer = GameObject.Find("ans4"); //target button
				ans4Answer.GetComponent<Image> ().sprite = rightAnswer;//change button

            }
            else
            {
                Debug.Log("WRONG!");
				ans4Answer = GameObject.Find("ans4"); //target button
				ans4Answer.GetComponent<Image> ().sprite = wrongAnswer;//change button
				DisableButtons();
            }
            StartCoroutine(TransitionToNextQuestion());
        }
    }

	void SetGlobalScore ()
	{
		DisableButtons();
		timeLimit = Mathf.Round(timeLimit * 10); //Multiplies the timer by 10 and rounds it.
		globalScore = timeLimit += globalScore; //Adds the score to the Global score.
		Debug.Log (timeLimit); //Displays in console for checking.
		timeLimit = Mathf.Round (timeLimit / 10);//Sets it back to normal so that it will display correctly.
		scoreUIText.text = globalScore.ToString (); //Displays score in the UI.
	}

	void DisableButtons()
	{
		ans1.interactable = false; //Disables button after click
		ans2.interactable = false; //Disables button after click
		ans3.interactable = false; //Disables button after click
		ans4.interactable = false; //Disables button after click
	}

}
