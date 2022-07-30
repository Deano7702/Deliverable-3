using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable2
{
    //Dean Mason
    //1574783
    class Offender
    {
        private string _offenderID; //Offender ID variable
        private string _fname; //Offender first name variable
        private string _lname; //Offender last name variable

        /// <summary>
        /// Constructor, initalizes class fields 
        /// </summary>
        /// <param name="ID">The ID of the offender</param>
        /// <param name="name">The name of the offender</param>
        public Offender(string ID, string fname, string lname)
        {
            //Make the class fields equal to the values passed in
            _offenderID = ID; 
            _fname = fname;
            _lname = lname;

        }

        /// <summary>
        /// Getter method for offender ID
        /// </summary>
        public string ID
        {
            get { return _offenderID; }
        }

        /// <summary>
        /// Getter method for offenders first name
        /// </summary>
        public string firstName
        {
            get { return _fname; }
        }

        /// <summary>
        /// Getter method for offenders last name
        /// </summary>
        public string lastName
        {
            get { return _lname; }
        }



    }
}
