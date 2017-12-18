using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorpionExtra
{
    public partial class Form1 : Form
    {
        private Game game;
        private List<Button> buttons = new List<Button>();

        public Form1(Game game)
        {
            this.game = game;

            InitializeComponent();

            Size size = new System.Drawing.Size(75, 50);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Location = new System.Drawing.Point(12+(size.Width*j), 21+(size.Height*i));
                    button.Name = "b"+i+""+j;
                    button.Size = size;
                    button.TabIndex = 0;
                    button.UseVisualStyleBackColor = true;
                    button.Click += new System.EventHandler(this.button1_Click);

                    this.Controls.Add(button);
                    buttons.Add(button);
                }
             }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool j1 = true;
        private void button1_Click(object sender, EventArgs e)
        {
            string symbol = "0";
            if (j1)
                symbol = "X";

            Button button = (Button)sender;

            int x = Convert.ToInt32(button.Name.Substring(1, 1));
            int y = Convert.ToInt32(button.Name.Substring(2, 1));

            foreach(Player player in game.Players)
            {
                //current playing player
                if(player.isCross && symbol=="X" 
                    || !player.isCross && symbol != "X")
                {
                    player.SetNextMoveFromUI(x, y);
                }
            }

            //Done after engine has processed
            //button.Text = symbol;

            j1 = !j1;
        }

        public void Draw(Player player,int x,int y)
        {
            string symbol = "O";
            if (player.isCross)
                symbol = "X";

            foreach(Button button in buttons)
            {
                if(button.Name.Substring(1,1)==x.ToString() && button.Name.Substring(2,1)==y.ToString())
                {
                    button.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        button.Text = symbol;
                    });
                    
                    break;
                }
            }
        }
    }
}
