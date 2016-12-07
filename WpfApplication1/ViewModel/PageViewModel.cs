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
