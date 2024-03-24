using System;
using System.ServiceModel;
using Client.CalculationDuplex;
using Client.Transformation;

namespace Client
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            WCFServiceSimple();
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine();
            WCFServiceDuplex();
            Console.ReadKey();
        }

        private static void WCFServiceSimple()
        {
            var client = new ShapeTransformationClient(new WSHttpBinding(),
                    new EndpointAddress("http://localhost:8888/RectangleTransform"));

            var rect = client.GetRectangle(3, 4);
            Console.WriteLine("Rectangle object height is {0} and width is {1}.", rect.Height, rect.Width);
            Console.WriteLine("Rectangle square is: {0}", client.GetSquare(rect));

            try
            {
                var newRect = client.ChangeSize(rect, -2.0);
            }
            catch (FaultException<CustomServiceException> e)
            {
                Console.WriteLine(e.Detail.Message);
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Should not fall in here.");
            }
        }
        
        private static void WCFServiceDuplex()
        {
            var instance = new InstanceContext(new CallbackHandler());
            var client =
                new CalculationDuplexClient(instance, 
                        new WSDualHttpBinding{ClientBaseAddress = new Uri("http://localhost:8888/ClientCallback")},
                        new EndpointAddress("http://localhost:8888/CalcDuplex"));

            try
            {
                // Call the AddTo service operation.
                double value = 100.00D;
                client.AddTo(value);

                // Call the SubtractFrom service operation.
                value = 50.00D;
                client.SubtractFrom(value);
                System.Threading.Thread.Sleep(500);

                // Call the MultiplyBy service operation.
                value = 17.65D;
                client.MultiplyBy(value);
                System.Threading.Thread.Sleep(500);

                // Call the DivideBy service operation.
                value = 2.00D;
                client.DivideBy(value);
                System.Threading.Thread.Sleep(500);

                // Complete equation.
                client.Clear();

                // Wait for callback messages to complete before
                // closing.
                System.Threading.Thread.Sleep(500);

                // Close the WCF client.
                client.Close();
                Console.WriteLine("Done!");
            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                client.Abort();
                Console.Read();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message);
                client.Abort();
                Console.Read();
            }
        }
    }

    public class CallbackHandler : ICalculationDuplexCallback
    {
        public CallbackHandler()
        {
            
        }

        public void Result(double result)
        {
            Console.WriteLine("Result ({0})", result);
        }
        public void Equation(string equation)
        {
            Console.WriteLine("Equation({0})", equation);
        }
    }
}
