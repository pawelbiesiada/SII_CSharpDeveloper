using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using UserService;
using WCFService;

namespace Host
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var svc = new ServiceHost(typeof(RectangleTransform),
                   new Uri("http://localhost:8888/RectangleTransform"));
            svc.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            svc.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
            svc.AddServiceEndpoint(typeof(IShapeTransformation), new WSHttpBinding(), "");
            var rectHost = new Host(svc);


            svc = new ServiceHost(typeof(UserManager),
                   new Uri("http://localhost:8888/UserManager"));
            svc.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            svc.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
            svc.AddServiceEndpoint(typeof(IUserManager), new WSHttpBinding(), "");
            var userHost = new Host(svc);


            svc = new ServiceHost(typeof(CalculationDuplex),
                   new Uri("http://localhost:8888/CalcDuplex"));
            svc.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            svc.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
            svc.AddServiceEndpoint(typeof(ICalculationDuplex), new WSDualHttpBinding(), "");
            
            var calcHost = new Host(svc);

            if (!rectHost.Start())
            {
                rectHost.Stop();
                return;
            }
            if (!calcHost.Start())
            {
                calcHost.Stop();
                return;
            }

            if (!userHost.Start())
            {
                userHost.Stop();
                return;
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            rectHost.Stop();
            calcHost.Stop();
            userHost.Stop();

        }

        private static ServiceHost GetService(Type obj, params Uri[] uri)
        {
            var svc = new ServiceHost(obj,
                   uri);

            svc.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            svc.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
            return svc;
        }
    }

    internal class Host
    {
        private ServiceHost _svc;

        public Host(ServiceHost svc)
        {
            _svc = svc;
        }

        public bool Start()
        {
            var result = false;
            try
            {
                _svc.Open();
                Console.WriteLine("Service started");
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public void Stop()
        {
            try
            {
                if (_svc != null)
                {
                    _svc.Close();
                    _svc = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
    }
}
