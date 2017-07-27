using System;
using static System.Console;
using static System.Array;
using System.Linq;
using System.Collections;

namespace ICollectionFullImplementation
{
    class Program
    {
        // collection
        public static Student students = new Postgraduate();

        // main 
        static void Main(string[] args)
        {
            // Address object
            Address a = new Address("54", "Elm Street", "Bettystown", "County Dublin");

            // ICollection add method
            try
            {
                students.Add(new Postgraduate("11457687", false, "Poddy Jackson", DateTime.Parse("1978.03.02"), "1023456TH", "pod@test.org", a, 3));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            // Address object
            Address b = new Address("23", "Pork Street", "Jerrystown", "County Cork");

            // ICollection add method
            try
            {
                students.Add(new Postgraduate("10345672", false, "jeremy Davids", DateTime.Parse("1990.03.02"), "10765456JH", "jermey@test.org", b, 0));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            // convert students collection to an array
            Student[] studentsArray = students.ToArray();

            // sort the array - this implicitly invokes IComparable<Student> CompareTo method
            Sort(studentsArray);

            // create another array to copy to
            Array newArray = CreateInstance(typeof(Student), studentsArray.Length);

            // ICollection invoking the copyto method
            try
            {
                Copy(studentsArray, newArray, studentsArray.Length);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            // iterate  through new array with an enumerator with ICollection GetEnumerator
            Console.ForegroundColor = ConsoleColor.Green;
            IEnumerator enumerator = newArray.GetEnumerator();

            while (enumerator.MoveNext())
            {
                WriteLine(enumerator.Current);
                WriteLine();
            }

            // give collection count
            WriteLine($"Student count: {students.Count}");
            WriteLine();

            WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            WriteLine(@"After contains method");

            //  find student by id
            try
            {
                students.Contains("11457687");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            

            // remove student by id
            try
            {
                students.Remove("11457687");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteLine(@"After remove method");

            // iterate  through collection with ICollection GetEnumerator
            IEnumerator newEnumerator = students.GetEnumerator();

            while (newEnumerator.MoveNext())
            {
                WriteLine(newEnumerator.Current);
                WriteLine();
            }

            // hold
            ReadLine();
        }
    }
}
