namespace Common.Utils.Model
{
    public class TableMetaData
    {
        public string filters { get; set; }
        public int first { get; set; }
        public int rows { get; set; }
        public string sortField { get; set; }
        public int sortOrder { get; set; }
        public string filterHandle { get; set; }
        public string tagHandle { get; set; }
        public string globalFilter { get; set; }
    }
}
