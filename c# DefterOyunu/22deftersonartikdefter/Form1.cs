using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22deftersonartikdefter
{
    public partial class Form1 : Form
    {
        public const int Size =5;
        private readonly Button[,] _buttons = new Button[Size, Size];
        private readonly bool[,] _visited = new bool[Size, Size];
        private int _currentX;
        private int _currentY;
        private int _moveNumber = 1;

        public Form1()
        {
            
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    var button = new Button
                    {
                        Location = new Point(i * 100, j * 100),
                        Size = new Size(100, 100),
                        BackColor = Color.White
                    };
                    button.Click += OnButtonClick;
                    _buttons[i, j] = button;
                    Controls.Add(button);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void OnButtonClick(object sender, EventArgs e)
        { 
            if (!HasRedButtons() && HasEmptyButtons())
            {
                MessageBox.Show("Maalesef kaybettiniz,Baska hamle yapamazsiniz");
            }
            else if(!HasRedButtons() && !HasEmptyButtons())
            {
                MessageBox.Show("Tebrikler oyunu bitirdiniz");
            }

             bool HasRedButtons()
            {
                for (var i = 0; i < Size; i++)
                {
                    for (var j = 0; j < Size; j++)
                    {
                        if (_buttons[i, j].BackColor == Color.Red)
                            return true;
                    }
                }

                return false;
            }

             bool HasEmptyButtons()
            {
                for (var i = 0; i < Size; i++)
                {
                    for (var j = 0; j < Size; j++)
                    {
                        if (string.IsNullOrWhiteSpace(_buttons[i, j].Text))
                            return true;
                    }
                }

                return false;
            }
            var button = (Button)sender;
            var x = button.Location.X / 100;
            var y = button.Location.Y / 100;

            if (_visited[x, y])
                return;

            if (_moveNumber == 1 || button.BackColor == Color.Red)
            {
                _visited[x, y] = true;
                button.Text = _moveNumber.ToString();
                _moveNumber++;
                ClearRedButtons();
                ShowPossibleMoves(x, y);
                _currentX = x;
                _currentY = y;
            }
            
        }

        private void ClearRedButtons()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (_buttons[i, j].BackColor == Color.Red)
                        _buttons[i, j].BackColor = Color.White;
                }
            }
        }

        private void ShowPossibleMoves(int x, int y)
        {
            Move(x - 2, y - 1);
            Move(x - 2, y + 1);
            Move(x - 1, y - 2);
            Move(x - 1, y + 2);
            Move(x + 1, y - 2);
            Move(x + 1, y + 2);
            Move(x + 2, y - 1);
            Move(x + 2, y + 1);
        }

        private void Move(int x, int y)
        {
            if (x >= 0 && x < Size && y >= 0 && y < Size && !_visited[x, y])
                _buttons[x, y].BackColor = Color.Red;
        }
    }
}

