using System;

abstract class Person
{
    protected string name;
    protected DateTime dob;
    protected string gender;
    protected string address;
    protected string contact;

    public Person(string name, DateTime dob, string gender, string address, string contact)
    {
        this.name = name;
        this.dob = dob;
        this.gender = gender;
        this.address = address;
        this.contact = contact;
    }

    public int AgeCalculate()
    {
        int age = DateTime.Now.Year - dob.Year;
        if (DateTime.Now.DayOfYear < dob.DayOfYear)
            age--;

        return age;
    }

    public abstract void Accept();

    public abstract void Display();
}

class Student : Person
{
    private string rollNo;
    private string gradeNumber;
    private int mark1;
    private int mark2;
    private int mark3;
    private int totalMarks;
    private double averageMarks;
    private string result;

    public Student(string name, DateTime dob, string gender, string address, string contact,
                   string rollNo, string gradeNumber, int mark1, int mark2, int mark3)
        : base(name, dob, gender, address, contact)
    {
        this.rollNo = rollNo;
        this.gradeNumber = gradeNumber;
        this.mark1 = mark1;
        this.mark2 = mark2;
        this.mark3 = mark3;
        this.totalMarks = CalculateTotalMarks();
        this.averageMarks = CalculateAverageMarks();
        this.result = CalculateResult();
    }

    public override void Accept()
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
        contact = Console.ReadLine();

        Console.Write("Roll No: ");
        rollNo = Console.ReadLine();

        Console.Write("Grade Number: ");
        gradeNumber = Console.ReadLine();

        Console.Write("Enter Mark 1: ");
        mark1 = Convert.ToInt32(Console.ReadLine());


        Console.Write("Enter Mark2: ");
        mark2 = Convert.ToInt32(Console.ReadLine());


        Console.Write("Enter Mark 3: ");
        mark3 = Convert.ToInt32(Console.ReadLine());

        totalMarks = CalculateTotalMarks();
        averageMarks = CalculateAverageMarks();
        result = Convert.ToString(CalculateResult());
    }

    public override void Display()
    {
        Console.WriteLine("Student Details:");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Date of Birth: " + dob.ToString("yyyy-MM-dd"));
        Console.WriteLine("Gender: " + gender);
        Console.WriteLine("Address: " + address);
        Console.WriteLine("Contact Number: " + contact);
        Console.WriteLine("Roll No: " + rollNo);
        Console.WriteLine("Grade Number: " + gradeNumber);
        Console.WriteLine("Total Marks: " + totalMarks);
        Console.WriteLine("Average Marks: " + averageMarks);
        Console.WriteLine("Result: " + result);
    }

    private int CalculateTotalMarks()
    {
       
       int  total = mark1 + mark2 + mark3;
        return total;
    }

    private double CalculateAverageMarks()
    {
        return totalMarks / 3;


    }

    private string CalculateResult()
    {
        if (averageMarks > 40)
            return "Pass";
        else
            return "fail";

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Student Details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dobInput))
            {
                DateTime dob = dobInput;

                Console.Write("Gender: ");
                string gender = Console.ReadLine();

                Console.Write("Address: ");
                string address = Console.ReadLine();

                Console.Write("Contact Number: ");
                string contact = Console.ReadLine();

                Console.Write("Roll No: ");
                string rollNo = Console.ReadLine();

                Console.Write("Grade Number: ");
                string gradeNumber = Console.ReadLine();
                Console.Write("Enter Mark 1: ");
                int mark1 = Convert.ToInt32(Console.ReadLine());


                Console.Write("Enter Mark2: ");
                int mark2 = Convert.ToInt32(Console.ReadLine());


                Console.Write("Enter Mark 3: ");
                int mark3 = Convert.ToInt32(Console.ReadLine());



                Student student1 = new Student(
                name: name,
                dob: dob,
                gender: gender,
                address: address,
                contact: contact,
                rollNo: rollNo,
                gradeNumber: gradeNumber,
                mark1: mark1,
                mark2: mark2, 
                mark3: mark3

            );
                student1.Accept();
                student1.Display();

                int age = student1.AgeCalculate();
                Console.WriteLine("Age: " + age);
            }
            else
            {
                Console.WriteLine("Invalid date format");
            }
        }
    }
}