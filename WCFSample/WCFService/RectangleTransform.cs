using System.ServiceModel;

namespace WCFService
{
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RectangleTransform : IShapeTransformation
    {
        public RectangleTransform()
        {
            
        }

        public Rectangle GetRect(double width, double height)
        {
            if(width <= 0.0 || height <= 0.0)
                throw new FaultException<CustomServiceException>
                    (new CustomServiceException("Lenght of the sides are not valid."), 
                    "Invalid lengths.");

            return new Rectangle(width, height);
        }

        public Rectangle ModifySize(Rectangle rect, double factor)
        {
            if (factor <= 0.0)
                throw new FaultException<CustomServiceException>
                    (new CustomServiceException("Factor must be a positive value."),
                    "Invalid factor.");

            rect.RectHeight *= factor;
            rect.RectWidth *= factor;

            return rect;
        }

        public double GetArea(Rectangle rect)
        {
            return rect.RectWidth * rect.RectHeight;
        }
    }
}
