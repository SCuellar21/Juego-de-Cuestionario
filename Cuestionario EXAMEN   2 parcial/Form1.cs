using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cuestionario_EXAMEN___2_parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ///Lee y ordena las preguntas por categoria en la memoria del programa
            FileStream stream = new FileStream("preguntas.txt", FileMode.Open, FileAccess.Read);   //@"C:\Users\Sergio\Desktop\Google Drive\Programacion Avanzada (3)\Cuestionario EXAMEN   2 parcial\Cuestionario EXAMEN   2 parcial\bin\Debug\archivo.txt"
            StreamReader reader = new StreamReader(stream);

            int i = 0;
            while (reader.Peek() > -1)
            {
                string Linea = reader.ReadLine();
                temp = Linea.Split('-');

                if (temp[0] == null)
                {
                    break;
                }

                //categ_asing(Convert.ToInt32(temp[0]), temp[1]);
                arreglo[Convert.ToInt32(temp[0])].numero = Convert.ToInt32(temp[0]);
                arreglo[Convert.ToInt32(temp[0])].categoria = temp[1];
                arreglo[Convert.ToInt32(temp[0])].pregunta = temp[2];
                arreglo[Convert.ToInt32(temp[0])].opc1 = temp[3];
                arreglo[Convert.ToInt32(temp[0])].opc2 = temp[4];
                arreglo[Convert.ToInt32(temp[0])].opc3 = temp[5];
                arreglo[Convert.ToInt32(temp[0])].respuesta = Convert.ToInt16(temp[6]);
                i++;
                num_preguntas++;
            }
            stream.Close();
            reader.Close();

            menuStrip1.Visible = true;

            //ordenar();
        }

        public struct preguntas
        {
            public int numero;
            public string categoria;
            public string pregunta;
            public string opc1;
            public string opc2;
            public string opc3;
            public int respuesta;
        }
        preguntas[] arreglo = new preguntas[35];

        public string[] temp = new string[7];
        public Random random = new Random();

        public int num_preguntas = 0, opcion = 0, puntos = 0, n_preg_juego, valor_preg, inicio, final;
        public string contraseña = "1234";
        
        // busca la pregunta y la devuelve si existce
        public int BuscarPreg(String Numero)
        {
            for (int i = 0, x = 0; i < num_preguntas + x; i++)
            {
                if (arreglo[i].pregunta != null)
                {
                    if (arreglo[i].numero == Convert.ToInt16(Numero))
                    {
                        return i;
                    }
                }
                else
                {
                    x++;
                }
            }
            return -1;
        }
        //public int search(string Clave, int inicio, int final) // search(textBox1.Text, 0, num_articulos - 1)
        //{
        //    if (final >= 0)
        //    {
        //        int medio = (inicio + final) / 2;
        //        if (articulo[medio].Clave == Clave)
        //        {
        //            return medio;
        //        }
        //        else if (Convert.ToInt32(articulo[medio].Clave) < Convert.ToInt32(Clave))
        //        {
        //            search(Clave, medio + 1, final);
        //        }
        //        else if (Convert.ToInt32(articulo[medio].Clave) > Convert.ToInt32(Clave))
        //        {
        //            search(Clave, inicio, medio);
        //        }
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}

        //public void MergeSort(preguntas[] arreglo, int inicio, int tamano)
        //{
        //    int final = inicio + tamano - 1;
        //    int mitad, merge1, merge2;
        //    preguntas[] temp2 = new preguntas[tamano];

        //    if (inicio == final)
        //    {
        //        return;
        //    }

        //    mitad = (inicio + final) / 2;

        //    MergeSort(arreglo, inicio, mitad + 1);
        //    MergeSort(arreglo, mitad + 1, mitad);

            
        //    for (int i = 0; i < tamano; i++)
        //    {
        //        temp2[i] = arreglo[inicio + i];
        //    }
            
        //    merge1 = 0;
        //    merge2 = mitad - inicio + 1;

        //    for (int i = 0; i < tamano; i++)
        //    {
        //        if (merge2 <= final - inicio)
        //        {
        //            if (merge1 <= mitad - inicio)
        //            {
        //                if (Convert.ToInt32(temp2[merge1]) > Convert.ToInt32(temp2[merge2]))
        //                {
        //                    arreglo[i + inicio] = temp2[merge2++];
        //                }
        //                else
        //                {
        //                    arreglo[i + inicio] = temp2[merge1++];
        //                }
        //            }
        //            else
        //            {
        //                arreglo[i + inicio] = temp2[merge2++];
        //            }
        //        }
        //        else
        //        {
        //            arreglo[i + inicio] = temp2[merge1++];
        //        }
        //    }
        //}
        //public void ordenar()
        //{
        //    preguntas tempo;
        //    for (int i = 0, x = 0;i < 35 && i < num_preguntas + x; i++)
        //    {
        //        if (arreglo[i].pregunta != null)
        //        {
        //            if (i != arreglo[i].numero)
        //            {
        //                for (int k = i; k < num_preguntas; k++)
        //                {
        //                    if (i == arreglo[k].numero)
        //                    {
        //                        tempo = arreglo[i];
        //                        arreglo[i] = arreglo[k];
        //                        arreglo[k] = tempo;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            x++;
        //        }
        //    }
        //}

        //ingresa la pregunta a la categoria correspondiente para dif. acciones
        //public int a = 0, b = 5, c = 10, d = 15, f = 20, g = 25, h = 30;
        //public void categ_asing(int i, string categ)
        //{
        //    if (categ == "Categ 1")
        //    {
        //        if (a > 4)
        //        {
        //            MessageBox.Show("esa categoria esta llena");
        //        }
        //        else
        //        {
        //            arreglo[i].numero = a++;
        //        }
        //    }
        //    else if (categ == "Categ 2")
        //    {
        //        if (b > 9)
        //        {
        //            MessageBox.Show("esa categoria esta llena");
        //        }
        //        else
        //        {
        //            arreglo[i].numero = b++;
        //        }
        //    }
        //    else if (categ == "Categ 3")
        //    {
        //        if (c > 14)
        //        {
        //            MessageBox.Show("esa categoria esta llena");
        //        }
        //        else
        //        {
        //            arreglo[i].numero = c++;
        //        }
        //    }
        //    else if (categ == "Categ 4")
        //    {
        //        if (d > 19)
        //        {
        //            MessageBox.Show("esa categoria esta llena");
        //        }
        //        else
        //        {
        //            arreglo[i].numero = d++;
        //        }
        //    }
        //    else if (categ == "Categ 5")
        //    {
        //        if (f > 24)
        //        {
        //            MessageBox.Show("esa categoria esta llena");
        //        }
        //        else
        //        {
        //            arreglo[i].numero = f++;
        //        }
        //    }
        //    else if (categ == "Categ 6")
        //    {
        //        if (g > 29)
        //        {
        //            MessageBox.Show("esa categoria esta llena");
        //        }
        //        else
        //        {
        //            arreglo[i].numero = g++;
        //        }
        //    }
        //    else if (categ == "Categ 7")
        //    {
        //        if (h > 34)
        //        {
        //            MessageBox.Show("esa categoria esta llena");
        //        }
        //        else
        //        {
        //            arreglo[i].numero = h++;
        //        }
        //    }
        //}

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gContraseña.Visible = true;
            gMovimientos.Visible = true;
            gJuego.Visible = false;
            groupBox3.Visible = false;
            tContraseña.Focus();
        }

        private void jugarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gJuego.Location = new Point(13, 28);
            gJuego.Visible = true;
            gMovimientos.Visible = false;
            lPuntos.Text = Convert.ToString(puntos);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ingresa la contraseña para hacer movimientos
        private void bEntrar_Click(object sender, EventArgs e)
        {
            if (tContraseña.Text == contraseña)     //contraseña correcta
            {
                tContraseña.Clear();
                gContraseña.Visible = false;
                groupBox3.Location = new Point(6, 19);
                groupBox3.Visible = true;
                gMovimientos.Text = Convert.ToString(num_preguntas) + "! Preguntas guardadas";
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
                tContraseña.Clear();
            }
        }

        //escribe el documento de texto con los datos guardados en el arreglo
        public void escribir_doc()
        {
            FileStream stream = new FileStream("preguntas.txt", FileMode.Create, FileAccess.Write);    //@"C:\Users\Sergio\Desktop\Google Drive\Programacion Avanzada (3)\Cuestionario EXAMEN   2 parcial\Cuestionario EXAMEN   2 parcial\bin\Debug\archivo.txt"
            StreamWriter writer = new StreamWriter(stream);
            for (int i = 0, x = 0; i < 35 && x < num_preguntas; i++)
            {
                if (arreglo[i].pregunta != null)
                {
                    string linea = arreglo[i].numero + "-" + arreglo[i].categoria + "-" + arreglo[i].pregunta + "-" + arreglo[i].opc1 + "-" + arreglo[i].opc2 + "-" + arreglo[i].opc3 + "-" + arreglo[i].respuesta;
                    writer.WriteLine(linea);
                    x++;
                }
            }
            writer.Close();
            stream.Close();
        }

        //ingresa los datos de la pregunta a la memoria
        private void bIngresar_Click(object sender, EventArgs e)
        {
            if (tNumPreg.Text == "" || tPregunta.Text == "" || tOpc1.Text == "" || tOpc2.Text == "" || tOpc3.Text == "" || tRespuesta.Text == "")
            {
                MessageBox.Show("Llena todos los campos!");
                return;
            }
            if (BuscarPreg(tNumPreg.Text) == Convert.ToInt32(tNumPreg.Text))
            {
                MessageBox.Show("Ya existe una pregunta en ese número");
                tNumPreg.Clear();
                return;
            }

            arreglo[Convert.ToInt16(tNumPreg.Text)].numero = Convert.ToInt16(tNumPreg.Text);    //arreglo[num_preguntas].numero = Convert.ToInt16(tNumPreg.Text);
            arreglo[Convert.ToInt16(tNumPreg.Text)].categoria = cCategoria.Text;
            arreglo[Convert.ToInt16(tNumPreg.Text)].pregunta = tPregunta.Text;
            arreglo[Convert.ToInt16(tNumPreg.Text)].opc1 = tOpc1.Text;
            arreglo[Convert.ToInt16(tNumPreg.Text)].opc2 = tOpc2.Text;
            arreglo[Convert.ToInt16(tNumPreg.Text)].opc3 = tOpc3.Text;
            arreglo[Convert.ToInt16(tNumPreg.Text)].respuesta = Convert.ToInt16(tRespuesta.Text);
            num_preguntas++;

            escribir_doc();

            show_lb();

            tNumPreg.Clear();
            tPregunta.Clear();
            tOpc1.Clear();
            tOpc2.Clear();
            tOpc3.Clear();
            tRespuesta.Clear();
            tNumPreg.Focus(); 
            if (listBox1.Items.Count == 5)
            {
                bIngresar.Visible = false;
            }
            gMovimientos.Text = Convert.ToString(num_preguntas) + "! Preguntas guardadas";
        }

        //cambia los datos de una pregunta
        private void bCambiar_Click(object sender, EventArgs e)
        {
            if (tNumPreg.Text == "" || tPregunta.Text == "" || tOpc1.Text == "" || tOpc2.Text == "" || tOpc3.Text == "" || tRespuesta.Text == "")
            {
                MessageBox.Show("Llena todos los campos!");
                return;
            }

            arreglo[Convert.ToInt32(tNumPreg.Text)].pregunta = tPregunta.Text;
            arreglo[Convert.ToInt32(tNumPreg.Text)].categoria = cCategoria.Text;
            arreglo[Convert.ToInt32(tNumPreg.Text)].opc1 = tOpc1.Text;
            arreglo[Convert.ToInt32(tNumPreg.Text)].opc2 = tOpc2.Text;
            arreglo[Convert.ToInt32(tNumPreg.Text)].opc3 = tOpc3.Text;
            arreglo[Convert.ToInt32(tNumPreg.Text)].respuesta = Convert.ToInt16(tRespuesta.Text);

            escribir_doc();

            show_lb();
            
            tPregunta.Clear();
            tNumPreg.Clear();
            tOpc1.Clear();
            tOpc2.Clear();
            tOpc3.Clear();
            tRespuesta.Clear();
            tNumPreg.Focus();
            label1.Visible = false;
            tNumPreg.Visible = false;
            lPregunta.Visible = false;
            tPregunta.Visible = false;
            lOpc1.Visible = false;
            lOpc2.Visible = false;
            lOpc3.Visible = false;
            tOpc1.Visible = false;
            tOpc2.Visible = false;
            tOpc3.Visible = false;
            lRespC.Visible = false;
            tRespuesta.Visible = false;
            bCambiar.Visible = false;
            bEliminar.Visible = false;
        }

        //elimina una pregunta de la memoria
        private void bEliminar_Click(object sender, EventArgs e)
        {
            arreglo[Convert.ToInt32(tNumPreg.Text)].numero = 0;
            arreglo[Convert.ToInt32(tNumPreg.Text)].categoria = null;
            arreglo[Convert.ToInt32(tNumPreg.Text)].pregunta = null;
            arreglo[Convert.ToInt32(tNumPreg.Text)].opc1 = null;
            arreglo[Convert.ToInt32(tNumPreg.Text)].opc2 = null;
            arreglo[Convert.ToInt32(tNumPreg.Text)].opc3 = null;
            arreglo[Convert.ToInt32(tNumPreg.Text)].respuesta = 0;
            //for (int i = Convert.ToInt32(tNumPreg.Text); i < num_preguntas; i++)
            //{
            //    arreglo[i].numero = arreglo[i + 1].numero;
            //    arreglo[i].categoria = arreglo[i + 1].categoria;
            //    arreglo[i].pregunta = arreglo[i + 1].pregunta;
            //    arreglo[i].opc1 = arreglo[i + 1].opc1;
            //    arreglo[i].opc2 = arreglo[i + 1].opc2;
            //    arreglo[i].opc3 = arreglo[i + 1].opc3;
            //    arreglo[i].respuesta = arreglo[i + 1].respuesta;
            //}
            num_preguntas--;

            escribir_doc();

            show_lb();

            tPregunta.Clear();
            tNumPreg.Clear();
            tOpc1.Clear();
            tOpc2.Clear();
            tOpc3.Clear();
            tRespuesta.Clear();
            tNumPreg.Focus();
            bIngresar.Visible = true;
            bCambiar.Visible = false;
            bEliminar.Visible = false;
            gMovimientos.Text = Convert.ToString(num_preguntas) + "! Preguntas guardadas";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bResponder.Visible = true;
            opcion = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bResponder.Visible = true;
            opcion = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            bResponder.Visible = true;
            opcion = 3;
        }

        //Selecciona la pregunta y las opciones para cada boton de pregunta
        public void Pregunta(int n_pregunta)
        {
            gRespuestas.Text = arreglo[n_pregunta].pregunta;
            radioButton1.Text = arreglo[n_pregunta].opc1;
            radioButton2.Text = arreglo[n_pregunta].opc2;
            radioButton3.Text = arreglo[n_pregunta].opc3;

            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
        }

        //manda la respuesta seleccionada y revisa si es correcta
        private void bResponder_Click(object sender, EventArgs e)
        {
            if (arreglo[n_preg_juego].respuesta == opcion)
            {
                MessageBox.Show("Correcto!");
                puntos = puntos + valor_preg;
            }
            else
            {
                MessageBox.Show("La cagaste!");
            }

            bResponder.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            //groupBox3.Text = " ";
            lPuntos.Text = Convert.ToString(puntos);
        }

        //define aleatoriamente el numero de la pregunta para el boton presionado
        public int[] rand1 = { -1, -1, -1, -1, -1 };
        public int[] rand2 = { -1, -1, -1, -1, -1 };
        public int[] rand3 = { -1, -1, -1, -1, -1 };
        public int[] rand4 = { -1, -1, -1, -1, -1 };
        public int[] rand5 = { -1, -1, -1, -1, -1 };
        public int[] rand6 = { -1, -1, -1, -1, -1 };
        public int[] rand7 = { -1, -1, -1, -1, -1 };
        public int N_Preg_Def(int aumento_categ)
        {
            n_preg_juego = random.Next(0, 5);
            switch (aumento_categ)
            {
                case 0:
                    while (n_preg_juego == rand1[n_preg_juego])
                    {
                        n_preg_juego = random.Next(0, 5);
                    }
                    rand1[n_preg_juego] = n_preg_juego;
                    return n_preg_juego + aumento_categ;

                case 5:
                    while (n_preg_juego == rand2[n_preg_juego])
                    {
                        n_preg_juego = random.Next(0, 5);
                    }
                    rand2[n_preg_juego] = n_preg_juego;
                    return n_preg_juego + aumento_categ;

                case 10:
                    while (n_preg_juego == rand3[n_preg_juego])
                    {
                        n_preg_juego = random.Next(0, 5);
                    }
                    rand3[n_preg_juego] = n_preg_juego;
                    return n_preg_juego + aumento_categ;

                case 15:
                    while (n_preg_juego == rand4[n_preg_juego])
                    {
                        n_preg_juego = random.Next(0, 5);
                    }
                    rand4[n_preg_juego] = n_preg_juego;
                    return n_preg_juego + aumento_categ;

                case 20:
                    while (n_preg_juego == rand5[n_preg_juego])
                    {
                        n_preg_juego = random.Next(0, 5);
                    }
                    rand5[n_preg_juego] = n_preg_juego;
                    return n_preg_juego + aumento_categ;

                case 25:
                    while (n_preg_juego == rand6[n_preg_juego])
                    {
                        n_preg_juego = random.Next(0, 5);
                    }
                    rand6[n_preg_juego] = n_preg_juego;
                    return n_preg_juego + aumento_categ;

                case 30:
                    while (n_preg_juego == rand7[n_preg_juego])
                    {
                        n_preg_juego = random.Next(0, 5);
                    }
                    rand7[n_preg_juego] = n_preg_juego;
                    return n_preg_juego + aumento_categ;

                default:
                    return -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(0));
            button1.Enabled = false;
            valor_preg = 500;
            //n_preg_juego = 1;
            //Pregunta(n_preg_juego);
            //button1.Enabled = false;
            //valor_preg = 500;
            ////OcultPreguntas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(5));
            button2.Enabled = false;
            valor_preg = 500;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(10));
            button3.Enabled = false;
            valor_preg = 500;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(15));
            button4.Enabled = false;
            valor_preg = 500;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(20));
            button5.Enabled = false;
            valor_preg = 500;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(25));
            button6.Enabled = false;
            valor_preg = 500;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(30));
            button7.Enabled = false;
            valor_preg = 500;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(0));
            button8.Enabled = false;
            valor_preg = 400;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(5));
            button9.Enabled = false;
            valor_preg = 400;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(10));
            button10.Enabled = false;
            valor_preg = 400;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(15));
            button11.Enabled = false;
            valor_preg = 400;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(20));
            button12.Enabled = false;
            valor_preg = 400;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(25));
            button13.Enabled = false;
            valor_preg = 400;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(30));
            button14.Enabled = false;
            valor_preg = 400;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(0));
            button15.Enabled = false;
            valor_preg = 300;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(5));
            button16.Enabled = false;
            valor_preg = 300;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(10));
            button17.Enabled = false;
            valor_preg = 300;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(15));
            button18.Enabled = false;
            valor_preg = 300;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(20));
            button19.Enabled = false;
            valor_preg = 300;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(25));
            button20.Enabled = false;
            valor_preg = 300;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(30));
            button21.Enabled = false;
            valor_preg = 300;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(0));
            button22.Enabled = false;
            valor_preg = 200;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(5));
            button23.Enabled = false;
            valor_preg = 200;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(10));
            button24.Enabled = false;
            valor_preg = 200;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(15));
            button25.Enabled = false;
            valor_preg = 200;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(20));
            button26.Enabled = false;
            valor_preg = 200;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(25));
            button27.Enabled = false;
            valor_preg = 200;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(30));
            button28.Enabled = false;
            valor_preg = 200;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(0));
            button29.Enabled = false;
            valor_preg = 100;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(5));
            button30.Enabled = false;
            valor_preg = 100;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(10));
            button31.Enabled = false;
            valor_preg = 100;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(15));
            button32.Enabled = false;
            valor_preg = 100;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(20));
            button33.Enabled = false;
            valor_preg = 100;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(25));
            button34.Enabled = false;
            valor_preg = 100;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Pregunta(N_Preg_Def(30));
            button35.Enabled = false;
            valor_preg = 100;
        }

        // borra los textbox para ingresar una nueva pregunta
        private void tNumPreg_TextChanged(object sender, EventArgs e)
        {
            tPregunta.Clear();
            tOpc1.Clear();
            tOpc2.Clear();
            tOpc3.Clear();
            tRespuesta.Clear();
            bCambiar.Visible = false;
            bEliminar.Visible = false;
        }

        // muestra los preguntas de la categoria seleccionada
        public void show_lb()
        {
            listBox1.Items.Clear();
            switch (cCategoria.SelectedIndex)
            {
                case 0:
                    inicio = 0;
                    final = 5;
                    break;
                case 1:
                    inicio = 5;
                    final = 10;
                    break;
                case 2:
                    inicio = 10;
                    final = 15;
                    break;
                case 3:
                    inicio = 15;
                    final = 20;
                    break;
                case 4:
                    inicio = 20;
                    final = 25;
                    break;
                case 5:
                    inicio = 25;
                    final = 30;
                    break;
                case 6:
                    inicio = 30;
                    final = 35;
                    break;
            }

            for (int i = inicio; i < final; i++)
            {
                while (arreglo[i].pregunta == null && i < final)
                {
                    i++;
                }
                if (final <= i)
                {
                    break;
                }
                listBox1.Items.Add(arreglo[i].numero + " " + arreglo[i].categoria + " " + arreglo[i].pregunta);
            }
        }

        //muestra en listbox las preguntas que existen en la categoria seleccionada
        private void cCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            show_lb();

            if (listBox1.Items.Count < 5)
            {
                tNumPreg.Clear();
                tPregunta.Clear();
                tOpc1.Clear();
                tOpc2.Clear();
                tOpc3.Clear();
                tRespuesta.Clear();
                label1.Visible = true;
                tNumPreg.Visible = true;
                lPregunta.Visible = true;
                tPregunta.Visible = true;
                lOpc1.Visible = true;
                tOpc1.Visible = true;
                lOpc2.Visible = true;
                tOpc2.Visible = true;
                lOpc3.Visible = true;
                tOpc3.Visible = true;
                lRespC.Visible = true;
                tRespuesta.Visible = true;
                bIngresar.Visible = true;
                bCambiar.Visible = false;
                bEliminar.Visible = false;
            }
            else
            {
                label1.Visible = false;
                tNumPreg.Visible = false;
                lPregunta.Visible = false;
                tPregunta.Visible = false;
                lOpc1.Visible = false;
                tOpc1.Visible = false;
                lOpc2.Visible = false;
                tOpc2.Visible = false;
                lOpc3.Visible = false;
                tOpc3.Visible = false;
                lRespC.Visible = false;
                tRespuesta.Visible = false;
                bIngresar.Visible = false;
            }
        }

        // muestra los datos de la pregunta seleccionada para realizarle cambio o eliminarla
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] numero = new string[3];
            string s = Convert.ToString(listBox1.SelectedItem);
            numero = s.Split();

            tNumPreg.Text = Convert.ToString(numero[0]);
            tPregunta.Text = arreglo[Convert.ToInt32(tNumPreg.Text)].pregunta;
            cCategoria.Text = arreglo[Convert.ToInt32(tNumPreg.Text)].categoria;
            tOpc1.Text = arreglo[Convert.ToInt32(tNumPreg.Text)].opc1;
            tOpc2.Text = arreglo[Convert.ToInt32(tNumPreg.Text)].opc2;
            tOpc3.Text = arreglo[Convert.ToInt32(tNumPreg.Text)].opc3;
            tRespuesta.Text = Convert.ToString(arreglo[Convert.ToInt32(tNumPreg.Text)].respuesta);
            label1.Visible = true;
            tNumPreg.Visible = true;
            lCategoria.Visible = true;
            cCategoria.Visible = true;
            lPregunta.Visible = true;
            tPregunta.Visible = true;
            lOpc1.Visible = true;
            tOpc1.Visible = true;
            lOpc2.Visible = true;
            tOpc2.Visible = true;
            lOpc3.Visible = true;
            tOpc3.Visible = true;
            lRespC.Visible = true;
            tRespuesta.Visible = true;
            bCambiar.Visible = true;
            bEliminar.Visible = true;
        }
        
        //public void OcultPreguntas()
        //{
        //    if (radioButton1.Visible)
        //    {
        //        button1.Enabled = false;
        //        button2.Enabled = false;
        //        button3.Enabled = false;
        //        button4.Enabled = false;
        //        button5.Enabled = false;
        //        button6.Enabled = false;
        //        button7.Enabled = false;
        //        button8.Enabled = false;
        //        button9.Enabled = false;
        //        button10.Enabled = false;
        //        button11.Enabled = false;
        //        button12.Enabled = false;
        //        button13.Enabled = false;
        //        button14.Enabled = false;
        //        button15.Enabled = false;
        //        button16.Enabled = false;
        //        button17.Enabled = false;
        //        button18.Enabled = false;
        //        button19.Enabled = false;
        //        button20.Enabled = false;
        //        button21.Enabled = false;
        //        button22.Enabled = false;
        //        button23.Enabled = false;
        //        button24.Enabled = false;
        //        button25.Enabled = false;
        //        button26.Enabled = false;
        //        button27.Enabled = false;
        //        button28.Enabled = false;
        //        button29.Enabled = false;
        //        button30.Enabled = false;
        //        button31.Enabled = false;
        //        button32.Enabled = false;
        //        button33.Enabled = false;
        //        button34.Enabled = false;
        //        button35.Enabled = false;
        //    }
        //}
    }
}