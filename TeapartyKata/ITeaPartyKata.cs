using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeapartyKata
{
    interface ITeaPartyKata
    {
        string Welcome(string lastName, bool isWoman, bool isSir);
    }

    public class TeaPartyKata : ITeaPartyKata
    {
        public string Welcome(string lastName, bool isWoman, bool isSir)
        {
            if (isWoman) return "Hello Ms. " + lastName;
            if (!isSir) return "Hello Mr. " + lastName;
            return "Hello Sir " + lastName;
        }
    }
}
