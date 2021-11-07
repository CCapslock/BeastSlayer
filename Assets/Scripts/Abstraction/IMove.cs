using UnityEngine;

namespace Abstraction
{
    public interface IMove
    {
        int Step { get; }
        Vector3 BowOut(string direction, Vector3 position);
    }
}
