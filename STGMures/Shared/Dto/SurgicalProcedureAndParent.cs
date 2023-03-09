// used in SurgicalProcedure.razor table

namespace StgMures.Shared.Dto
{
    public partial class SurgicalProcedureAndParent
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; } = null!;

        public string ParentName { get; set; } = null!;

    }
    public partial class ParentProcInfo //used by surgicalprocedure.razor
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

    }


}
