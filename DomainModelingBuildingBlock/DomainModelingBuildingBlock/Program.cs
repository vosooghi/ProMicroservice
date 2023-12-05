//Without using Value Objects
var person = new DomainModelingBuildingBlock.Entities.Person(2, "Abbas", "Vosoughi");
//if we use str in other parts of our code, the rules related to the FirstName property will not be considered.
string str = person.FirstName;

