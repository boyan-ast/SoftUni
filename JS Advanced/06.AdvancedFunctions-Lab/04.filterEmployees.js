function solve(data, criteria) {
    let employees = JSON.parse(data);
    let [filterKey, filterValue] = criteria.split('-');

    let filteredEmployees = filterKey == 'all' ? employees : employees.filter(e => e[filterKey] == filterValue);
    
    let i = 0;

    let result = filteredEmployees.reduce((a, el) => {        
        a += `${i++}. ${el['first_name']} ${el['last_name']} - ${el['email']}\n`;
        return a;
    }, '').trim();

    return result;
}


console.log(solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`, 
'gender-Female'
));