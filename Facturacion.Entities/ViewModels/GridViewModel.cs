using System.Collections.Generic;

namespace Facturacion.Entities.ViewModels
{
    public class GridResponse<T> where T : class
    {
        public bool success { get; set; }
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<T> data { get; set; }
    }

    public class GridRequest<T> where T : class
    {
        public int draw { get; set; }
        public int length { get; set; }
        public int start { get; set; }
        public int page
        {
            get
            {
                return start == 0 ? 1 : ((start / length) + 1);
            }
        }
        public Search search { get; set; }
        public List<Order> order { get; set; }
        public List<Columns> columns { get; set; }
        public T filters { get; set; }
        public bool SearchAll { get; set; }
    }

    public class Columns
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool orderable { get; set; }
        public bool searchable { get; set; }
        public Search search { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    public class Search
    {
        public bool regex { get; set; }
        public string value { get; set; }
    }

    public class GridTotal
    {
        public int TotalRows { get; set; }
    }
}
