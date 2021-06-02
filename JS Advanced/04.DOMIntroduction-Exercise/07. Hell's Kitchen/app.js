function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      const inputTextElement = document.querySelector('#inputs textarea');
      const inputTextArray = JSON.parse(inputTextElement.value);

      const restaurants = {};

      for (let restaurantInfo of inputTextArray) {
         let [name, workersInfo] = restaurantInfo.split(' - ');

         let workers = workersInfo.split(', ');

         if (restaurants[name] == undefined) {
            restaurants[name] = {};
         }

         for (let worker of workers) {
            let [workerName, salary] = worker.split(' ');
            salary = Number(salary);

            restaurants[name][workerName] = salary;
         }
      }

      let bestRestaurantWorkers = {};
      let maxAverageSalary = 0;
      let bestRestaurantName = '';

      for (let restaurantInfo of Object.entries(restaurants)) {
         let restaurantName = restaurantInfo[0];
         let workersInfo = restaurantInfo[1];
         let workersSalaries = Object.values(workersInfo);
         let averageSalary = workersSalaries.reduce((a, x) => a + x / workersSalaries.length, 0);

         if (averageSalary > maxAverageSalary) {
            maxAverageSalary = averageSalary;
            bestRestaurantWorkers = restaurants[restaurantName];
            bestRestaurantName = restaurantName;
         }
      }

      let sortedWorkers = Object.entries(bestRestaurantWorkers).sort((a, b) => b[1] - a[1]);

      let bestRestaurantElement = document.querySelector('#bestRestaurant p');

      bestRestaurantElement.textContent =
         `Name: ${bestRestaurantName} Average Salary: ${maxAverageSalary.toFixed(2)} Best Salary: ${sortedWorkers[0][1].toFixed(2)}`;

      let workersElement = document.querySelector('#workers p');

      let result = [];

      for (let worker of sortedWorkers) {
         result.push(`Name: ${worker[0]} With Salary: ${worker[1]}`);
      }

      workersElement.textContent = result.join(' ');
   }
}