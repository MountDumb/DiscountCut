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

        private object _lock;
        //private object _setLock = new object();
        private bool _isAvailable;
        private string _designation;
        #endregion
        
        #region Properties
        public bool IsAvailable
        {
          // Seems like it works as long as I lock on "this" instead of "_lock.."
          // Needs research.
                get
            {
                    lock (this)
                    {
                        return _isAvailable;
                    }

                }
                set
            {
                    lock (this)
                    {
                        _isAvailable = value;
                    }

                }
            

         }

        public Scissor GetScissor
        {
            get
            {
                lock (_lock)
                {
                    return this;
                }
                
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
            _lock = new object();
            _designation = designation;
            _isAvailable = true;
        }
        #endregion

     
    }
}
