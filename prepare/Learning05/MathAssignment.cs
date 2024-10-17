public class MathAssignment : Assignment
{
    private string _section;
    private string _problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string section, string problems) : base(studentName, topic)
    {
        _section = section; // Set specific variables
        _problems = problems;
    }

    // Here get homework list
    public string GetHomeworkList()
    {
        return $"Section {_section} Problems {_problems}";
    }
}