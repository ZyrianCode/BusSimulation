using System.Collections.Generic;
using Simulation.Repository.Entities;

namespace Simulation.Data.Repositories.Abstract
{
    /// <summary>
    /// Provider - интерфейс, предоставляющий интерфейс взаимодействия с репозиторием
    /// </summary>
    public interface IParkingRepositoryProvider
    {
        /// <summary>
        /// Добавляет парковку в репозиторий
        /// </summary>
        /// <param name="parkingEntity"> парковка сущность</param>
        public void AddParking(ParkingEntity parkingEntity);

        /// <summary>
        /// Удаляет парковку
        /// </summary>
        /// <param name="id"></param>
        public void RemoveParkingById(string id);

        /// <summary>
        /// Выдает парковку
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ParkingEntity GetParkingById(string id);

        /// <summary>
        /// Обновляет парковку
        /// </summary>
        /// <param name="parkingEntity"></param>
        public void UpdateParking(ParkingEntity parkingEntity);

        /// <summary>
        /// Клонирует существующий репозиторий
        /// </summary>
        /// <returns> список парковок </returns>
        public List<ParkingEntity> Clone();

        /// <summary>
        /// Возвращает список существующих Id у объектов
        /// </summary>
        /// <returns> список Id </returns>
        public List<string> GetExistedIdList();

        /// <summary>
        /// Очищает репозиторий
        /// </summary>
        public void Clear();
    }
}
