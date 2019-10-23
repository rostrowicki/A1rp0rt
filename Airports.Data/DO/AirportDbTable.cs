using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airports.Data.DO
{
    public class AirportDbTable
    {
        [Column("Date_Created")]
        public DateTime DateCreated { get; set; }

        [Column("Date_Modified")]
        public DateTime DateModified { get; set; }

        [Column("Modified_By")]
        public string ModifiedBy { get; set; }
    }
}
