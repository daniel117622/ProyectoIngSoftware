using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace BlankApp
{
    public class CuentaMesa : INotifyPropertyChanged
    {
        private int mesa;
        private string platillo;
        private int cantidad;
        private float precio;

        public List<CuentaMesa> lista = new List<CuentaMesa>();

        public int Mesa
        {
            get => mesa;
            set { mesa = value; OnPropertyChanged("Mesa"); }
        }
        public string Platillo
        {
            get => platillo;
            set { platillo = value; OnPropertyChanged("Platillo"); }
        }
        public int Cantidad
        {
            get => cantidad;
            set { cantidad = value; OnPropertyChanged("Cantidad"); }
        }
        public float Precio
        {
            get => precio;
            set { precio = value; OnPropertyChanged("Precio"); }
        }
        public CuentaMesa(int mesa,string platillo,int cantidad,float precio)
        {
            this.Mesa = mesa;
            this.mesa = mesa;

            this.platillo = platillo;
            this.Platillo = platillo;

            this.cantidad = cantidad;
            this.Cantidad = cantidad;

            this.precio = precio;
            this.Precio = precio;
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
