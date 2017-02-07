using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCut
{
    public class Scissor
    {
        #region Fields

 
        private string _designation;
        #endregion
        
        #region Properties
       

        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                _designation = value;
            }
        }

        #endregion

        #region Constructors
        public Scissor(string designation)
        {
            
            _designation = designation;
            
        }
        #endregion

     
    }
}
