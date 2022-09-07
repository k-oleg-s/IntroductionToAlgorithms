using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

internal class Sometxt
{
    public string text { get; set; }

    public override bool Equals(object? obj)
    {
        var other = obj as Sometxt;
        if (other == null) return false;

        return text == other.text;
    }

    public override int GetHashCode()
    {
        return text?.GetHashCode()??0;
    }
}
