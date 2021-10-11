using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Operations { ADD, SUBTRACT, MULTIPLY, DIVIDE };
        private bool _toReset;
        private double _currentNumber;
        private Operations? _operation;

        public MainWindow()
        {
            InitializeComponent();
            _currentNumber = 0;
            _operation = null;
            _toReset = true;
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            currentNumber.Text = "0";
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            currentNumber.Text = "0";
            operationHistory.Text = "";
            _operation = null;
            _toReset = true;
        }

        private void _clear_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber.Text.Length == 1 || _toReset)
                currentNumber.Text = "0";
            else
                currentNumber.Text = currentNumber.Text.Substring(0, currentNumber.Text.Length - 1);
        }

        private void currentNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentNumber.Text.Length == 0)
                _currentNumber = 0;
            else if (currentNumber.Text.Length > 10)
                currentNumber.Text = currentNumber.Text.Substring(0, currentNumber.Text.Length - 1);
            else
                _currentNumber = double.Parse(currentNumber.Text, System.Globalization.CultureInfo.InvariantCulture);
        }

        private void _number_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber.Text == "0" || _toReset)
            {
                _toReset = false;
                currentNumber.Text = "";
            }

            currentNumber.Text += (sender as Button)?.Content;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    _0.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad1:
                    _1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad2:
                    _2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad3:
                    _3.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad4:
                    _4.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad5:
                    _5.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad6:
                    _6.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad7:
                    _7.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad8:
                    _8.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.NumPad9:
                    _9.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.Escape:
                    C.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.Back:
                    _clear.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.Enter:
                    _equals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.Decimal:
                    _dot.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.Add:
                    _plus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.Subtract:
                    _minus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.Multiply:
                    _mult.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case Key.Divide:
                    _div.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
            }
        }

        private void _plus_Click(object sender, RoutedEventArgs e)
        {
            _equals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            _toReset = true;
            _operation = Operations.ADD;
            operationHistory.Text = _currentNumber.ToString(System.Globalization.CultureInfo.InvariantCulture) + "+";
        }

        private void _minus_Click(object sender, RoutedEventArgs e)
        {
            _equals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            _toReset = true;
            _operation = Operations.SUBTRACT;
            operationHistory.Text = _currentNumber.ToString(System.Globalization.CultureInfo.InvariantCulture) + "-";
        }

        private void _mult_Click(object sender, RoutedEventArgs e)
        {
            _equals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            _toReset = true;
            _operation = Operations.MULTIPLY;
            operationHistory.Text = _currentNumber.ToString(System.Globalization.CultureInfo.InvariantCulture) + "*";
        }

        private void _div_Click(object sender, RoutedEventArgs e)
        {
            _equals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            _toReset = true;
            _operation = Operations.DIVIDE;
            operationHistory.Text = _currentNumber.ToString(System.Globalization.CultureInfo.InvariantCulture) + "/";
        }

        private void _equals_Click(object sender, RoutedEventArgs e)
        {
            if (_operation is null)
            {
                operationHistory.Text = currentNumber.Text + "=";
                return;
            }

            double num1 = double.Parse(operationHistory.Text.Substring(0, operationHistory.Text.Length - 1), System.Globalization.CultureInfo.InvariantCulture);
            double num2 = _currentNumber;

            operationHistory.Text += $"{num2.ToString(System.Globalization.CultureInfo.InvariantCulture)}=";

            switch (_operation)
            {
                case Operations.ADD:
                    currentNumber.Text = $"{Math.Round(num1 + num2, 5).ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                    break;

                case Operations.SUBTRACT:
                    currentNumber.Text = $"{Math.Round(num1 - num2, 5).ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                    break;

                case Operations.MULTIPLY:
                    currentNumber.Text = $"{Math.Round(num1 * num2, 5).ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                    break;

                case Operations.DIVIDE:
                    currentNumber.Text = $"{Math.Round(num1 / num2, 5).ToString(System.Globalization.CultureInfo.InvariantCulture)}";
                    break;
            }
            _operation = null;
            _toReset = true;
        }

        private void _dot_Click(object sender, RoutedEventArgs e)
        {
            if (!currentNumber.Text.Contains('.'))
                currentNumber.Text += '.';
        }
    }
}
