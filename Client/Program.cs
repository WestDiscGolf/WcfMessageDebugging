using System;
using Common;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.Service1Client();

            if (false /* below is how to add the behavior in through code */)
            {
                client.Endpoint.Behaviors.Add(new DebugMessageBehavior());
            }

            var result = client.GetData(7);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}