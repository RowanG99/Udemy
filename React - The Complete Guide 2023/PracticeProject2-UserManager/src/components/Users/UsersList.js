import React from 'react';
import Card from '../UI/Card';
import classes from './UsersList.module.css';

const UserList = (props) => {
    return (
        <div>
            { props.users.length !== 0 ? 
                <Card className={classes.users}>
                    <ul>
                        {props.users.map((user) => (
                            <li key={user.id}>
                                {user.name} ({user.age} years old)
                            </li>
                        ))}
                    </ul>
                </Card> : null
            }
        </div>
    )
}

export default UserList