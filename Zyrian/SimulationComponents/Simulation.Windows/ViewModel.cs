using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Simulation.Windows
{
    /// <summary>
    /// Класс прородитель модели представления
    /// </summary>
    public abstract class ViewModel : ObservableObject, IDataErrorInfo, IDisposable 
    {
        private bool _disposed;

        public virtual string ViewModelName { get; } = "";
        public string Error => throw new NotSupportedException();
        public string this[string propertyName] => OnValidate(propertyName);

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _disposed) return;
            _disposed = true; //Освобождение управляемых ресурсов
        }

        public override string OnValidate(string propertyName)
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
