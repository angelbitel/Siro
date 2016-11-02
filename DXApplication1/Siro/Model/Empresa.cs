using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Siro.Model
{
    public class Empresa : INotifyPropertyChanged
    {
        private string _nombre;
        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                this._nombre = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string ID { get; set; }
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            var evt = PropertyChanged;
            if (evt != null) evt(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
