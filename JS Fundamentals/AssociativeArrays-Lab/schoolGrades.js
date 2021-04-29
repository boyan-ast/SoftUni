function solve(input) {
    let students = new Map();

    for (let student of input) {
        let studentInfo = student.split(' ');
        let name = studentInfo.shift();
        let grades = studentInfo.map(g => Number(g));

        if (!students.has(name)) {
            students.set(name, []);
        }

        let currentGrades = students.get(name);

        for (let grade of grades) {
            currentGrades.push(grade);
        }
    }

    let sorted = Array.from(students.entries())
        .sort(([keyA, gradesA], [keyB, gradesB]) => {
            let averageA = gradesA.reduce((a, b) => a + b, 0);
            averageA /= gradesA.length;

            let averageB = gradesB.reduce((a, b) => a + b, 0);
            averageB /= gradesB.length;

            return averageA - averageB;
        });

    for (let kvp of sorted) {
        console.log(`${kvp[0]}: ${kvp[1].join(', ')}`);
    }
}

solve(['Lilly 4 6 6 5',
    'Tim 5 6',
    'Tammy 2 4 3',
    'Tim 6 6']);