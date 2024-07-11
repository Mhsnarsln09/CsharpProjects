using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Card
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AssignedPersonId { get; set; }
        public Size Size { get; set; }
        public string CurrentLine { get; set; }
    }

    public enum Size
    {
        XS = 1,
        S = 2,
        M = 3,
        L = 4,
        XL = 5
    }
}