namespace Library.Model.Model.Page
{
    public class PopupModel : BaseModel
    {
        public PopupModel() 
        {
        }
        
        #region Properties
        public string Title { get; set; }
        public string ViewPath { get; set; }
        public string ViewModelPath { get; set; }
        public int Width { get; set; } = 450;
        public int Height { get; set; } = 500;
        #endregion
    }

}
