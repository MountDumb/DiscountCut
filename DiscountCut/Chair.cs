using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DiscountCut
{
    public class Chair
    {
        #region Fields
        private object _lockPad = new object();
        private Scissor _leftScissor;
        private Scissor _rightScissor;

        private string _designation;
        private int _sessionsLeft;


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

        public int SessionsLeft
        {
            get
            {
                return _sessionsLeft;
            }

            set
            {
                _sessionsLeft = value;
            }
        }
        #endregion

        #region Constructors
        public Chair()
        {
            _sessionsLeft = 10;
        }

        public Chair(Scissor leftScissor, Scissor rightScissor)
        {
            _leftScissor = leftScissor;
            _rightScissor = rightScissor;
        }
        #endregion

        #region Methods

        private int GiveInterval()
        {
            return new Random().Next(100, 601);
        }

        private void CompleteSession()
        {
            _sessionsLeft--;
            _leftScissor.IsAvailable = true;
            _rightScissor.IsAvailable = true;

        }

        public void TryGetScissors()
        {
            lock (_lockPad)
            {
                if (_leftScissor.IsAvailable != true && _rightScissor.IsAvailable != true)
                {
                    Monitor.PulseAll(_lockPad);
                    Thread.Sleep(GiveInterval());                                           
                }
                else
                {
                    _leftScissor.IsAvailable = false;
                    _rightScissor.IsAvailable = false;
                    Thread.Sleep(GiveInterval());
                    CompleteSession();
                    Console.WriteLine("Chair " + this._designation + " is using Scissors: " + this._leftScissor + " and" + this._rightScissor);
                    
                }
            }
        }

        #endregion
    }
}
