public class Quiz
{
    private string? img;
    private int difficulty;
    private List<string> tags = new List<string>();
    List<Question>? questions;
    public void addQuestion(string ask, List<string> answers)
    {
        Question question = new Question(ask, answers);
    }   
    public void setImg(string img)
    {
        this.img = img;
    }
    public void addTag(string tag)
    {
        this.tags.Add(tag);
    }
    public void setDificulty(int difficulty)
    {
        this.difficulty = difficulty;
    }

    public List<Question>? getQuestions()
    {
        return this.questions;
    }
    public string? getImg()
    {
        return this.img;
    }
    public List<string> getTag()
    {
        return this.tags;
    }
    public int getDificulty()
    {
        return this.difficulty;
    }
}

public class Question 
{
    string ask;
    List<string> answers = new List<string>();
    public Question(string ask, List<string> answers)
    {
        this.ask = ask;
        this.answers = answers;
    }
}