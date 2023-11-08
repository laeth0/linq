using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQSession1
{
    public class Book
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public string ShelfId { get; set; }

        public override string ToString()
        {
            return $"Book ID : {Id} \nBook Title : {Title} \nBook Author : {Author} \nBook Category : {Category} \nBook Price : {Price} \n ======================================";
        }
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            var other = (Book)obj;
            return Id == other.Id && Title == other.Title && Author == other.Author && Category == other.Category && Price == other.Price && ShelfId == other.ShelfId;
        }

        public override int GetHashCode()
        {
            // Implementation of GetHashCode() is missing. 
            // Please provide a proper implementation here.
            throw new System.NotImplementedException();
        }



    }
}
