using System;
using System.Threading;

namespace MorpionExtra
{
    public class Player
    {
        public int Name { get; internal set; }
        public bool isCross { get; set; }

        private volatile int[] nextMoveFromUI;
        private Object threadSync = new object();


        public int[] GetNextMoveFromUI()
        {
            lock (threadSync)
            {
                return nextMoveFromUI;
            }
        }
        public void SetNextMoveFromUI(int x,int y)
        {
            lock (threadSync)
            {
                nextMoveFromUI= new int[] { x, y };
            }
        }

        public void ResetNextMoveFromUI()
        {
            lock (threadSync)
            {
                nextMoveFromUI = null;
            }
        }

        public Player(bool isCross)
        {
            this.isCross = isCross;
        }

        internal int[] NextMove()
        {
            Console.Write("Prochaine case :");

            if (Console.KeyAvailable)
            {
                string[] coordinates = Console.ReadLine().Split(',');
                return new int[] { Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]) };
            }
            else
            {
                //TODO check in UI
                lock (threadSync)
                {
                    if (nextMoveFromUI != null)
                    {
                        return nextMoveFromUI;
                    }
                }

                Thread.Sleep(500);
            }

            return null;

        }

        internal void NotifyMove(int[] xY)
        {
            //throw new NotImplementedException();
        }
    }
}