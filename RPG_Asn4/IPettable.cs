using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Asn4
{
    public interface IPettable
    {
        string Name { get; }
        string GetPetResponse();
    }
}
