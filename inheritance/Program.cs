using System;

public class Person
{
    public int Contactno;
    public string name;
    public string address;
    public string gender;
    public string dateofbirth;

    public Person(int Cn, string n, string ad, string gen, string dob)
    {
        Contactno = Cn;
        name = n;
        address = ad;
        gender = gen;
        dateofbirth = dob;
    }

    public virtual void  display()
    {
        Console.WriteLine("Person Name: " + name);
        Console.WriteLine("Address: " + address);
        Console.WriteLine("Date of Birth: " + dateofbirth);
        Console.WriteLine("Gender: " + gender);
        Console.WriteLine("Contact Number: " + Contactno);
    }
}

class Student : Person
{
    public int rollno;
    public int grade;
    public float mark1;
    public float mark2;
    public float mark3;
    public float total;
    public float average;
    public string result;

    public Student(int Cn, string n, string ad, string gen, string dob, int rn, int gr, float m1, float m2, float m3)
        : base(Cn, n, ad, gen, dob)
    {
        rollno = rn;
        grade = gr;
        mark1 = m1;
        mark2 = m2;
        mark3 = m3;
    }

    public void accept()
    {
        total = mark1 + mark2 + mark3;
        average = total / 3;

        if (average >= 40)
        {
            result = "Passed";
        }
        else
        {
            result = "Failed";
        }
    }

    public override void display()
    {
        base.display();
        Console.WriteLine("Roll no: " + rollno);
        Console.WriteLine("Grade: " + grade);
        Console.WriteLine("Mark 1: " + mark1);
        Console.WriteLine("Mark 2: " + mark2);
        Console.WriteLine("Mark 3: " + mark3);
        Console.WriteLine("Total: " + total);
        Console.WriteLine("Result: " + result);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Student s1 = new Student(994, "yamini", "12 , classic residency , vsk nagar , cbe", "female", "11 october 2002", 101, 7, 90, 90, 90);
        s1.accept();
        s1.display();
    }
}
