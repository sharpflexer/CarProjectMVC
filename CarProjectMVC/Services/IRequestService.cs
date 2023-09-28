using CarProjectMVC.Models;

namespace CarProjectMVC.Services
{
    public interface IRequestService
    {
        public Task CreateAsync(IFormCollection form);

        public List<Car> ReadAsync();

    }
}
