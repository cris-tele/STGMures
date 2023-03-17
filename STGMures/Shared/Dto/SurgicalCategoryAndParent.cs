// used in SurgicalCategory.razor table

namespace StgMures.Shared.Dto
{
    public partial class SurgicalCategoryAndParent
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ParentName { get; set; } = string.Empty;

    }
    public partial class ParentProcInfo //used by surgicalprocedure.razor
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

    }


}
