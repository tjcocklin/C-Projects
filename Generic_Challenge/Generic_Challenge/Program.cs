using System;
using System.Collections.Generic;
using System.Reflection;

namespace Generic_Challenge
{
    /// <summary>
    /// Class used to test Answer class methods.
    /// </summary>
    public class Uni_Staff
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public Uni_Staff(string name, string title)
        {
            this.Name = name;
            this.Title = title;
        }
        public override string ToString()
        {
            return string.Format("Name: {0} Title: {1}", Name, Title);
        }

    }
    /// <summary>
    /// Class used to test Answer class methods.
    /// </summary>
    public class Med_Staff
    {
        public string Title { get; set; }
        public string Name { get; set; }

        public Med_Staff(string name, string title)
        {
            this.Name = name;
            this.Title = title;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Title: {1}", Name, Title);
        }
    }



    public class Answer<T, U>
    {
        public List<T> List1 { get; private set; }
        public List<T> List2 { get; private set; }

        public T Obj1 { get; private set; }
        public U Obj2 { get; private set; }
        
                
        public Answer(List<T> list1, List<T> list2)
        {
            this.List1 = list1;
            this.List2 = list2;
        }

        public Answer(T obj1, U obj2)
        {
            this.Obj1 = obj1;
            this.Obj2 = obj2;
        }
        /// <summary>
        /// Prints the contents of Generic Lists of tye T
        /// to the console.
        /// </summary>
        /// <param name="list">
        /// The List to be printed.
        /// </param>
        public void PrintList(List<T> list)
        {

            for (int i = 0; i < list.Count; i++)
                Console.Write("{0}, ", list[i]);

            Console.WriteLine();
        }
        /// <summary>
        ///  A method for the "Generics Challenge Goal".
        ///  Method takes in two lists of type T Objects and intermixes the 
        ///  two lists, alternating from the larger of the two lists
        ///  to the smaller of the two list.
        ///  If Both lists are of equal size param "list1",
        ///  is treated as the larger list.
        /// </summary>
        /// 
        /// <returns>
        ///  A new list of Type T consisting of Objects from list1 and list2.
        ///  If both lists are empty the method returns a pointer to
        ///  an empty Object list.
        ///  
        /// </returns>
        public List<T> InterMixList()
        {
            List<T> toReturn = new List<T>();
            int indexList1 = 0;
            int indexList2 = 0;

            if (this.List1.Count > this.List2.Count)
            {
                while (indexList1 < this.List1.Count && indexList2 < this.List2.Count)
                {
                    toReturn.Add(this.List1[indexList1]);
                    toReturn.Add(this.List2[indexList2]);

                    indexList1++;
                    indexList2++;
                }
            }
            else
            {
                while (indexList2 < this.List2.Count && indexList1 < this.List1.Count)
                {
                    toReturn.Add(this.List2[indexList2]);
                    toReturn.Add(this.List1[indexList1]);

                    indexList2++;
                    indexList1++;
                }
            }

            while (indexList1 < this.List1.Count)
            {
                toReturn.Add(this.List1[indexList1]);
                indexList1++;
            }
            while (indexList2 < this.List2.Count)
            {
                toReturn.Add(this.List2[indexList2]);
                indexList2++;
            }

            return toReturn;
        }
        /// <summary>
        /// A method for the "Generics challenge Bonus".
        /// Determines which object contains the longer "Title"
        /// Property. If an object doesn't contain the "Title"
        /// Property, its "Title" length is zero.
        /// </summary>
        /// 
        /// <returns>
        /// A pointer to the object containing the longer "Title" 
        /// Property.
        /// If neither object contains the property "Title"
        /// an object pointer to null is returned.
        /// If both objects have a "Title" property of the same
        /// length, an object pointer to null is returned.
        /// 
        /// </returns>

        public Object LongerTitle()
        {
            Object toReturn = null;
            string obj1Title;
            string obj2Title;

            int obj1TitleLength = 0;
            int obj2TitleLength = 0;

            try
            {

                var obj1Property = this.Obj1.GetType().GetProperty("Title");
                var obj2Property = this.Obj2.GetType().GetProperty("Title");

                if (obj1Property != null)
                {

                    obj1Title = (string)obj1Property.GetValue(this.Obj1, null);
                    obj1TitleLength = obj1Title.Length;
                }


                if (obj2Property != null)
                {
                    obj2Title = (string)obj2Property.GetValue(this.Obj2, null);
                    obj2TitleLength = obj2Title.Length;
                }


                if (obj1TitleLength >= obj2TitleLength)
                    toReturn = this.Obj1;
                else if (obj2TitleLength > obj1TitleLength)
                    toReturn = this.Obj2;


            }
            catch (Exception e)
            {
                Console.WriteLine("whoops something went awry error: {0}. " +
                                  "Press any char key to exit.", e.Message);
                Console.ReadKey();
                Environment.Exit(1);

            }
            return toReturn;
        }
    }
    /// <summary>
    /// Class responsible for testing the Answer class
    /// </summary>
    public class Driver
    {
               
        static void Main()
        {
            List<int> listOfInt1 =
                new List<int>() { 1, 2, 3, 4, 5 };
            List<int> listOfInt2 =
                new List<int>() { 6, 7, 8, 9, 10, 11 };

            List<string> listOfString1 =
                new List<string>() { "Bob", "kerry", "Fisher", "Ken" };
            List<string> listOfString2 =
                new List<string>() { "Jim", "Harvey", "Swanson" };

            Answer<int, int> numberLists =
                new Answer<int, int>(listOfInt1, listOfInt2);

            Answer<string, string> stringLists =
                new Answer<string, string>(listOfString1, listOfString2);


            Console.WriteLine("listOfInt1: ");
            numberLists.PrintList(numberLists.List1);


            Console.WriteLine("\nlistofInt2: ");
            numberLists.PrintList(numberLists.List2);

            Console.WriteLine("\nTesting InterMixList on listOfInt1" +
                              " and listOfInt2");

            
            numberLists.PrintList(numberLists.InterMixList());

            Console.WriteLine("\n\nlistOfString1: ");
            stringLists.PrintList(stringLists.List1);

            Console.WriteLine("\nlistOfString2: ");
            stringLists.PrintList(stringLists.List2);

            Console.WriteLine("\nTesting InterMixList on listOfString1" +
                              " and listOfString2");

            stringLists.PrintList(stringLists.InterMixList());


            Uni_Staff person1 = new Uni_Staff("Glen Underwood", "Professor");
            Med_Staff person2 = new Med_Staff("Bill Sherpard", "Surgeon");

            Answer<Uni_Staff, Med_Staff> titleComparison =
                        new Answer<Uni_Staff, Med_Staff>(person1, person2);

            Console.WriteLine("\n\nperson1 of type Uni_Staff: " + person1.ToString());
            Console.WriteLine("\nperson2 of type Med_Staff: " + person2.ToString());

            Console.WriteLine("\nTesting LongerTitle, {0} has the " +
                  "longer title", titleComparison.LongerTitle().ToString());

            Console.WriteLine("\nPress any char key to exit the program");
            Console.ReadKey();

        }
    }
    
}
