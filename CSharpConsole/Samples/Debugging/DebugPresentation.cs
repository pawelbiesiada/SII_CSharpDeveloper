using System;
using System.Diagnostics;
using System.IO;

namespace CSharpConsole.Samples.Debugging
{
    internal class DebugPresentation
    {
        public static void Main(string[] args)
        {
            string sProdName = "Widget";
            int iUnitQty = 100;
            double dUnitCost = 1.03;
            Debug.WriteLine("Debug Information-Product Starting ");
            Debug.Indent();
            Debug.WriteLine("The product name is " + sProdName);
            Debug.WriteLine("The available units on hand are" + iUnitQty.ToString());
            Debug.WriteLine("The per unit cost is " + dUnitCost.ToString());

            System.Xml.XmlDocument oxml = new System.Xml.XmlDocument();
            Debug.WriteLine(oxml);

            Debug.WriteLine("The product name is " + sProdName, "Field");
            Debug.WriteLine("The units on hand are" + iUnitQty, "Field");
            Debug.WriteLine("The per unit cost is" + dUnitCost.ToString(), "Field");
            Debug.WriteLine("Total Cost is  " + (iUnitQty * dUnitCost), "Calc");

            Debug.WriteLineIf(iUnitQty > 50, "This message WILL appear");
            Debug.WriteLineIf(iUnitQty < 50, "This message will NOT appear");

            Debug.Assert(dUnitCost > 1, "Message will NOT appear");
            Debug.Assert(dUnitCost < 1, "Message will appear since dUnitcost  < 1 is false");


            Debug.WriteLine("The product name is " + sProdName);
            Debug.WriteLine("The available units on hand are" + iUnitQty);
            Debug.WriteLine("The per unit cost is " + dUnitCost);
            Debug.Unindent();
            Debug.WriteLine("Debug Information-Product Ending");
            Debug.Flush();

            Trace.WriteLine("Trace Information-Product Starting ");
            Trace.Indent();

            Trace.WriteLine("The product name is " + sProdName);
            Trace.WriteLine("The product name is" + sProdName, "Field");
            Trace.WriteLineIf(iUnitQty > 50, "This message WILL appear");
            Trace.Assert(dUnitCost > 1, "Message will NOT appear");


            Trace.WriteLine("Trace Information-Product Ending");

            Trace.Flush();

            Console.ReadLine();

            /*
                You can use the Trace and the Debug classes separately or together in the same application.
                In a Debug Solution Configuration project, both Trace and Debug output are active. 
                The project generates output from both of these classes to all Listener objects. However, 
                a Release Solution Configuration project only generates output from a Trace class. 
                The Release Solution Configuration project ignores any Debug class method invocations.
            */
        }
    }
}
