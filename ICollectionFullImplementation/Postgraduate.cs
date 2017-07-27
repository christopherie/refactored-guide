using System;
using static System.Console;
using System.Collections.Generic;

namespace ICollectionFullImplementation
{
    public class Postgraduate : Student
    {
        // Postgraduate class properties
        protected int Credits { get; set; }
        protected decimal CreditValue => 200M;

        // default constructor
        public Postgraduate() {}

        // constructor
        public Postgraduate(string studentID, bool underOrpost, string fullName, DateTime birth,
            string social, string mail, Address postal, int creditAmt) 
            : base(studentID, underOrpost, fullName, birth, social, mail, postal)
        {
            Credits = creditAmt;
        }

        // return postgraduate date
        public override string ToString() => base.ToString() + $"Credits: {Credits}\nFee After Credits: {CalculateFeesAfterCredits():C}";

        // calculate fees for postgraduate with credits
        public decimal CalculateFeesAfterCredits()
        {
            decimal total = 0M;
            if (Credits > 0)
            {
                total = base.CalculateCourseFee() - Decimal.Multiply(Credits, CreditValue);
            }
            return total;
        }

        // ICollection properties
        public override int Count => StudentList.Count;
        public override bool IsReadOnly => false;
        public override List<Student> StudentList { get; } = new List<Student>();

        // ICollection add item
        public override void Add(Student item)
        {
            if (!StudentList.Contains(item))
            {
                StudentList.Add(item);
            }
        }

        // ICollection clear collection
        public override void Clear() => StudentList.Clear();

        // ICollection check if collection contains an item
        public override bool Contains(Student item)
        {
            bool found = false;
            foreach (Student student in StudentList)
            {
                if (student.Equals(item))
                {
                    found = true;
                }
            }
            return found;
        }

        // ICollection copy collection to an array
        public override void CopyTo(Student[] array, int arrayIndex)
        {
            // array can't be null
            if (array == null)
            {
                throw new ArgumentNullException(message: "Array can't be null.", paramName: nameof(array));
            }

            // start index can't be negative
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(message: "Starting array index can't be negative", paramName: nameof(array));
            }

            // destination array can't have fewer elements than collection
            if (StudentList.Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentOutOfRangeException(message: "Destination array has fewer elements than collection", paramName: nameof(array));
            }

            // all good
            for (int i = 0; i < StudentList.Count; i++)
            {
                array[i + arrayIndex] = StudentList[i];
            }
        }

        // ICollection for looping through collection
        public override IEnumerator<Student> GetEnumerator() => StudentList.GetEnumerator();

        // ICollection remove an item from collection
        public override bool Remove(Student item)
        {
            bool found = false;
            for (int i = 0; i < StudentList.Count; i++)
            {
                Student current = (Postgraduate)StudentList[i];
                if (current.Equals(item))
                {
                    found = true;
                    StudentList.RemoveAt(i);
                    break;
                }
            }
            return found;
        }

        // ICollection custom method to search by student id
        internal override void Contains(string v)
        {
            for (int i = 0; i < StudentList.Count; i++)
            {
                if (StudentList[i].ID == v)
                {
                    WriteLine(StudentList[i]);
                    WriteLine();
                    break;
                }
                else
                {
                    throw new ArgumentException(message: "ID not found");
                }
            }
        }

        // ICollection custom method to remove student using id
        internal override void Remove(string v)
        {
            for (int i = 0; i < StudentList.Count; i++)
            {
                if (StudentList[i].ID == v)
                {
                    StudentList.Remove(StudentList[i]);
                    WriteLine("Student removed");
                    break;
                }
                else
                {
                    throw new ArgumentException(message: "ID not found");
                }
            }
        }
    }
}
