namespace Contracts.Department
{
    /// <summary>
    /// Department Data only
    /// </summary>
    public struct DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }
    }
}
