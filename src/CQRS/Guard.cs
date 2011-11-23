using System;


namespace CQRS
{
    public class Guard
    {
        public static void Against(bool condition, string message)
        {
            if (!condition) return;
            throw new Exception(message);
            

           
        }
    }
}