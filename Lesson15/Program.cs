using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
//using System.Collections.Generic;

namespace Lesson15
{
    class Program
    {
        static void Main(string[] args)
        {
            #region      Generics, implement Array role
            //GenericList<int> integerCollection = new GenericList<int>(4);
            //integerCollection.Add(1);
            //integerCollection.Add(2);
            //integerCollection.Add(4);
            //integerCollection.Add(-67);

            //for (int i = 0; i < integerCollection.Count; i++)
            //{
            //    Console.WriteLine(integerCollection[i]);
            //}

            //GenericList<Person> personList = new GenericList<Person>(3);
            //personList.Add(new Person { FirstName = "Gorkhmaz", LastName = "Maharramov" });
            //personList.Add(new Person { FirstName = "Nizami", LastName = "EliMemmeedov" });
            //personList.Add(new Person { FirstName = "Perviz", LastName = "Namazli" });

            //for (int i = 0; i < personList.Count; i++)
            //{
            //    Console.WriteLine(personList[i].FirstName + " " + personList[i].LastName);
            //}



            //GenericList<string> stringCollection = new GenericList<string>(5);
            //stringCollection.Add("text");
            //stringCollection.Add("metin");
            //stringCollection.Add("string");
            //stringCollection.Add("c#");
            //stringCollection.Add("java");

            #endregion

            #region      Generic base, class interface implemenetation

            //StudentDataAccess std = new StudentDataAccess();
            //std.Add(new StudentModel { FirstName = "Gorkhmaz", LastName = "Maharramov" });
            //std.Add(new StudentModel { FirstName = "Nizami", LastName = "EliMemmedov" });
            //std.Add(new StudentModel { FirstName = "Perviz", LastName = "Namazli" });

            //std.Remove(new StudentModel { FirstName = "Gorkhmaz" });
            //std.Update(new StudentModel { FirstName = "Nizami" });

            #endregion   Generic base, class interface implemenetation

            #region     Methods generics

            //StudentModel[] studenArray = new StudentModel[3]
            //{
            //    new StudentModel
            //    {
            //        FirstName = "Gorkhmaz",
            //        LastName = "Maharramov"
            //    },
            //    new StudentModel
            //    {
            //        FirstName = "Nizami",
            //        LastName = "EliMemmedov"
            //    },
            //    new StudentModel
            //    {
            //        FirstName = "Perviz",
            //        LastName = "Namazli"
            //    }
            //};

            //studenArray.GetElementsPrint();

            #endregion


            Console.ReadKey();
        }
    }

    #region      Generic base, class interface implementation
    public interface IOperation
    {
        string OperationName { get; }
    }


    public interface IDataStrategyRepository<Tinput>
    {
        void Add(Tinput model);

        void Remove(Tinput model);

        void Update(Tinput model);

        Tinput GetTableRow(int Id);

        IList<Tinput> GetTableRows();
    }

    internal abstract class BaseDataStrategyRepository<Tinput> : IDataStrategyRepository<Tinput>
                                                      where Tinput : class, new()
    {

        public virtual void Add(Tinput model)
        {
            Console.WriteLine(model.ToString() + " inserted ");
        }

        public virtual void Remove(Tinput input)
        {
            Console.WriteLine(input.ToString() + " removed");
        }

        public virtual void Update(Tinput model)
        {
            Console.WriteLine(model.ToString() + " updated");
        }


        public virtual Tinput GetTableRow(int Id)
        {
            return new Tinput();
        }

        public virtual IList<Tinput> GetTableRows()
        {
            return new List<Tinput>();
        }

    }


    public interface IStudentRepository : IDataStrategyRepository<StudentModel>
    {

    }

    public class StudentModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.Id;
        }
    }

    internal class StudentDataAccess : BaseDataStrategyRepository<StudentModel>, IStudentRepository
    {

    }
    #endregion

    #region    Generics
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }


    public class GenericList<T>
    /* <T> */
    {
        private T[] array;
        private int index;
        private int Capacity;


        public GenericList(int capacity)
        {
            array = new T[capacity];
            Capacity = capacity;
        }


        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Capacity)
                {
                    throw new Exception("Array ölçüsündən böyük index mövcud deyil");
                }

                return array[index];
            }
        }

        public void Add(T input)
        {
            array[index++] = input;
        }

        public void Remove(T removeElement)
        {
            var index = Array.IndexOf(array, removeElement);

            if (index != -1)
            {
                Array.Copy(array, index, array, index + 1, array.Length);
                Capacity--;
            }
        }


        public int Count
        {
            get
            {
                return this.Capacity;
            }
        }
    }
    #endregion

    #region    Mehtod generic

    public static class Printer
    {
        public static void GetElementsPrint<Tinput>(this ICollection<Tinput> sourceArray) where Tinput : class
        {
            foreach (var item in sourceArray)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
    #endregion


}
