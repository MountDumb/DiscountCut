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
        
        private bool _isAvailable;
        private string _designation;
        #endregion
        
        #region Properties
        public bool IsAvailable
        {
            get
            {
                return _isAvailable;
            }
            set
            {
                _isAvailable = value;
            }

                  
        }

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
            _isAvailable = true;
        }
        #endregion

     
    }
}
