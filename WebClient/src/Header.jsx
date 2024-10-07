import React from 'react'
import styled from 'styled-components'
import {forwardRef} from 'react'
import { useContext } from 'react';
import { AuthContext } from './store/authentication-info-context';
const Header = forwardRef(function Header({},ref) {
  const authDialgRef = ref;
  const authCtx = useContext(AuthContext);
  const handleLoginLogoutClick = () =>{
    if(authCtx.auth.get.username == undefined && authCtx.auth.get.password == undefined){
      authDialgRef.current.showModal();
    }else{
      //some code to logout ...
      authCtx.auth.set.username(undefined);
      authCtx.auth.set.password(undefined);
      console.log('logout');
    }
  }
  return (
    <StyledHeader>
        <h1>MyLogo</h1>
        <button onClick={handleLoginLogoutClick}>
          {authCtx.auth.get.username == undefined ? 'Login' : 'Logout'}
        </button>
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
