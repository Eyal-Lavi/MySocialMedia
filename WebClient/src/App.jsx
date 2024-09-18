import './App.css'
import { AuthContext , _defualtValue} from './store/authentication-info-context'
import AuthPage from './Authentication/AuthPage.jsx'
import { useState } from 'react'

function App() {
  const [authData , setAuthData] = useState({
    username: undefined,
    password: undefined,
  });
  
  const handleUpdateUsername = (val) => {
    setAuthData(prevValue => ({
      ...prevValue ,
      username: val
    }))
  }
  const handleUpdatePassword = (val) => {
    setAuthData(prevValue => ({
      ...prevValue ,
      password: val
    }))
  }
  
  const ctxValue = {
    auth:{
      get : {
        username: undefined,
        password: undefined,
      },
      set : {
        username: handleUpdateUsername,
        password: handleUpdatePassword,
      }
    },

  }
  return (
    <AuthContext.Provider value={ctxValue}>
      <AuthPage/>
    </AuthContext.Provider>
  )
}

export default App
