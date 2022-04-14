using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo);
            
            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();
            string resultado = lblResultado.Text;

            lblResultado.Text = operando.DecimalBinario(resultado);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();
            string resultado = lblResultado.Text;

            lblResultado.Text = operando.BinarioDecimal(resultado);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = txtNumero1.Text;
            string num2 = txtNumero2.Text;
            string operador = cmbOperador.Text;

            string resultado = Convert.ToString(Operar(num1, num2, operador));

            string operacion = (Int32.TryParse(num1, out int numero1) == false ? "0" : num1) + " " + (operador == " " ? "+" : operador) + " " + (Int32.TryParse(num2, out int numero2) == false ? "0" : num2) + " = " + resultado;

            lblResultado.Text = resultado;
            lstOperaciones.Items.Add(operacion);
        }

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "";
            lstOperaciones.Items.Clear();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);

            return Calculadora.Operar(operando1, operando2, char.Parse(operador));
        }
    }
}
