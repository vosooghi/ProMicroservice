

using ValueObjects.Samples;

//-------Equality Check
Meter meter01 = new Meter(1);
Meter meter02 = new Meter(1);
Meter meter2 = new Meter(1);

bool conditon =  meter01.Equals(meter02);

//-------Immutable Check
var person = new Person
{
    Id = 1,
    Hight = new Meter(2)
};
var car = new Car { Id=1, Hight = new Meter(1) };

//it doesn't effect person.hight
car.Hight = car.Hight.AddMeter(new Meter(1));

//-------Combinable
Meter meter1 = new Meter(1);
Meter meter3 = new Meter(1);
Meter meter4 = meter1+ meter3;