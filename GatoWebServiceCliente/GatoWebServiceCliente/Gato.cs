using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace GatoWebServiceCliente
{
    public partial class Gato : Form
    {
        private TITANIC.webapps_gatoPortClient gato;
        private int turno;
        private Stopwatch time1;
        private Stopwatch time2;
        private List<string> puntajes;
        public Gato()
        {
            gato = new TITANIC.webapps_gatoPortClient();
            puntajes = new List<string>();
            InitializeComponent();
            time1 = new Stopwatch();
            time2 = new Stopwatch();

            string todos = gato.loadScores();
            if (todos != "")
            {
                string[] scores = todos.Split('\n');
                foreach (string s in scores)
                {
                    if (s != "")
                    {
                        puntajes.Add(s);
                    }
                }
            }

            turno = 0;  // turno empieza con 0 = 'O'
            turnoText.Text = "Jugador 1";
            time1.Start();
            time2.Reset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string result = gato.play(turno, 0);
            cambiarTurno();
            if (result == "GAME OVER")
            {
                mostrarEstado(gato.getBoard().Split(','));
                mostrarGanador();
            }
            else if (result == "EMPATE")
            {
                mensaje.Text = "EMPATE";
            }
            else
            {
                mostrarEstado(result.Split(','));
                button1.Enabled = false;
            }

        }

        private void cambiarTurno()
        {
            if (turno == 0)
            {
                time1.Stop();
                turno = 1;
                time2.Start();
            }
            else
            {
                time2.Stop();
                turno = 0;
                time1.Start();
            }
            int jugador = turno + 1;
            turnoText.Text = "Jugador " + (jugador).ToString();
        }

        private void mostrarGanador()
        {
            time1.Stop();
            time2.Stop();
            mensaje.BackColor = System.Drawing.Color.LightGreen;
            int ganador = Int32.Parse(gato.getWinner()) + 1;
            string winnerTime;
            if (ganador == 1)
            {
                winnerTime = String.Format("{0:00}", time1.Elapsed.Seconds);
            }
            else
            {
                winnerTime = String.Format("{0:00}", time2.Elapsed.Seconds);
            }
            mensaje.Text = "Ganó jugador " + (ganador) + " en: " + winnerTime + "s";

            String score = winnerTime + "s" + "    " + "jugador " + ganador;
            puntajes.Add(score);
            puntajes.Sort();
            string top10 = "";
            int length = puntajes.Count;
            if (length > 10)
            {
                length = 10;
            }
            for (int i = 0; i < length; i++)
            {
                top10 += puntajes[i] + "\n";
            }
            gato.saveScores(top10);

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result = gato.play(turno, 1);
            cambiarTurno();
            if (result == "GAME OVER")
            {
                mostrarEstado(gato.getBoard().Split(','));
                mostrarGanador();
            }
            else if (result == "EMPATE")
            {
                mensaje.Text = "EMPATE";
            }
            else
            {
                mostrarEstado(result.Split(','));
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = gato.play(turno, 2);
            cambiarTurno();
            if (result == "GAME OVER")
            {
                mostrarEstado(gato.getBoard().Split(','));
                mostrarGanador();
            }
            else if(result == "EMPATE")
            {
                mensaje.Text = "EMPATE";
            }
            else
            {
                mostrarEstado(result.Split(','));
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = gato.play(turno, 3);
            cambiarTurno();
            if (result == "GAME OVER")
            {
                mostrarEstado(gato.getBoard().Split(','));
                mostrarGanador();
            }
            else if (result == "EMPATE")
            {
                mensaje.Text = "EMPATE";
            }
            else
            {
                mostrarEstado(result.Split(','));
                button4.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string result = gato.play(turno, 4);
            cambiarTurno();
            if (result == "GAME OVER")
            {
                mostrarEstado(gato.getBoard().Split(','));
                mostrarGanador();
            }
            else if (result == "EMPATE")
            {
                mensaje.Text = "EMPATE";
            }
            else
            {
                mostrarEstado(result.Split(','));
                button5.Enabled = false;
            }
        }

        private void puntuaciones_Click(object sender, EventArgs e)
        {
            puntajes.Sort();
            string top10 = "";
            int length = puntajes.Count;
            if (length > 10)
            {
                length = 10;
            }

            for (int i = 0; i < length; i++)
            {
                top10 += puntajes[i] + "\n";
            }
            MessageBox.Show(top10, "Mejores tiempos");
        }


        private void mostrarEstado(string[] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == "0")
                {
                    board[i] = "O";
                }
                else if (board[i] == "1")
                {
                    board[i] = "X";
                }
                else
                {
                    board[i] = "";
                }
            }
            button1.Text = board[0];
            button2.Text = board[1];
            button3.Text = board[2];
            button4.Text = board[3];
            button5.Text = board[4];
            button6.Text = board[5];
            button7.Text = board[6];
            button8.Text = board[7];
            button9.Text = board[8];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string result = gato.play(turno, 5);
            cambiarTurno();
            if (result == "GAME OVER")
            {
                mostrarEstado(gato.getBoard().Split(','));
                mostrarGanador();
            }
            else if (result == "EMPATE")
            {
                mensaje.Text = "EMPATE";
            }
            else
            {
                mostrarEstado(result.Split(','));
                button6.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string result = gato.play(turno, 6);
            cambiarTurno();
            if (result == "GAME OVER")
            {
                mostrarEstado(gato.getBoard().Split(','));
                mostrarGanador();
            }
            else if (result == "EMPATE")
            {
                mensaje.Text = "EMPATE";
            }
            else
            {
                mostrarEstado(result.Split(','));
                button7.Enabled = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string result = gato.play(turno, 7);
            cambiarTurno();
            if (result == "GAME OVER")
            {
                mostrarEstado(gato.getBoard().Split(','));
                mostrarGanador();
            }
            else if (result == "EMPATE")
            {
                mensaje.Text = "EMPATE";
            }
            else
            {
                mostrarEstado(result.Split(','));
                button8.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string result = gato.play(turno, 8);
            cambiarTurno();
            if (result == "GAME OVER")
            {
                mostrarEstado(gato.getBoard().Split(','));
                mostrarGanador();
            }
            else if (result == "EMPATE")
            {
                mensaje.Text = "EMPATE";
            }
            else
            {
                mostrarEstado(result.Split(','));
                button9.Enabled = false;
            }
        }

        private void juegoNuevo_Click(object sender, EventArgs e)
        {
            gato.newGame();
            if (turno == 0)
            {
                time1.Restart();
                time2.Reset();
            }
            else
            {
                time2.Restart();
                time1.Reset();
            }
            button1.Enabled = true;
            button1.Text = "";
            button2.Enabled = true;
            button2.Text = "";
            button3.Enabled = true;
            button3.Text = "";
            button4.Enabled = true;
            button4.Text = "";
            button5.Enabled = true;
            button5.Text = "";
            button6.Enabled = true;
            button6.Text = "";
            button7.Enabled = true;
            button7.Text = "";
            button8.Enabled = true;
            button8.Text = "";
            button9.Enabled = true;
            button9.Text = "";
            mensaje.Text = "";
            mensaje.BackColor = System.Drawing.SystemColors.Control;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void turnoText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
