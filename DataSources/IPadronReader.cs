using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WebApiPadron
{
    /// <summary>
    /// Interface of a reader which retrieves a collection of people from the padron.
    /// </summary>
    public interface IPadronReader
    {
        /// <summary>
        /// Get a collection of citizens on the padron.
        /// </summary>
        /// <returns>
        /// A collection of citizens in the padron.
        /// </returns>
        public Citizen[] getCitizens();
    }
}
