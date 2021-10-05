using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using Simulation.Infrastructure.Instruments.Validation;

namespace Simulation.Infrastructure.ViewModelAbstractComponents
{
    /// <summary>
    /// Класс прородитель модели представления
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged, IPropertyNameValidatable, IDataErrorInfo, IDisposable 
    {
        private bool _disposed;

        public virtual string ViewModelName { get; } = "";
        public string Error => throw new NotSupportedException();
        public string this[string propertyName] => OnValidate(propertyName);

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

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _disposed) return;
            _disposed = true; //Освобождение управляемых ресурсов
        }

        public virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            var results = new Collection<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);

            return !isValid ? results.First().ErrorMessage : null;
        }
    }
}
