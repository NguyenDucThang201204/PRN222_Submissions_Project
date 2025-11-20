using PantherPetManagement.DAL;


namespace PantherPetManagement.BLL.Services
{
    public interface IPantherTypeService
    {
        Task<List<PantherType>> GetAllAsync();
    }
}
