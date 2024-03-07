using System;
using System.Collections.Generic;
using CSharpConsole.Samples.Class;
using CSharpConsole.Samples.Class.Inheritance;

namespace CSharpConsole.Samples.Types
{
    public interface IGenericSample<T>
    {
        T GenericProperty { get; set; }
        T CreateObject();
        void Print(T obj);
    }
    
    public interface IGenericPlane<T> : IGenericSample<T> where T : AbstractPlane
    {
        IList<T> ConcatenatePlanes<TV>(TV collection, T plane) where TV : ICollection<T>;
    }

    public class GenericSample<T> : IGenericSample<T>
    {
        public GenericSample()
        {
            //default constructor
            Console.WriteLine(typeof(T));
        }

        public GenericSample(T obj)
        {
            Console.WriteLine(obj.GetType());
        }

        public T GenericProperty { get; set; }

        public T CreateObject()
        {
            //return new T(); // need constraint new()
            return default(T);
        }

        public void Print(T obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
    
    public class GenericPlaneSample<T> : IGenericPlane<T> where T : AbstractPlane
    {
        public GenericPlaneSample()
        {
            //default constructor
            Console.WriteLine(typeof(T));
        }

        public GenericPlaneSample(T obj)
        {
            Console.WriteLine(obj.GetType());
        }

        public T GenericProperty { get; set; }

        public T CreateObject()
        {
            var plane = default(T);
            plane?.TakeOff();
            return plane;
        }

        public void Print(T obj)
        {
            Console.WriteLine(obj.ToString());
        }

        public IList<T> ConcatenatePlanes<TV>(TV collection, T plane) where TV : ICollection<T>
        {
            if (collection is IList<T> list)
            {
                list.Add(plane);
                return list;
            }

            list = new List<T>(collection) {plane};
            return list;
        }
    }

    public class NonGenericClass
    {
        public void UseGeneric<T>(T param) where T : Car
        {
            Console.WriteLine(param.IsServiceCheckNeeded());
        }
    }

    public class GenericsTest
    {
        public static void Main()
        {
            GenericSamples();
            EmbeddedGenerics();

            Console.ReadLine();
        }

        private static void GenericSamples()
        {
            var intSample = new GenericSample<int>();
            var intDefault = intSample.CreateObject();
            intSample.Print(54);

            var stringSample = new GenericSample<string>();
            var stringDefault = intSample.CreateObject();
            stringSample.Print("test message");

            var planeGenericSample = new GenericSample<Car>();
            var planeGenericSampleDefault = intSample.CreateObject();
            planeGenericSample.Print(new Car(43));

            //var planeSample = new GenericCarSample<string>(); string can't be mapped to Car
            var planeSample = new GenericPlaneSample<AbstractPlane>();
            var planeSampleDefault = intSample.CreateObject();
            planeSample.Print(new Boeing747());

            //var planeList = planeSample.ConcatenatePlanes<ICollection<AbstractPlane>>(new[] { new Boeing747(), new Boeing747() }, new Boeing747());
            var planeList = planeSample.ConcatenatePlanes(new List<AbstractPlane> {new Boeing747(), new Boeing747()}, new Boeing747());
        }

        private static void EmbeddedGenerics()
        {
            HashSet<string> names = new HashSet<string>(); // allows to store distinct names
            names.Add("Paul");
            names.Add("Judith");
            names.Add("Susan");
            names.Add("Paul"); // duplicate - ok to add but still has 3 elements
            var containsName = names.Contains("Susan");
            
            List<string> namesList = new List<string>(); // allows to store distinct names
            namesList.Add("Paul");
            namesList.Add("Judith");
            //namesList.Add(2);
            //namesList.Add(new object());
            namesList.Add("Susan");
            namesList.Add("Paul"); // duplicate - ok to add but still has 3 elements
            var dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Paul");
            //dictionary.Add(1, "Paul"); // duplicate - dictinary throws exception
            var containsKey = dictionary.ContainsKey(1); //very fast
            var containsValue = dictionary.ContainsValue("Paul"); //slow

            var hasSearchedElement = dictionary.TryGetValue(1, out var value); //very fast
            //var value = dictionary[1]; //that gives the same result, but throws an exception if key does not exist
        }
    }
}
