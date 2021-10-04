using System.ComponentModel;
using System.Runtime.CompilerServices;
using Simulation.Instruments.Validation;

namespace Simulation.Windows
{
    public abstract class ObservableObject : INotifyPropertyChanged, IPropertyNameValidatable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Разрешает проблему кольцевых обновлений свойств
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return true;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public abstract string OnValidate(string propertyName);
    }
}
