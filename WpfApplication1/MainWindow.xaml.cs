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
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isLoading = false;

        private PageViewModel viewModel = new PageViewModel();

        public MainWindow()
        {
            isLoading = true;


            InitializeComponent();

            // Set binding.
            DataContext = viewModel;

            isLoading = false;
        }


        private void Textbox_Leverage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (isLoading)
                return;

            UpdateCalculationResults();
        }

        private void Textbox_StopLoss_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (isLoading)
                return;

            UpdateCalculationResults();
        }

        private void Textbox_TakeProfit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (isLoading)
                return;

            UpdateCalculationResults();
        }

        private void Textbox_Entry_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (isLoading)
                return;

            UpdateCalculationResults();
        }

        private void Textbox_Amount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (isLoading)
                return;

            UpdateCalculationResults();
        }

        #region InternalCalculation
        private void UpdateCalculationResults()
        {
            double amount = 0;
            if (Textbox_Amount.Value != null)
                amount = (double)Textbox_Amount.Value;

            double entryPrice = 0;
            if (Textbox_Entry.Value != null)
                entryPrice = (double) Textbox_Entry.Value;

            double takeProfit = 0;
            if (Textbox_TakeProfit.Value != null)
                takeProfit = (double)Textbox_TakeProfit.Value;

            double leverage = 0;
            if (Textbox_Leverage.Value != null)
                leverage = (double)Textbox_Leverage.Value;

            double stopLoss = 0;
            if (Textbox_StopLoss.Value != null)
                stopLoss = (double)Textbox_StopLoss.Value;


            bool isLongPosition = entryPrice < takeProfit;
            double percentageDifference_Win = (isLongPosition ? (takeProfit - entryPrice) : (entryPrice - takeProfit)) / 100;
            double percentageDifference_loss = (isLongPosition ? (entryPrice - stopLoss) : (stopLoss - entryPrice)) / 100;
            double totalPosition = amount * leverage;

            // update
            viewModel.MaxPossibleGains = percentageDifference_Win * totalPosition;
            viewModel.MaxPossibleLoss = percentageDifference_loss * totalPosition;
            viewModel.Exposure = totalPosition;
            viewModel.RiskReward = percentageDifference_Win > percentageDifference_loss ? ((percentageDifference_Win/percentageDifference_loss) +" : 1") : ("1 : " + (percentageDifference_loss / percentageDifference_Win));
        }
        #endregion
    }
}
