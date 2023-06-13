using UnityEngine;

namespace Scripting
{
    public interface IPlayer
    {
        void Move(Vector3 moveVector);

        Vector3 GetCurrentPosition();
    }
}