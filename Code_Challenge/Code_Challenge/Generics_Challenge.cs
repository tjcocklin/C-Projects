using System;
using System.Collections.Generic;
using System.Reflection;
namespace Code_Challenge
{

    public class University_Staff
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public University_Staff(string name, string title)
        {
            this.Name = name;
            this.Title = title;
        }
        public override string ToString()
        {
            return string.Format("Name: {0} Title: {1}", Name, Title);
        }

    }
    public class Medical_Staff
    {
        public string Title { get; set; }
        public string Name { get; set; }

        public Medical_Staff(string name, string title)
        {
            this.Name = name;
            this.Title = title;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Title: {1}", Name, Title);
        }
    }

    public class Animal
    {
        public string Name { get; set; }
        public Animal(string name){ this.Name = name;}
        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }
    }
    public class Answer
    {
                
        /// <summary>
        /// Method prints the contents of a list to the console.
        /// </summary>
        /// 
        /// <param name="list">
        /// The target list to be printed.
        /// </param>
        public static void PrintList(List<Object> list)
        {
                        
            for (int i = 0; i < list.Count; i++)
                Console.Write("{0}, ", list[i]);

            Console.WriteLine();
        }
        /// <summary>
        ///  A method for the "Generics Challenge Goal".
        ///  Method takes in two lists of Objects and intermixes the 
        ///  two lists, alternating from the larger of the two lists
        ///  to the smaller of the two list.
        ///  If Both lists are of equal size param "list1",
        ///  is treated as the larger list.
        /// </summary>
        /// <param name="list1">
        ///  The first list of Objects.
        /// </param>
        /// <param name="list2"> 
        ///  The second list of Objects.
        /// </param>
        /// <returns>
        ///  A new list consisting of Objects from list1 and list2.
        ///  If both lists are empty the method returns a pointer to
        ///  an empty Object list.
        ///  
        /// </returns>
        public static List<Object> InterMixList( List<Object> list1, List<Object> list2 )
        {
            List<Object> toReturn = new List<Object>();

            int indexOfList1 = 0;
            int indexOfList2 = 0;

            if(list1.Count >= list2.Count)
            {
                while( indexOfList1 < list1.Count && indexOfList2 < list2.Count)
                {
                    toReturn.Add(list1[indexOfList1]);
                    toReturn.Add(list2[indexOfList2]);

                    indexOfList1++;
                    indexOfList2++;
                }
            }
            else
            {
                while (indexOfList1 < list1.Count && indexOfList2 < list2.Count)
                {
                    toReturn.Add(list2[indexOfList2]);
                    toReturn.Add(list1[indexOfList1]);

                    indexOfList1++;
                    indexOfList2++;
                }
            }

            while(indexOfList1 < list1.Count)
            {
                toReturn.Add(list1[indexOfList1]);
                indexOfList1++;
            }

            while (indexOfList2 < list2.Count)
            {
                toReturn.Add(list2[indexOfList2]);
                indexOfList2++;
            }

            return toReturn;
        } 
        
        /// <summary>
        /// A method for the "Generics challenge Bonus".
        /// Determines which object contains the longer "Title"
        /// Property. If an object doesn't contain the "Title"
        /// Property, its "Title" length is zero.
        /// </summary>
        /// <param name="thing1"> 
        /// The first object to evaluated
        /// </param>
        /// <param name="thing2"> 
        /// The seond object to be evaluated
        /// </param>
        /// <returns>
        /// A pointer to the object containing the longer "Title" 
        /// Property.
        /// If neither object contains the property "Title"
        /// an object pointer to null is returned.
        /// If both objects have a "Title" property of the same
        /// length, an object pointer to null is returned.
        /// 
        /// </returns>
        public static Object LongerTitle(Object thing1, Object thing2)
        {
            string thing1Title;
            string thing2Title;

            int thing1TitleLength=0;
            int thing2Titlelength=0;

            Object toReturn = null;

            try
            {
                 

                var thing1Property = thing1.GetType().GetProperty("Title");
                var thing2Property = thing2.GetType().GetProperty("Title");
                
                if (thing1Property != null)
                {
                    
                    thing1Title = (string)thing1Property.GetValue(thing1, null); ;
                    thing1TitleLength = thing1Title.Length;
                }
                                       
                   
                if (thing2Property != null)
                {
                    thing2Title = (string)thing2Property.GetValue(thing2, null); 
                    thing2Titlelength = thing2Title.Length; 
                }
                

                if (thing1TitleLength > thing2Titlelength)
                    toReturn= thing1;
                else if (thing2Titlelength > thing1TitleLength)
                    toReturn = thing2;
                
               
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


        /// <summary>
        /// Driver for the Answer class
        /// </summary>
        
        static void Main()
        {

            List<Object> listOfInt1 = new List<Object>() { 1, 2, 3, 4, 5 };
            List<Object> listOfInt2 = new List<Object>() { 6, 7, 8, 9, 10, 11 };

            List<Object> listOfString1 = new List<Object>() { "Bob", "kerry", "Fisher","Ken" };
            List<Object> listOfString2 = new List<Object>() { "Jim", "Harvey", "Swanson" };


            Console.WriteLine("listOfInt1: ");
            PrintList(listOfInt1);

            Console.WriteLine("\nlistOfInt2: ");
            PrintList(listOfInt2);

            Console.WriteLine("\nlistOfString1");
            PrintList(listOfString1);

            Console.WriteLine("\nlistOfString2 ");
            PrintList(listOfString2);

            Console.WriteLine("\nTesting InterMixList for listOfInt1 and listofInt2");
            PrintList(InterMixList(listOfInt1,listOfInt2));

            Console.WriteLine("\nTesting InterMixList for listOfString1 and listOfString2");
            PrintList(InterMixList(listOfString1, listOfString2));

            Console.WriteLine("\nTesting InterMixList for listOfString2 and listOfInt1");
            PrintList(InterMixList(listOfString2, listOfInt1));

            Console.WriteLine("\nTesting InterMixList for listOfString2 and listOfInt2");
            PrintList(InterMixList(listOfString2, listOfInt2));

            Console.WriteLine("\nTesting InterMixList for listOfString1 and listOfInt1");
            PrintList(InterMixList(listOfString1, listOfInt1));

            Console.WriteLine("\nTesting InterMixList for listOfString1 and listOfInt2");
            PrintList(InterMixList(listOfString1, listOfInt2));
            

            

            University_Staff person1 = new University_Staff("Glen Underwood", "Professor");
            Medical_Staff person2 = new Medical_Staff("Bill Sherpard", "Surgeon");
            Animal canine = new Animal("Pepper");

            Console.WriteLine("\n\nperson1: {0}",person1.ToString());
            Console.WriteLine("\nperson2: {0}", person2.ToString());
            Console.WriteLine("\ncanine: {0}", canine.ToString());



            Console.WriteLine("\nTesting LongerTitle for person1 and " +
                              "person2");
                        
            Console.WriteLine(LongerTitle(person1, person2).ToString());


            Console.WriteLine("\nTesting LongerTitle for person1 and " +
                              "canine");

            Console.WriteLine(LongerTitle(person1, canine).ToString());


            Console.WriteLine("\nTesting LongerTitle for person2 and " +
                              "canine");

            Console.WriteLine(LongerTitle(person2, canine).ToString());


            Console.WriteLine("Press any char key to exit the program");
            Console.ReadKey();


        }


    }
}
