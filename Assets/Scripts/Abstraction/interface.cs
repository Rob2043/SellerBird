
using UnityEngine;

namespace CustomInterfaces
{
    public interface IObstacle
    {
        public BoxCollider2D collision2D { get; set; } 
    }
    public interface IMainObstcle
    {
        public void ChanhgePosition();
    }

}