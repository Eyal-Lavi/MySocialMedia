import React from 'react'
import styled from 'styled-components'
import {forwardRef} from 'react'
import { useContext } from 'react';
import { AuthContext } from './store/authentication-info-context';
import LoginButton from './utils/LoginButton';
const Header = forwardRef(function Header({},ref) {
  const authDialgRef = ref;
  const authCtx = useContext(AuthContext);
  const handleLoginClick = () =>{
    authDialgRef.current.showModal();
  }
  const handleLogoutClick = () =>{
      //some code to logout ...
      authCtx.auth.set.username(undefined);
      authCtx.auth.set.password(undefined);
      console.log('logout');
  }

  return (
    <StyledHeader>
        <h1>SocialMedia</h1>
        <LoginButton onLoginClick={handleLoginClick} onLogoutClick={handleLogoutClick} >
          {authCtx.auth.get.username == undefined ? 'Login' : 'Logout'}
        </LoginButton>
    </StyledHeader>
  )
});
export default Header;

const StyledHeader = styled.header`
    background-color: red;
    height: 5vh;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding:5px 20px;

    & button{
        height: 35px;
    }
`;
