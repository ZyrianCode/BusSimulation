using System.Collections.Generic;
using Simulation.Data.Repositories.Entities.Abstract;

namespace Simulation.Data.Repositories.Repositories.Abstract
{
    public interface IRepository
    {
        /// <summary>
        /// Добавляет сущность в репозиторий
        /// </summary>
        /// <param name="entity"> сущность репозитория </param>
        public void Add(IBaseRepositoryEntity entity);

        /// <summary>
        /// Удаляет сущность по идентефикатору
        /// </summary>
        /// <param name="id"></param>
        public void RemoveById(string id);

        /// <summary>
        /// Выдает сущность по идентифекатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IBaseRepositoryEntity GetById(string id);

        /// <summary>
        /// Обновляет сущность репозитория
        /// </summary>
        /// <param name="entity"> сущность репозитория </param>
        public void Update(IBaseRepositoryEntity entity);

        /// <summary>
        /// Клонирует существующий репозиторий
        /// </summary>
        /// <returns> список сущностей </returns>
        public List<IBaseRepositoryEntity> Clone();

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
