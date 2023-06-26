import React, { useState } from "react";

import './Form.css';


function Form(props) {

    const INITIAL_INPUT = {
        'current-savings': 1000,
        'yearly-contribution': 1200, 
        'expected-return': 7, 
        'duration': 10
    }; 

    const [userInput, setUserInput] = useState(INITIAL_INPUT); 

    const submitHandler = (event) => {
        event.preventDefault();
        props.onCalculate(userInput)
    };

    const resetHandler = () => {
        setUserInput(INITIAL_INPUT);
        props.clear();
    };

    const inputChangeHandler = (input, value) => {
        setUserInput((previousInput) => {
            return {
                ...previousInput, 
                [input]: +value
            };
        });
    };


    return (
        <form className="form" onSubmit={submitHandler}>
            <div className="input-group">
                <p>
                    <label htmlFor="current-savings">Current Savings ($)</label>
                    <input value = {userInput['current-savings']} type="number" id="current-savings" onChange={(event) => inputChangeHandler("current-savings", event.target.value)} />
                </p>
                <p>
                    <label htmlFor="yearly-contribution">Yearly Savings ($)</label>
                    <input value = {userInput['yearly-contribution']} type="number" id="yearly-contribution" onChange={(event) => inputChangeHandler("yearly-contribution", event.target.value)} />
                </p>
            </div>
            <div className="input-group">
                <p>
                    <label htmlFor="expected-return">
                        Expected Interest (%, per year)
                    </label>
                    <input value = {userInput['expected-return']} type="number" id="expected-return" onChange={(event) => inputChangeHandler("expected-return", event.target.value)} />
                </p>
                <p>
                    <label htmlFor="duration">Investment Duration (years)</label>
                    <input value = {userInput['duration']} type="number" id="duration" onChange={(event) => inputChangeHandler("duration", event.target.value)} />
                </p>
            </div>
            <p className="actions">
                <button onClick={resetHandler} type="reset" className="buttonAlt">
                    Reset
                </button>
                <button type="submit" className="button">
                    Calculate
                </button>
            </p>
        </form>)
}

export default Form;