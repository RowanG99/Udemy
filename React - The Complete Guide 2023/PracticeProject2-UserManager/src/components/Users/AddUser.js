import React from 'react'
import Card from '../UI/Card'
import Button from '../UI/Button'
import classes from './AddUser.module.css'

function AddUser(props) {
    const addUserHandler = (event) => {
        event.preventDefault();
    }
    return (
        <div>
            <Card className={classes.input}>
                <form onSubmit={addUserHandler}>
                    <label htmlfor="username">Username</label>
                    <input id="username" type="text" />
                    <label htmlfor="age">Ages (Years)</label>
                    <input id="age" type="number" />
                    <Button className={classes.button} type="submit">Add User</Button>
                </form>
            </Card>
        </div>
    )
}

export default AddUser;