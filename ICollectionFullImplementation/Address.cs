using System.Text;

namespace ICollectionFullImplementation
{
    public class Address
    {
        // properties
        public string Number { get; set; }
        public string Street { get; set; }
        public string Place { get; set; }
        public string County { get; set; }

        // constructor
        public Address(string no, string streetRd, string area, string countyArea)
        {
            Number = no;
            Street = streetRd;
            Place = area;
            County = countyArea;
        }

        // data for address
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"Number: {Number}");
            buffer.AppendLine($"Street: {Street}");
            buffer.AppendLine($"Place: {Place}");
            buffer.AppendLine($"County: {County}");
            return buffer.ToString();
        }
    }
}
