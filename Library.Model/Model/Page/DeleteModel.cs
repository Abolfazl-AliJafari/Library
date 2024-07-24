using Library.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Model.Page
{
    public class DeleteModel : BaseModel
    {

        #region Constructor

        public DeleteModel(
            ModelType type,
            int id)
        {
            Type = type;
            Id = id;
        }
        #endregion

        #region Properties

        public ModelType Type { get; set; }
        public int Id { get; set; }
        #endregion
    }
}
