import './App.css'
import { AuthContext , _defualtValue} from './store/authentication-info-context'
import AuthPage from './Authentication/AuthPage.jsx'
import { useState } from 'react'
import styled from 'styled-components';
import Header from './Header.jsx';
import Footer from './Footer.jsx';

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
      <FatherDiv>
        <Header/>

        <main>
          {/* <AuthPage/> */}
        </main>

        <Footer/>
      </FatherDiv>
    </AuthContext.Provider>
  )
}

const FatherDiv = styled.div`
  background-color: pink;
  width: 100vw;
  height: 100vh;
  overflow: hidden;
  
  & main{
    background-color: black;
    height: 90vh;
  }
`;
export default App
