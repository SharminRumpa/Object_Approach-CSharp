using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Object
{
    abstract class Department
    {
        protected int DepartmentID { get; set; }
        protected string DepartmentName { get; set; }
    }

    interface IBookList
    {
        string listOfBook(String bookName);
    }

  
    sealed class Subject : Department, IBookList
    {
        public Subject(int DepartmentID, string DepartmentName)
        {
            this.DepartmentID = DepartmentID;
            this.DepartmentName = DepartmentName;
        }

        string IBookList.listOfBook(String bookName)
        {
            return bookName;
        }

        public string SubjectName { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string ISBN { get; set; }

        public string PublicationName { get; set; }

        public string PublishDate { get; set; }

        public override string ToString()
        {
            return $"ID : {this.DepartmentID}, \nDepartment : {this.DepartmentName}, \nBookName : {this.BookName}, \nAuthorName : {this.AuthorName}, " +
                $"\nISBN : {this.ISBN}, \nPublication : {this.PublicationName}, \nPublishDate : {this.PublishDate}";
        }
    }
    class Program
    {
        enum Department
        {
            Arts , Science, BusinessStudies  
        }

        enum SubjectList
        {
            Physics, Bengali, English, Management, Marketing, Chemistry
        }

        enum BooksList
        {
            Mrityukshuda, Ratri_Shesh, Noukadubi, The_Bluest_Eye, Theretical_Concept_in_physics,
            Financial_Management, Principal_of_Management, You_never_can_tell, Organic_Chemistry
        }

        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            Console.WriteLine("\nEnter Department ID Please(Must be int)...");
            int ID = Convert.ToInt32(Console.ReadLine().ToString());

            Console.WriteLine("\nAvailable Department");
            var enumList = Enum.GetNames(typeof(Department));

            foreach(var d in enumList)
            {
                Console.WriteLine(d);
            }

            
            Console.WriteLine("\nEnter DepartmentName ...");
            string Department = Console.ReadLine();

            Console.WriteLine("\nAvailable Subjects");
            var enumList1 = Enum.GetNames(typeof(SubjectList));

            foreach (var s in enumList1)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nEnter Subject Name...");
            string SubjectName = Console.ReadLine();

            Console.WriteLine("\nAvailable Books");
            var enumList2 = Enum.GetNames(typeof(BooksList));

            foreach (var s in enumList2)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nEnter BookName...");
            Subject subject = new Subject(ID, Department);
            string BookName = Console.ReadLine();
            subject.BookName = BookName;

            List<string> bookList = new List<string>();
            IBookList ibl = (IBookList)subject;
            bookList.Add(ibl.listOfBook(BookName));

          

            Console.WriteLine("\nEnter AuthorName...");
            subject.AuthorName = Console.ReadLine();

            Console.WriteLine("\nEnter ISBN...");
            subject.ISBN = Console.ReadLine();

            Console.WriteLine("\nEnter PublicationName...");
            subject.PublicationName = Console.ReadLine();

            Console.WriteLine("\nEnter PublishDate...");
            subject.PublishDate = Console.ReadLine();

            Console.WriteLine("\nDetails Information is below");
            Console.WriteLine(subject.ToString());

            Console.WriteLine("\nEnter Book Name ...");
            string Book_Name = Console.ReadLine();

           

          

            bool yesProceed = true;
            while (yesProceed)
            {
                Console.WriteLine("More Book ? Yes Or No");
                string YesNoInput = Console.ReadLine();
                if (YesNoInput.ToUpper() == "Yes".ToUpper())
                {
                    Console.WriteLine("\nBook Name:");
                     Book_Name = Console.ReadLine();

                    bookList.Add(ibl.listOfBook(Book_Name));

                }
                else
                {
                    yesProceed = false;
                }

            }
            Console.WriteLine("You have the following Books:");
            

            foreach (var s in bookList)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nThank you");

            Console.ReadLine();




        }
    }
}
