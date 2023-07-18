using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tarea_S10
{
    public partial class MainPage : ContentPage
    {
        //Participantes David Arce, Maria García, Wilson Wong, Samantha Castro

        private string expression = ""; // Variable para almacenar la expresión matemática ingresada por el usuario

        private string currentOperator = ""; // Variable para almacenar el operador actual seleccionado


        public MainPage()
        {
            InitializeComponent();
        }

        // Función para manejar el evento de clic en los botones numéricos (0-9) y coma (si aplica)
        private void OnNumberButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                expression += button.Text;
                UpdateDisplay();
            }
        }
        // Función para manejar el evento de clic en los botones de operadores (+, -, *, /)
        private void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (!string.IsNullOrEmpty(expression))
                {
                    currentOperator = button.Text;
                    expression += currentOperator;
                    UpdateDisplay();
                }
            }
        }
        // Función para manejar el evento de clic en el botón "="

        private void OnEqualsButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(expression))
            {
                try
                {
                    var result = EvaluateExpression(expression);
                    resultLabel.Text = result.ToString();
                    expression = result.ToString();
                }
                catch (Exception ex)
                {
                    resultLabel.Text = "Error";
                    expression = "";
                }
            }
        }
        // Función para manejar el evento de clic en el botón "C" (clear)

        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            expression = "";
            currentOperator = "";
            resultLabel.Text = "0";
            expressionLabel.Text = "";
        }
        // Función para actualizar la etiqueta de expresión con el contenido actual de la variable 'expression'

        private void UpdateDisplay()
        {
            expressionLabel.Text = expression;
        }
        // Función para evaluar la expresión matemática utilizando un DataTable

        private double EvaluateExpression(string expression)
        {
            var dataTable = new System.Data.DataTable();
            var result = dataTable.Compute(expression, "");
            return Convert.ToDouble(result);
        }


    }
}
