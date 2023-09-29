using CarProjectMVC.Models;

namespace CarProjectMVC.Services
{
    public interface IRequestService
    {
        /// <summary>
        /// Отправляет запрос на добавление нового автомобиля в БД через ApplicationContext
        /// </summary>
        /// <param name="form">Форма с данными списков Brands, Models и Colors</param>
        /// <returns></returns>
        public Task CreateAsync(IFormCollection form);

        /// <summary>
        /// Полуает список всех автомобилей из БД
        /// </summary>
        /// <returns>Список автомобилей</returns>
        public List<Car> Read();
        public Task UpdateAsync(IFormCollection form);
    }
}
