using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    public class PageViewModel : INotifyPropertyChanged
    {
        public PageViewModel()
        {

        }

        private string _riskReward = "1:1";
        public string RiskReward
        {
            get { return _riskReward; }
            set
            {
                this._riskReward = value;
                OnPropertyChanged("RiskReward");
            }
        }

        private double _exposure = 0;
        public double Exposure
        {
            get { return _exposure; }
            set { this._exposure = value;
                OnPropertyChanged("Exposure");
            }
        }

        private double _MaxPossibleGains = 0;
        public double MaxPossibleGains
        {
            get { return _MaxPossibleGains; }
            set
            {
                this._MaxPossibleGains = value;
                OnPropertyChanged("MaxPossibleGains");
            }
        }

        private double _WinPercentage = 0;
        public double WinPercentage
        {
            get { return _WinPercentage; }
            set
            {
                this._WinPercentage = value;
                OnPropertyChanged("WinPercentage");
            }
        }

        private double _MaxPossibleLoss = 0;
        public double MaxPossibleLoss
        {
            get { return _MaxPossibleLoss; }
            set
            {
                this._MaxPossibleLoss = value;
                OnPropertyChanged("MaxPossibleLoss");
            }
        }

        private double _LossPercentage = 0;
        public double LossPercentage
        {
            get { return _LossPercentage; }
            set
            {
                this._LossPercentage = value;
                OnPropertyChanged("LossPercentage");
            }
        }

        private double _UsedMargin = 0;
        public double UsedMargin
        {
            get { return _UsedMargin; }
            set
            {
                this._UsedMargin = value;
                OnPropertyChanged("UsedMargin");
            }
        }

        /// <summary>
        /// Property changed event handler to trigger update UI
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
