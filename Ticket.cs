using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BlankApp
{
    public class Ticket : INotifyPropertyChanged
    {
        private float total;
        private int cantidad;
        private int mesa;

        public List<Platillo> lista = new List<Platillo>();

        public float Total
        {
            get => total;
            set { total = value; OnPropertyChanged("Total"); }
        }
        public int Cantidad
        { 
            get => cantidad; 
            set { cantidad = value; OnPropertyChanged("Cantidad"); }
        }
        public int Mesa
        {
            get => mesa;
            set { mesa = value; OnPropertyChanged("Mesa"); }
        }

        public Ticket(float total, int cantidad, int mesa)
        {
            this.Total = total;
            this.total = total;

            this.Cantidad = cantidad;
            this.cantidad = cantidad;

            this.Mesa = mesa;
            this.mesa = mesa;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

    }
}
