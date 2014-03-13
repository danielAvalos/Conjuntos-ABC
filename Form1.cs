using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Conjuntos
{
    public partial class Form1 : Form
    {
        // se le indica al programa que cree un espacion en memoria con estos componentes

        List<string> conjuntoA;
        List<string> conjuntoB;
        List<string> conjuntoC;
        List<string> conjuntoU;
        List<string> conjuntoAB;
        List<string> conjuntoCB;
        List<string> conjuntoAC;
        List<string> conjuntoABC;

        List<string> BuCo;
        List<string> AdC ;
        List<string> respuesta;


        public Form1()
        {
            InitializeComponent();
            button7.Enabled = false;
        }

        private void btonSalir_Click(object sender, EventArgs e)
        {// este boton cierra el programa 
            this.Close();
        }

        private void btonMostrar_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = false;
            this.panelConjuntos.SendToBack();
            conjuntoA = new List<string>();
            conjuntoB = new List<string>();
            conjuntoC = new List<string>();
            conjuntoU = new List<string>();
            BuCo = new List<string>();
            AdC = new List<string>();
            conjuntoAB = new List<string>();
            conjuntoCB = new List<string>();
            conjuntoAC = new List<string>();
            conjuntoABC = new List<string>();
            respuesta = new List<string>();
            //Aqui creamos un vector y en cada posicion hay un dato
            string[] conA = txtA.Text.Split(',');
            string[] conB = txtB.Text.Split(',');
            string[] conC = txtC.Text.Split(',');
            string[] conU = txtU.Text.Split(',');
            llenarConjuntoU(conU);
            llenarConjuntoU(conA);
            llenarConjuntoU(conB);
            llenarConjuntoU(conC);
            conjuntoA = llenarConjunto(conA);
            conjuntoB = llenarConjunto(conB);
            conjuntoC = llenarConjunto(conC);
            conjuntoAB = mostrarIntersecciones(conjuntoA, conjuntoB);
            conjuntoCB = mostrarIntersecciones(conjuntoC, conjuntoB);
            conjuntoAC = mostrarIntersecciones(conjuntoA, conjuntoC);
            conjuntoABC = mostrarIntersecciones(conjuntoA, conjuntoCB);
            mostrarTextBox();
            llenarBuCo();
            llenarAdC();
            llenarRespuesta();
            llenarCombox();
        }

        public List<String> mostrarIntersecciones(List<String> conjunto1, List<String> conjunto2)
        {
            List<String> interseccion = new List<string>();
            for (int i = 0; i < conjunto1.Count; i++)
            {
                if (conjunto2.Contains(conjunto1[i]))
                {
                    interseccion.Add(conjunto1[i]);                    
                }
            }
            return interseccion;
        }

        public void limpiarCombox()
        {
            cmb1.Items.Clear();
            cmb2.Items.Clear();
            cmb3.Items.Clear();
            cmbu.Items.Clear();
            combAB.Items.Clear();
            combABC.Items.Clear();
            combCB.Items.Clear();
            cmbAC.Items.Clear();
        }

        public void llenarCombox()
        {
            limpiarCombox();

            foreach (String valor in conjuntoABC)
            {
                combABC.Items.Add(valor);
            }

            foreach (String valor in conjuntoAC)
            {
                if (!combABC.Items.Contains(valor))
                {
                    cmbAC.Items.Add(valor);
                }
            }

            foreach (String valor in conjuntoAB)
            {
                if (!combABC.Items.Contains(valor))
                {
                    combAB.Items.Add(valor);
                }
            }

            foreach (String valor in conjuntoCB)
            {
                if (!combABC.Items.Contains(valor))
                {
                    combCB.Items.Add(valor);
                }
            }


            foreach (String valor in conjuntoA)
            {
                if (!combAB.Items.Contains(valor) && !cmbAC.Items.Contains(valor) && !combABC.Items.Contains(valor) )
                {
                    cmb1.Items.Add(valor);
                }
            }

            foreach (String valor in conjuntoB)
            {
                if (!combAB.Items.Contains(valor) && !combCB.Items.Contains(valor) && !combABC.Items.Contains(valor))
                {
                    cmb2.Items.Add(valor);
                }
            }

            foreach (String valor in conjuntoC)
            {
                if (!combCB.Items.Contains(valor) && !cmbAC.Items.Contains(valor) && !combABC.Items.Contains(valor))
                {
                    cmb3.Items.Add(valor);
                }
            }

            foreach (String valor in conjuntoU)
            {
                cmbu.Items.Add(valor);
            }
        }

        public void llenarRespuesta()
        {
            foreach (var dato in AdC)
            {
                if (BuCo.Contains(dato))
                {
                    respuesta.Add(dato.Trim());
                }
            }
            txtRespuesta.Text = "";
            foreach (var dato in respuesta)
            {
                txtRespuesta.Text += dato + ",";
            }
        }

        public void llenarAdC()
        {
            foreach (var dato in conjuntoA)
            {
                if(!conjuntoC.Contains(dato))
                {
                    AdC.Add(dato.Trim());
                }
            }
            txtAdC.Text = "";
            foreach (var dato in AdC)
            {
                txtAdC.Text += dato + ",";
            }
        }

        public void llenarBuCo()
        {
            foreach (var dato in conjuntoU)
            {
                if (!conjuntoC.Contains(dato))
                {
                    BuCo.Add(dato.Trim());
                }
            }

            foreach (var dato in conjuntoB)
            {
                if(!BuCo.Contains(dato))
                {
                    BuCo.Add(dato.Trim());
                }
            }
            
            txtBuCo.Text = "";
            foreach (var dato in BuCo)
            {
                txtBuCo.Text += dato + ",";
            }
        }

        public void llenarConjuntoU(string[] conjunto)
        {
            foreach (string dato in conjunto)
            {
                if (!conjuntoU.Contains(dato))
                {
                    conjuntoU.Add(dato.Trim());
                }
            }
        }

        public List<string> llenarConjunto(string[] conjunto)// este metodo llena la lista del conjunto U la cual esta compuesta por los elementos del Conjunto A,B,C
        {
            List<string> conjuntoGenerico = new List<string>();
            foreach (string dato in conjunto)
            {
                if (!conjuntoGenerico.Contains(dato))
                {
                    conjuntoGenerico.Add(dato.Trim());
                }
            }

            return conjuntoGenerico;
        }

        public void mostrarTextBox()
        {
            txtU.Text = "";
            foreach(string dato in conjuntoU){
                txtU.Text += dato + ",";
            }
        }

        private void btonSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
            this.pictureBox1.SendToBack();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
