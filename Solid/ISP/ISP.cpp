struct Document;
struct IMachine {
    virtual void print(Document& doc) = 0;
    virtual void fax(Document& doc) = 0;
    virtual void scan(Document& doc) = 0;
};
struct MultiFunctionPrinter : IMachine {      // OK
    void print(Document& doc) override {
        // print
    }
    void fax(Document& doc) override { 
        // send fax
    }
    void scan(Document& doc) override { 
        // Do scanning
    }
};
struct Scanner : IMachine {                   // Not OK
    void print(Document& doc) override { /* Blank */ }
    void fax(Document& doc) override { /* Blank */ }
    void scan(Document& doc) override {
        // Do scanning ...
    }
};














/* -------------------------------- Interfaces ----------------------------- */
struct IPrinter {
    virtual void print(Document& doc) = 0;
};
struct IScanner {
    virtual void scan(Document& doc) = 0;
};
/* ------------------------------------------------------------------------ */
struct Printer : IPrinter {
    void print(Document& doc) override { /* print */ };
};
struct Scanner : IScanner {
    void scan(Document& doc) override { /* scan */ };
};
struct IMultiMachine : IPrinter, IScanner { };
struct MultiMachine : IMultiMachine {
    IPrinter& _printer;
    IScanner& _scanner;
    MultiMachine(IPrinter& p, IScanner& s) : _printer{ p }, _scanner{ s } { }
    void print(Document& doc) override { _printer.print(doc); }
    void scan(Document& doc) override { _scanner.scan(doc); }
};