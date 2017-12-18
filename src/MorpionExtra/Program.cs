using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorpionExtra
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Game game = new Game();

            game.AddPlayer(new Human("Yoda",true));
            game.AddPlayer(new Human("Chewbacca",false));

            Form1 ui = new Form1(game);
            game.SetUi(ui);

            new Thread(new ThreadStart(game.Start)).Start();

            Application.Run(ui);
        }
    }
}
