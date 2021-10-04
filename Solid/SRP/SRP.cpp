#include <string>
#include <vector>
#include <fstream>

using std::string;
using std::vector;
using std::to_string;
using std::ofstream;
using std::endl;

class Journal {
    string          _title;
    vector<string>  _entries;
public:
    Journal(const string& title) : _title{ title } {}
    void add_entries(const string& entry) {
        static unsigned int count = 1;
        _entries.push_back(to_string(count++) + ": " + entry);
    }
    auto get_entries() const { return _entries; }
    void save(const string& filename) {
        ofstream ofs(filename);
        for (auto& s : _entries) {
            ofs << s << endl;
        }
    }
};

int  main() {
    Journal journal{ "Dear XYZ" };
    journal.add_entries("I ate a bug");
    journal.add_entries("I cried today");
    journal.save("diary.txt");
    return EXIT_SUCCESS;
}




























struct SavingManager {
    static void save(const Journal& j, const string& filename) {
        ofstream ofs(filename);
        for (auto& s : j.get_entries())
            ofs << s << endl;
    }
};