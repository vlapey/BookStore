using System.Collections.Generic;

namespace Context
{
    public interface IApplicationContext
    {
        public int Execute(string command);
        public List<string[]> ToList(string command);
    }
}