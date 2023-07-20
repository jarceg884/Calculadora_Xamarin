using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

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
        //para el nombre del archivo
        private static string nombreArchivo = "LogCalcu.txt";
        //creando la ruta del archivo 
        private static string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);        
        private static string rutaCompleta = Path.Combine(ruta, nombreArchivo);

        // Función para manejar el evento de clic en los botones numéricos (0-9) y coma (si aplica)
        private void OnNumberButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Text == "+/-")
                {
                    if (!(expression == "" && expression is null))
                    {
                        try
                        {
                            // va a cambiar toda la operacion de positivo a negativo y viceversa
                            expression = (Convert.ToDouble(expression) * -1).ToString();
                            UpdateDisplay();
                        }
                        catch (Exception) { }

                    }

                }
                else
                {
                expression += button.Text;
                UpdateDisplay();

                }
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
                    if (result.ToString() != "Infinity")
                    {
                        resultLabel.Text = result.ToString();
                        
                        expression = result.ToString();

                    }
                    else
                    {
                        resultLabel.Text = "Error";
                        expression = "";
                    }
                    
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

        private void agregarArchivo()
        {
            
            using (StreamWriter escritor = File.AppendText(rutaCompleta))
            {
                Console.WriteLine(rutaCompleta);

                int numero = (contarLineas(rutaCompleta) + 1);
                escritor.WriteLine(numero+". "+ expressionLabel.Text + " = "+ resultLabel.Text);

            }
        }

        private int contarLineas(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int lineCount = lines.Length;
            return lineCount;
        }

        private void Guardar_Clicked(object sender, EventArgs e)
        {
            agregarArchivo();
        }

        private async void Ver_Clicked(object sender, EventArgs e)
        {
            OnClearButtonClicked(sender, e);
            await Navigation.PushAsync(new VistaLog());
            
        }
    }
}
