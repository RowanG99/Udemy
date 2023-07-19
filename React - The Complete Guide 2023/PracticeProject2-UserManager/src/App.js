import React, {useState} from 'react';
import AddUser from './components/Users/AddUser';
import UserList from './components/Users/UsersList';

function App() {
  const [usersList, setUsersList] = useState([]);
  const addUserHandler = (userName, userAge) => {
    setUsersList((previousUserList) => {
      return [...previousUserList, {name: userName, age: userAge, id: Math.random().toString()}]
    });
  }

  return (
    // LIFTING THE STATE UP
    <div>      
      <AddUser onAddUser={addUserHandler}/>
      <UserList users={usersList}/>
    </div>
  )
}

export default App;
