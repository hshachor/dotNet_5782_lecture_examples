#include <string>
#include <vector>
#include <iostream>

using std::string;
using std::vector;
using std::cout;


enum class COLOR { RED, GREEN, BLUE };
enum class SIZE { SMALL, MEDIUM, LARGE };
struct Product {
    string  _name;
    COLOR   _color;
    SIZE    _size;
};

using Items = vector<Product*>;

struct ProductFilter {
    static Items by_color(Items items, const COLOR e_color) {
        Items result;
        for (auto& i : items)
            if (i->_color == e_color)
                result.push_back(i);
        return result;
    }
    static Items by_size(Items items, const SIZE e_size) {
        Items result;
        for (auto& i : items)
            if (i->_size == e_size)
                result.push_back(i);
        return result;
    }
    static Items by_size_and_color(Items items, const SIZE e_size, const COLOR e_color) {
        Items result;
        for (auto& i : items)
            if (i->_size == e_size && i->_color == e_color)
                result.push_back(i);
        return result;
    }
};
int main() {
    const Items all{
        new Product{"Apple", COLOR::GREEN, SIZE::SMALL},
        new Product{"Tree", COLOR::GREEN, SIZE::LARGE},
        new Product{"House", COLOR::BLUE, SIZE::LARGE},
    };
    for (auto& p : ProductFilter::by_color(all, COLOR::GREEN))
        cout << p->_name << " is green\n";
    for (auto& p : ProductFilter::by_size_and_color(all, SIZE::LARGE, COLOR::GREEN))
        cout << p->_name << " is green & large\n";
    return EXIT_SUCCESS;
}
/*
Apple is green
Tree is green
Tree is green & large
*/

// discuss problem and solutions















// (use filter as "interface", and add "And" filter)