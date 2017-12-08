using System;

namespace SystemUnderTest
{
    public class SimpleClass
    {
        public string SimpleMethod(string input)
        {
            if (input == "input1")
            {
                return "input 1";
            }
            else if (input == "input2")
            {
                return "input 2";
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
