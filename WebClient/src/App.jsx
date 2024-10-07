import './App.css'
import { AuthContext} from './store/authentication-info-context'
import { useRef, useState } from 'react'
// import styled from 'styled-components';
import Header from './Header.jsx';
import Footer from './Footer.jsx';
import MainData from './MainData.jsx';
import AuthModal from './Authentication/AuthDialog.jsx';

function App() {
  const dialog = useRef();
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
        username: authData.username,
        password: authData.password,
      },
      set : {
        username: handleUpdateUsername,
        password: handleUpdatePassword,
      }
    },

  }
  return (
    
    <AuthContext.Provider value={ctxValue}>{/*'ctxValue' here for set the real data*/}
        <AuthModal ref={dialog}/>

        <Header ref = {dialog}/>

        <MainData />
        
        <Footer/>
    </AuthContext.Provider>
  )
}
export default App
