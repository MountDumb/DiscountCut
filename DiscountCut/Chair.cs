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

        public Chair(string designation, Scissor leftScissor, Scissor rightScissor)
        {
            _designation = designation;
            _leftScissor = leftScissor;
            _rightScissor = rightScissor;
            _sessionsLeft = 10;
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
                        Monitor.Pulse(_lockPad);
                        Thread.Sleep(GiveInterval());
                    }
                    else
                    {
                        _leftScissor.IsAvailable = false;
                        _rightScissor.IsAvailable = false;

                        Console.WriteLine("Chair " + this._designation + " has " + this._sessionsLeft + " sessions left"
                                                   + " and " + " is using Scissors: " + this._leftScissor.Designation
                                                   + " and " + this._rightScissor.Designation);

                        CompleteSession();
                        Console.WriteLine("Chair " + this._designation + " released Scissors: " + this._leftScissor.Designation
                                        + " and " + this._rightScissor.Designation);
                        Console.WriteLine("Chair " + this._designation + " has " + this._sessionsLeft + " sessions left");

                        Thread.Sleep(GiveInterval()); // I'm doing work.


                    }
                
            }
        }

        #endregion
    }
}
