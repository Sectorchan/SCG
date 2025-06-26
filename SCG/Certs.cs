using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL;
public class Certs
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Wichtig: ToString bestimmt, was in der ListBox angezeigt wird
    public override string ToString()
    {
        return Name;
    }
}
