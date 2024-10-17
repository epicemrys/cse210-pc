public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    // Method to get writing information
    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }

    // Method set to public to gets the student's name from the base class.
    public string GetStudentName()
    {
        return _studentName;
    }
}