import React from 'react';

//Default state
const AuthContext = React.createContext({
    isLoggedIn: false
});

// Need to provide (wrap all components that neeed to listen) it and consume it (listen to it)
export default AuthContext;