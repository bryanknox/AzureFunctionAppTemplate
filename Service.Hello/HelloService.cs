using System;

namespace Service.Hello
{
    public class HelloService : IHelloService
    {
        private readonly string _greeting;

        public HelloService()
        {
            _greeting = "Hello";
        }

        public string SayHelloTo(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            return $"{_greeting}, {name}.";
        }
    }
}
