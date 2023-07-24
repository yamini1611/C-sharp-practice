using System;

interface Input
{
    void Accept();
}

interface Output
{
    void Display();
}

class Person
{
    protected string name;
    protected DateTime dob;
    protected string gender;
    protected string address;
    protected long  contact;

    public Person(string name, DateTime dob, string gender, string address, long contact)
    {
        this.name = name;
        this.dob = dob;
        this.gender = gender;
        this.address = address;
        this.contact = contact;
    }
}

class Student : Person, Input, Output
{
    private string rollNo;
    private string gradeNumber;
    private int[] marks;
    private int totalMarks;
    private double averageMarks;
    private string result;
    private const int PASS_MARK = 40;

    public Student(string name, DateTime dob, string gender, string address, long contact,
                   string rollNo, string gradeNumber, int[] marks)
        : base(name, dob, gender, address, contact)
    {
        this.rollNo = rollNo;
        this.gradeNumber = gradeNumber;
        this.marks = marks;
        this.totalMarks = CalculateTotalMarks();
        this.averageMarks = CalculateAverageMarks();
        this.result = CalculateResult();
    }

    public void Accept()
    {
        Console.WriteLine("Enter Student Details:");
        Console.Write("Name: ");
        name = Console.ReadLine();

        Console.Write("Date of Birth (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dobInput))
        {
            dob = dobInput;
        }
        else
        {
            Console.WriteLine("Invalid date format. Using current date as Date of Birth.");
            dob = DateTime.Now;
        }

        Console.Write("Gender: ");
        gender = Console.ReadLine();

        Console.Write("Address: ");
        address = Console.ReadLine();

        Console.Write("Contact Number: ");
        contact = Convert.ToInt64(Console.ReadLine());

        Console.Write("Roll No: ");
        rollNo = Console.ReadLine();

        Console.Write("Grade Number: ");
        gradeNumber = Console.ReadLine();

        Console.Write("Enter Marks in Three Subjects (separated by spaces): ");
        string[] marksInput = Console.ReadLine().Split(' ');
        marks = Array.ConvertAll(marksInput, int.Parse);

        totalMarks = CalculateTotalMarks();
        averageMarks = CalculateAverageMarks();
        result = CalculateResult();
    }

    public void Display()
    {
        Console.WriteLine("Student Details:");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Date of Birth: " + dob.ToString("yyyy-MM-dd"));
        Console.WriteLine("Gender: " + gender);
        Console.WriteLine("Address: " + address);
        Console.WriteLine("Contact Number: " + contact);
        Console.WriteLine("Roll No: " + rollNo);
        Console.WriteLine("Grade Number: " + gradeNumber);
        Console.Write("Marks in Three Subjects: ");
        foreach (var mark in marks)
        {
            Console.Write(mark + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Total Marks: " + totalMarks);
        Console.WriteLine("Average Marks: " + averageMarks);
        Console.WriteLine("Result: " + result);
    }

    private int CalculateTotalMarks()
    {
        int total = 0;
        foreach (var mark in marks)
        {
            total += mark;
        }
        return total;
    }

    private double CalculateAverageMarks()
    {
        return (double)totalMarks / marks.Length;
    }

    private string CalculateResult()
    {
        foreach (var mark in marks)
        {
            if (mark < PASS_MARK)
            {
                return "FAIL";
            }
        }
        return "PASS";
    }
}


class Program
{
    static void Main(string[] args)
    {
     
        Student student1 = new Student(
            name: "",
            dob: DateTime.Now,
            gender: "",
            address: "",
            contact: new long(),
            rollNo: "",
            gradeNumber: "",
            marks: new int[3]
        );

        student1.Accept();

     
        student1.Display();
    }
}
