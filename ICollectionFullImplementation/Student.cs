using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ICollectionFullImplementation
{
    public abstract class Student : IComparable<Student>, ICollection<Student>
    {
        // student class properties
        public string ID { get; set; }
        public string Name { get; set; }
        protected DateTime DOB { get; set; }
        protected string PPSN { get; set; }
        protected string Email { get; set; }
        protected Address PostalAddress { get; set; }
        protected bool Status { get; set; }
        protected decimal UndergraduateFee => 12000M;
        protected decimal PostgraduateFee => 15000M;

        // default constructor
        public Student() {}

        // student class constructor
        public Student(string studentID, bool underOrpost, string fullName, DateTime birth, string social, string mail, Address postal)
        {
            ID = studentID;
            Status = underOrpost;
            Name = fullName;
            DOB = birth;
            PPSN = social;
            Email = mail;
            PostalAddress = postal;
        }

        // return student data
        public override string ToString()
        {
            string studentStatus = String.Format("{0}", Status == true ? "Undergraduate" : "Postgraduate");
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"Student ID: {ID}");
            buffer.AppendLine($"Status: {studentStatus}");
            buffer.AppendLine($"Name: {Name}");
            buffer.AppendLine($"Date of birth: {DOB.ToShortDateString()}");
            buffer.AppendLine($"PPSN: {PPSN}");
            buffer.AppendLine($"Email: {Email}");
            buffer.AppendLine($"Address: {PostalAddress}");
            buffer.AppendLine($"Fees: {CalculateCourseFee():C}");
            return buffer.ToString();
        }

        // calculate fees for year
        public decimal CalculateCourseFee()
        {
            decimal fee = 0M;
            if (Status == true)
            {
                // fee for undergraduate
                fee = Decimal.Multiply(4, UndergraduateFee);
            }
            else if (Status == false)
            {
                // fee for postgraduate
                fee = Decimal.Multiply(2, PostgraduateFee);
            }
            return fee;
        }

        // ICollection abstract properties
        public abstract List<Student> StudentList { get; }
        public abstract int Count { get; }
        public abstract bool IsReadOnly { get; }

        // ICollection abstract methods
        public abstract void Add(Student item);
        public abstract void Clear();
        public abstract bool Contains(Student item);
        public abstract void CopyTo(Student[] array, int arrayIndex);
        public abstract IEnumerator<Student> GetEnumerator();
        public abstract bool Remove(Student item);
        IEnumerator IEnumerable.GetEnumerator() => StudentList.GetEnumerator();
        internal abstract void Contains(string v);
        internal abstract void Remove(string v);

        // IComparable to compare by student id
        public int CompareTo(Student other) => ID.CompareTo(other.ID);
    }
}
