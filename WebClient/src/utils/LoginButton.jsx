import { useContext } from "react";
import styled from "styled-components";
import { AuthContext } from "../store/authentication-info-context";

export default function LoginButton({onLoginClick , onLogoutClick}){
    const authCtx = useContext(AuthContext);
    const handleClick = () =>{
        if(authCtx.auth.get.username && authCtx.auth.get.password){
            onLogoutClick();
        }else{
            onLoginClick();
        }
    }
    return (
        <StyledLoginButton onClick={handleClick}  className="bebas-font">
              {authCtx.auth.get.username && authCtx.auth.get.password ? "Logout" : "Login"}
        </StyledLoginButton>
    )
}

const StyledLoginButton = styled.button`
  background-color: #17cbd4;
  border: none;
  border-radius: 30px;
  font-size: 20px;
  padding: 12px 24px;
  color: white;
  cursor: pointer;
  transition: background-color 0.3s ease, box-shadow 0.3s ease, transform 0.2s ease;
  height:20px;
  display: flex;
  align-items: center;
  justify-content: center;
  
  &:hover {
    background-color: #00ADB5;
    box-shadow: 0 8px 15px rgba(0, 0, 0, 0.1);
    transform: translateY(-3px);
  }

  &:active {
    background-color: #039da5;
    transform: translateY(0); 
  }

  &:focus {
    outline: none;
    box-shadow: 0 0 0 3px rgba(3, 157, 165, 0.5);
  }

  /* שינוי צבע הכפתור ל-logout */
  ${
    props => props.children === "Logout" &&
    `
        background-color: #f44336; /* צבע אדום ל-logout */
        &:hover {
          background-color: #e53935; /* אדום כהה יותר ב-hover */
        }
        &:active {
          background-color: #d32f2f; /* אדום כהה יותר בעת לחיצה */
        }
        &:focus {
          box-shadow: 0 0 0 3px rgba(244, 67, 54, 0.5); /* מסגרת אדומה רכה בעת פוקוס */
        }
    `
    }
    @media (min-width: 1024px){
      height:35px;
    }
`;