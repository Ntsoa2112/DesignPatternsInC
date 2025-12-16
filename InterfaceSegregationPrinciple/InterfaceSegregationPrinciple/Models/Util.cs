using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple.Models
{
    public class Document
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            // Implementation for printing
        }
        public void Scan(Document d)
        {
            // Implementation for scanning
        }
        public void Fax(Document d)
        {
            // Implementation for faxing
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            // Implementation for printing
        }
        public void Scan(Document d)
        {
            throw new NotImplementedException("This printer cannot scan.");
        }
        public void Fax(Document d)
        {
            throw new NotImplementedException("This printer cannot fax.");
        }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);
    }
    public interface IFax
    {
        void Fax(Document d);
    }

    public class JustAPrinter : IPrinter
    {
        public void Print(Document d)
        {
            // Implementation for printing
        }
    }

    public interface IMultiFunctionDevice : IPrinter, IScanner, IFax
    {
    } 

    public class Photocopier : IPrinter, IScanner //..
    {
        public void Print(Document d)
        {
            // Implementation for printing
        }
        public void Scan(Document d)
        {
            // Implementation for scanning
        }
    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private readonly IPrinter _printer;
        private readonly IScanner _scanner;
        private readonly IFax _fax;
        public MultiFunctionMachine(IPrinter printer, IScanner scanner, IFax fax)
        {
            _printer = printer;
            _scanner = scanner;
            _fax = fax;
        }
        public void Print(Document d)
        {
            _printer.Print(d);
        }
        public void Scan(Document d)
        {
            _scanner.Scan(d);
        }
        public void Fax(Document d)
        {
            _fax.Fax(d);
        }
    }
}
