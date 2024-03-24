using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFService
{
    [ServiceContract(Namespace = "WCFService.Standard", Name = "ShapeTransformation", SessionMode = SessionMode.Required)]

    public interface IShapeTransformation
    {
        [OperationContract(Name = "GetRectangle")]
        [FaultContract(typeof(CustomServiceException))]
        Rectangle GetRect(double width, double height);

        [OperationContract(Name = "ChangeSize")]
        [FaultContract(typeof(CustomServiceException))]
        Rectangle ModifySize(Rectangle rect, double factor);

        [OperationContract(Name = "GetSquare")]
        double GetArea(Rectangle rect);
    }

    [DataContract(Name = "Rectangle", Namespace = "WCFService.Standard")]
    public class Rectangle
    {
        [DataMember(Name = "Width", EmitDefaultValue = true, IsRequired = true)]
        public double RectWidth { get; set; }

        [DataMember(Name = "Height", EmitDefaultValue = true, IsRequired = true)]
        public double RectHeight { get; set; }

        public int MyProperty { get; set; }

        public Rectangle(double width, double height)
        {
            RectHeight = height;
            RectWidth = width;
        }
    }

    [DataContract]
    public class CustomServiceException
    {
        [DataMember(IsRequired = true)]
        public string Message { get; set; }
        
        public CustomServiceException(string msg)
        {
            Message = msg;
        }
    }
}
