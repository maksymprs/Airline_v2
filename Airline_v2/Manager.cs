using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_v2
{
    abstract class Manager
    {
        public virtual void Add() { }
        public virtual void Edit() { }
        public virtual void Delete() { }
    }

}