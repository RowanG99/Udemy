import React, { useState } from 'react';

import logo from './assets/investment-calculator-logo.png';
import Form from './Components/UI/Form/Form';
import Table from './Components/UI/Table/Table';

function App() {

  const [userInput, setUserInput] = useState(null);

  const yearlyData = []; // per-year results

  let currentSavings = +userInput['current-savings']; // feel free to change the shape of this input object!
  const yearlyContribution = +userInput['yearly-contribution']; // as mentioned: feel free to change the shape...
  const expectedReturn = +userInput['expected-return'] / 100;
  const duration = +userInput['duration'];

  // The below code calculates yearly results (total savings, interest etc)
  for (let i = 0; i < duration; i++) {
    const yearlyInterest = currentSavings * expectedReturn;
    currentSavings += yearlyInterest + yearlyContribution;
    yearlyData.push({
      // feel free to change the shape of the data pushed to the array!
      year: i + 1,
      yearlyInterest: yearlyInterest,
      savingsEndOfYear: currentSavings,
      yearlyContribution: yearlyContribution,
    });
  }

  // do something with yearlyData ...
  setResults(yearlyData);

const [savings, setSavings] = useState("");
const constAddSavingsHandler = saving => {
  setSavings(previousSavings => {
    return [saving, ...previousSavings];
  });
}

return (
  <div>
    <header className="header">
      <img src={logo} alt="logo" />
      <h1>Investment Calculator</h1>
    </header>

    <Form onCalculate={calculateHandler} />
    {/* Todo: Show below table conditionally (only once result data is available) */}
    {/* Show fallback text if no data is available */}
    <Table />

  </div>
);
}

export default App;
