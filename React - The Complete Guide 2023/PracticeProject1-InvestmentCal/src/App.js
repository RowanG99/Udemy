import React, { useState } from 'react';

import logo from './assets/investment-calculator-logo.png';
import Form from './Components/UI/Form/Form';
import Table from './Components/UI/Table/Table';

function App() {

  const [userInput, setUserInput] = useState(null);
  const yearlyData = [];
  const calculateHandler = (userInput) => {
    setUserInput(userInput);
  }

  const clearData = () => {
    setUserInput(null);
  }

  if (userInput) {
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
  }

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

      <Form onCalculate={calculateHandler} clear={clearData}/>
      {!userInput && <p style={{textAlign: 'center'}}>No investment calculated yet.</p>}
      {userInput && <Table data={yearlyData} initialInvestment={userInput['current-savings']}/>}

    </div>
  );
}

export default App;
