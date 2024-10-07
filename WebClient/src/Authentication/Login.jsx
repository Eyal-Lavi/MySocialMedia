import { useContext, useRef } from "react";
import { AuthContext } from "../store/authentication-info-context";
import styled from "styled-components";
import InputAuth from "../utils/InputAuth";
const Login = ({updateAuthMode}) => {
    const authCtx = useContext(AuthContext);
    const usernameRef = useRef();
    const passwordRef = useRef();
    const handleSubmit = (event) => {
        event.preventDefault();
        authCtx.auth.set.username(usernameRef.current.value);
        authCtx.auth.set.password(passwordRef.current.value);
        console.log("Form submitted (login)");
    };
    const handleHaveNotAccount = ()=>{
        updateAuthMode(prevValue => !prevValue);
    };
    return(
        <FormStyled onSubmit={handleSubmit}>
           <h1>Login</h1>
            <InputAuth
                ref = {usernameRef}
                label="Username"
                type="text"
              />
            <InputAuth
                ref = {passwordRef}
                label="Password"
                type="password"
               />
           <button type="submit">Send</button>

           <button onClick={handleHaveNotAccount}>Have not account ?</button>
        </FormStyled>
    )
}
const FormStyled = styled.form`
    width:100%;
    height:100%;

    display:flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;
`;
export default Login;