namespace Contracts.Department
{
    /// <summary>
    /// Department to Create New Object
    /// </summary>
    public struct DepartmenCreatetDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }
    }
}
