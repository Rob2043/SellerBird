
using UnityEngine;

namespace CustomInterfaces
{
    public interface IObstacle
    {
        public BoxCollider2D collision2D { get; set; }
    }

}