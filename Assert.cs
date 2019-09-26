using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


public static class Assert
{
    [Conditional("DEBUG")]
    public static void IsTrue(bool expression, string message = null)
    {
        if (expression == false)
        {
            throw new Exception(message);
        }
    }
}