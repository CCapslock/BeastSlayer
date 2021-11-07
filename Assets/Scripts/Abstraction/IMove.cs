using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IMove
    {
        int Step { get; }
        void BowOut();
    }
}
