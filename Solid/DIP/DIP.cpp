class Lamp {
public:
    void turnOn() {}
    void turnOff() {}
};

class Botton {
private:
    Lamp lamp;
    void pushed() {
        if (/* some condition */1) {
            lamp.turnOn();
        }
        else if (/* another condition */ 0) {
            lamp.turnOff();
        }
    }
};

// problem?























class SwitchableDevice {
public:
    virtual void turnOn() = 0;
    virtual void turnOff() = 0;
};