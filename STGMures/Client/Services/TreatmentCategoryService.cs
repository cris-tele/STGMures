using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public class TreatmentCategoryService : ITreatmentCategoryService
    {
        public TreatmentCategoryService()
        {

        }
        IList<TreatmentCategoryService> ITreatmentCategoryService.TreatmentCategoryes { get ; set ; } = new List<TreatmentCategoryService>();

        Task ITreatmentCategoryService.AddTreatmentCategory(int id, TreatmentCategoryService treatmentCategory)
        {
            throw new NotImplementedException();
        }

        Task ITreatmentCategoryService.DeleteTreatmentCategory(int id)
        {
            throw new NotImplementedException();
        }

        Task<TreatmentCategoryService> ITreatmentCategoryService.GetTreatmentCategory(int id)
        {
            throw new NotImplementedException();
        }
        Task<TreatmentCategoryService> ITreatmentCategoryService.GetTreatmentCategoryes()
        {
            throw new NotImplementedException();
        }

        Task<Patient> ITreatmentCategoryService.UpdateTreatmentCategory(TreatmentCategoryService treatmentCategory)
        {
            throw new NotImplementedException();
        }
    }
}
