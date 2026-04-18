namespace StudiousWeb.Models
{
    public class StudyMaterialToEdit
    {
        public int ID { get; set; }
        public string USERNAME { get; set; } = "";
        public string STUDYSET_NAME { get; set; } = "";
        public string TERM { get; set; } = "";
        public string DEFINITION { get; set; } = "";
        public bool EDIT_MODE { get; set; } = false;
        public bool IS_NEW { get; set; } = false;
        public bool IS_DIRTY { get; set; } = false;
        public string ORIGINAL_TERM { get; set; } = "";
        public string ORIGINAL_DEFINITION { get; set; } = "";
    }
}
