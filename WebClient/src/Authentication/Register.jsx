import { useContext, useRef } from "react";
import { AuthContext } from "../store/authentication-info-context";
import styled from "styled-components";
import InputAuth from "../utils/InputAuth";
const Register = ({updateAuthMode}) => {
    const authCtx = useContext(AuthContext);
    const firstnameRef = useRef();
    const lastnameRef = useRef();
    const usernameRef = useRef();
    const passwordRef = useRef();
    const handleSubmit = (event) => {
        event.preventDefault();
        //some code to complete register
        console.log("Form submitted (register)");
    };
    const handleHaveNotAccount = ()=>{
        updateAuthMode(prevValue => !prevValue);
    };
    return(
        <FormStyled onSubmit={handleSubmit}>
        <h1>Register</h1>
        <InputAuth
             ref = {firstnameRef}
             label="First Name"
             type="text"
           />
        <InputAuth
             ref = {lastnameRef}
             label="Last Name"
             type="text"
           />
         <InputAuth
             ref = {usernameRef}
             label="User Name"
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
export default Register;