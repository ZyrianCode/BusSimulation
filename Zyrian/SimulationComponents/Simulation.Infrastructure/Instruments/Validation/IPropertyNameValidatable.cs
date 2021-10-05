
namespace Simulation.Infrastructure.Instruments.Validation
{
    /// <summary>
    /// Предоставляет интерфейс взаимодействия ко некоторым валидируемым параметрам
    /// </summary>
    public interface IPropertyNameValidatable
    {
        string OnValidate(string propertyName);
    }
}
