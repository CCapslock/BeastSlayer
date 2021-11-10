using UnityEngine;

namespace Abstraction
{
    public interface IMove
    {
        int Step { get; }
        void BowOut(string direction, Vector3 position);
    }
}
