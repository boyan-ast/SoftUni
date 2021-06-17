class Company {
    constructor() {
        this.departaments = {};
    }

    addEmployee(username, salary, position, department) {
        let info = [username, salary, position, department];

        if (info.some(e => {
            if (e == '' || e == null || e == undefined) {
                return true;
            }
        }) || salary < 0) {
            throw new Error('Invalid input!');
        }

        if (this.departaments[department] == undefined) {
            this.departaments[department] = [];
        }

        let employee = {
            username,
            salary,
            position
        };

        this.departaments[department].push(employee);
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let highestAverageSalary = Number.MIN_SAFE_INTEGER;

        let bestDepartmentName = '';
        let bestDepartmentEmployees = [];

        for (let key in this.departaments) {
            let averageSalary = this.departaments[key].reduce((acc, el) => {
                acc = acc + el.salary / this.departaments[key].length;
                return acc;
            }, 0);

            if (averageSalary > highestAverageSalary) {
                highestAverageSalary = averageSalary;
                bestDepartmentName = key;
                bestDepartmentEmployees = this.departaments[key];
            }
        }

        bestDepartmentEmployees.sort((a, b) => {
            let result = b.salary - a.salary;

            if (result == 0) {
                result = a.username.localeCompare(b.username);
            }

            return result;
        });

        let output = [`Best Department is: ${bestDepartmentName}`, `Average salary: ${highestAverageSalary.toFixed(2)}`];

        bestDepartmentEmployees.forEach(e => output.push(`${e.username} ${e.salary} ${e.position}`));

        return output.join('\n');
    }
}


let c = new Company();
console.log(c.addEmployee("Stanimir", 2000, "engineer", "Construction"));
console.log(c.addEmployee("Pesho", 1500, "electrical engineer", "Construction"));
console.log(c.addEmployee("Slavi", 500, "dyer", "Construction"));
console.log(c.addEmployee("Stan", 2000, "architect", "Construction"));
console.log(c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing"));
console.log(c.addEmployee("Pesho", 1000, "graphical designer", "Marketing"));
console.log(c.addEmployee("Gosho", 1350, "HR", "Human resources"));
console.log(c.bestDepartment());