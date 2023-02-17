

namespace StgMures.Shared.Dto
{
    public partial class DiagnosticsAndParent
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public int DiagnosticCategoryId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string ParentName { get; set; } = string.Empty;      // the new one: only one parent for this moment

        public string ValueFormat { get; set; } = string.Empty;

        public string? MinAlertValue { get; set; } = string.Empty;

        public string? MaxAlertValue { get; set; } = string.Empty;

        public string? Note { get; set; } = string.Empty;

        public string? MeasureUnit { get; set; } = string.Empty;
        // public string FullName { get; set; } = string.Empty;      // ParentName, Name
    }
}
